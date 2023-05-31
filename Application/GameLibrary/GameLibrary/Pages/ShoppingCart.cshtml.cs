using Factory;
using LogicLayer.Models.CartRelated;
using LogicLayer.Models.Discount;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Models.UserFolder;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace WebApp.Pages
{
    public class ShoppingCartModel : PageModel
    {
        public CartViewModel Cart { get; set; } = new CartViewModel();

        public void OnGet(int? gameId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                UserService userService = UserFactory.userservice;
                var user = userService.GetUserById(userId.Value);
                ViewData["User"] = user;
            }
            string cartDataKey;

            if (userId.HasValue)
            {
                cartDataKey = $"CartData_{userId}";
            }
            else
            {

                string tempId = HttpContext.Request.Cookies["TempId"];

                // If the temporary identifier doesn't exist, create one and store it in a cookie
                if (string.IsNullOrEmpty(tempId))
                {
                    tempId = Guid.NewGuid().ToString();
                    HttpContext.Response.Cookies.Append("TempId", tempId);
                }

                cartDataKey = $"CartData_{tempId}";
            }

            // Check if there's already cart data for the current user or session
            string existingCartData = HttpContext.Session.GetString(cartDataKey);
            List<int> gameIds;

            if (!string.IsNullOrEmpty(existingCartData))
            {
                // Deserialize the existing cart data
                gameIds = JsonSerializer.Deserialize<List<int>>(existingCartData);
            }
            else
            {
                gameIds = new List<int>();
            }


            if (gameId.HasValue && !gameIds.Contains(gameId.Value))
            {
                gameIds.Add(gameId.Value);
            }

            // Serialize and store the updated list
            string serializedCartData = JsonSerializer.Serialize(gameIds);
            HttpContext.Session.SetString(cartDataKey, serializedCartData);

            GameService gameService = GameFactory.gameservice;
            if (Cart == null)
            {
                Cart = new CartViewModel();
            }
            Cart.GamesInCart = gameIds.Select(id => gameService.GetGameById(id)).ToList();
        }


        private List<Game> RetrieveCartGames()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            string cartDataKey;

            if (userId.HasValue)
            {
                cartDataKey = $"CartData_{userId}";
            }
            else
            {
                string tempId = HttpContext.Request.Cookies["TempId"];
                if (string.IsNullOrEmpty(tempId))
                {
                    tempId = Guid.NewGuid().ToString();
                    HttpContext.Response.Cookies.Append("TempId", tempId);
                }
                cartDataKey = $"CartData_{tempId}";
            }

            string existingCartData = HttpContext.Session.GetString(cartDataKey);
            List<int> gameIds = new List<int>();

            if (!string.IsNullOrEmpty(existingCartData))
            {
                gameIds = JsonSerializer.Deserialize<List<int>>(existingCartData);
            }

            GameService gameService = GameFactory.gameservice;
            return gameIds.Select(id => gameService.GetGameById(id)).ToList();
        }


        [HttpPost("RemoveFromCart")]
        [ValidateAntiForgeryToken]
        public IActionResult OnPostRemoveFromCart(int gameId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            string cartDataKey;

            if (userId.HasValue)
            {
                cartDataKey = $"CartData_{userId}";
            }
            else
            {
                // If the user is not logged in, use the temporary identifier
                string tempId = HttpContext.Request.Cookies["TempId"];
                cartDataKey = $"CartData_{tempId}";
            }

            // Retrieve the existing cart data from the session
            string existingCartData = HttpContext.Session.GetString(cartDataKey);
            List<int> gameIds;

            if (!string.IsNullOrEmpty(existingCartData))
            {
                gameIds = JsonSerializer.Deserialize<List<int>>(existingCartData);
                gameIds.Remove(gameId);

                string serializedCartData = JsonSerializer.Serialize(gameIds);
                HttpContext.Session.SetString(cartDataKey, serializedCartData);

                return new JsonResult(new { success = true, message = "Game removed successfully" });
            }
            else
            {
                return new JsonResult(new { success = false, message = "No cart data found" });
            }
        }


        public void OnPostApplyDiscount(string discountCode)
        {

            List<Game> gamesInCart = RetrieveCartGames();
            decimal subtotal = gamesInCart.Sum(g => g.Price);
            CheckoutService checkout = CheckoutFactory.checkout;

            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                UserService userService = UserFactory.userservice;
                var user = userService.GetUserById(userId.Value);
                DateTime userBirthdate;

                var styles = System.Globalization.DateTimeStyles.None;
                var culture = System.Globalization.CultureInfo.InvariantCulture;

                if (!string.IsNullOrEmpty(user.Birthdate))
                {
                    if (!DateTime.TryParseExact(user.Birthdate, "yyyy-MM-dd", culture, styles, out userBirthdate))
                    {
                        throw new Exception("Invalid birthdate format");
                    }
                    if (userBirthdate.Date.Month == DateTime.Now.Month && userBirthdate.Date.Day == DateTime.Now.Day)
                    {
                        checkout.ApplyBirthdayDiscount("BirthDate");
                    }
                }
            }
            if (!checkout.ApplyDiscountByCode(discountCode))
            {
                ModelState.AddModelError("", "Discount code not valid. Please try another one.");
            }
            decimal discountedTotal = checkout.CalculateTotalPrice(subtotal);
            UserService userServiceCopy = UserFactory.userservice;
            if (userId.HasValue)
            {
                var userCopy = userServiceCopy.GetUserById(userId.Value);
                DateTime userBirthdateCopy;

                var styless = System.Globalization.DateTimeStyles.None;
                var cultures = System.Globalization.CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(userCopy.Birthdate))
                {
                    if (!DateTime.TryParseExact(userCopy.Birthdate, "yyyy-MM-dd", cultures, styless, out userBirthdateCopy))
                    {
                        throw new Exception("Invalid birthdate format");
                    }
                    if (userBirthdateCopy.Date.Month == DateTime.Now.Month && userBirthdateCopy.Date.Day == DateTime.Now.Day)
                    {
                        decimal discountedWithBithdayTotal = checkout.CalculateTotalPriceBirthDate(discountedTotal, userBirthdateCopy);
                        Cart.GamesInCart = gamesInCart;
                        Cart.Subtotal = subtotal;
                        decimal roundedDiscountedTotal = Math.Round(discountedWithBithdayTotal, 2);
                        Cart.DiscountedTotal = roundedDiscountedTotal;
                        if (discountCode != null)
                        {
                            Cart.DiscountCode = discountCode;
                        }

                    }
                    else
                    {
                        HttpContext.Session.SetString("DiscountCode", discountCode ?? "No discount code");
                        HttpContext.Session.SetString("DiscountedTotal", discountedTotal.ToString());

                        Cart.GamesInCart = gamesInCart;
                        Cart.Subtotal = subtotal;
                        decimal roundedDiscountTotal = Math.Round(discountedTotal, 2);
                        Cart.DiscountedTotal = roundedDiscountTotal;
                        Cart.DiscountCode = discountCode;
                    }
                }
            }
            else
            {
                HttpContext.Session.SetString("DiscountCode", discountCode ?? "No discount code");
                HttpContext.Session.SetString("DiscountedTotal", discountedTotal.ToString());

                Cart.GamesInCart = gamesInCart;
                Cart.Subtotal = subtotal;
                decimal roundedDiscountTotal = Math.Round(discountedTotal, 2);
                Cart.DiscountedTotal = roundedDiscountTotal;
                Cart.DiscountCode = discountCode;
            }
        }
        public IActionResult OnPost(List<int> gameIds, User loggedInUser)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {        
                string cartDataKey = $"CartData_{userId}";

                string existingCartData = HttpContext.Session.GetString(cartDataKey);

                if (!string.IsNullOrEmpty(existingCartData))
                {
                    gameIds = JsonSerializer.Deserialize<List<int>>(existingCartData);
                }

                decimal totalPrice = Cart.Subtotal;

                HttpContext.Session.SetString("TotalPrice", totalPrice.ToString());

                string serializedCartData = JsonSerializer.Serialize(gameIds);
                HttpContext.Session.SetString(cartDataKey, serializedCartData);
            }
            else
            {
                return RedirectToPage("Login");
            }

            return RedirectToPage("Checkout");
        }
    }
}
