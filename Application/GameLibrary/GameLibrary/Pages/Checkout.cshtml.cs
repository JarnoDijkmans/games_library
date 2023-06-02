using Factory;
using LogicLayer.Models.CartRelated;
using LogicLayer.Models.CheckoutRelated;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Models.UserFolder;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Common;
using System.Text.Json;

namespace WebApp.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public CheckoutInfo checkoutInfo { get; set; }
        private int? UserId { get; set; }
        private readonly CheckoutService _checkoutService;



        public CheckoutModel(CheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }


        public CartViewModel Cart { get; set; } = new CartViewModel();
        public void OnGet()
        {
            
            UserId = HttpContext.Session.GetInt32("UserId");

            if (UserId.HasValue)
            {
                UserService userService = UserFactory.userservice;
                var user = userService.GetUserById(UserId.Value);
                ViewData["User"] = user;

                string cartDataKey = $"CartData_{UserId.Value}";

                string existingCartData = HttpContext.Session.GetString(cartDataKey);

                List<int> gameIds;
                if (!string.IsNullOrEmpty(existingCartData))
                {
                    gameIds = JsonSerializer.Deserialize<List<int>>(existingCartData);
                }
                else
                {
                    gameIds = new List<int>();
                }

                GameService gameService = GameFactory.gameservice;
                if (Cart == null)
                {
                    Cart = new CartViewModel();
                }
                Cart.GamesInCart = gameIds.Select(id => gameService.GetGameById(id)).ToList();

                foreach (var game in Cart.GamesInCart)
                {
                    Cart.Subtotal += game.Price;
                }

                DateTime userBirthdate;
                var styles = System.Globalization.DateTimeStyles.AdjustToUniversal;
                var culture = System.Globalization.CultureInfo.InvariantCulture;

                if (!string.IsNullOrEmpty(user.Birthdate))
                {
                    if (!DateTime.TryParse(user.Birthdate, culture, styles, out userBirthdate))
                    {
                        throw new Exception("Invalid birthdate format");
                    }
                    if (userBirthdate.Date.Month == DateTime.UtcNow.Month && userBirthdate.Date.Day == DateTime.UtcNow.Day)
                    {
                        _checkoutService.ApplyBirthdayDiscount("BirthDate");
                        Cart.Subtotal = _checkoutService.CalculateTotalPriceBirthDate(Cart.Subtotal, userBirthdate);
                        
                    }
                }
                HttpContext.Session.SetString("TotalPrice", Cart.Subtotal.ToString());

            }
        }

        public void OnPostApplyDiscount(string discountCode, string action)
        {
            UserId = HttpContext.Session.GetInt32("UserId");

            if (UserId.HasValue)
            {
                UserService userService = UserFactory.userservice;
                var user = userService.GetUserById(UserId.Value);
                ViewData["User"] = user;

                string cartDataKey = $"CartData_{UserId.Value}";

                string existingCartData = HttpContext.Session.GetString(cartDataKey);

                List<int> gameIds;
                if (!string.IsNullOrEmpty(existingCartData))
                {
                    gameIds = JsonSerializer.Deserialize<List<int>>(existingCartData);
                }
                else
                {
                    gameIds = new List<int>();
                }

                GameService gameService = GameFactory.gameservice;
                if (Cart == null)
                {
                    Cart = new CartViewModel();
                }
                Cart.GamesInCart = gameIds.Select(id => gameService.GetGameById(id)).ToList();

                string totalPriceData = HttpContext.Session.GetString("TotalPrice");

                Cart.Subtotal = decimal.Parse(totalPriceData);
                if (action == "apply")
                {
                    bool discountApplied = _checkoutService.ApplyDiscountByCode(discountCode);
                    if (discountApplied)
                    {
                        Cart.Subtotal = _checkoutService.CalculateTotalPrice(Cart.Subtotal);
                        Cart.DiscountCode = discountCode;
                    }
                    else
                    {
                        // Handle invalid discount code
                    }
                }
                if (action == "remove")
                {
                    _checkoutService.ApplyDiscountByCode(null);
                    Cart.Subtotal = _checkoutService.CalculateTotalPrice(Cart.Subtotal);
                }
            }
        }
        public async Task<IActionResult> OnPostProcessPayment()
        {
            UserId = HttpContext.Session.GetInt32("UserId");

            if (UserId.HasValue)
            {
                UserService userService = UserFactory.userservice;
                var user = userService.GetUserById(UserId.Value);
                ViewData["User"] = user;

                string cartDataKey = $"CartData_{UserId.Value}";

                string existingCartData = HttpContext.Session.GetString(cartDataKey);

                List<int> gameIds;
                if (!string.IsNullOrEmpty(existingCartData))
                {
                    gameIds = JsonSerializer.Deserialize<List<int>>(existingCartData);
                }
                else
                {
                    gameIds = new List<int>();
                }

                GameService gameService = GameFactory.gameservice;
                if (Cart == null)
                {
                    Cart = new CartViewModel();
                }
                List<int> games = gameIds;

                string totalPriceData = HttpContext.Session.GetString("TotalPrice");

                decimal TotalAmount = decimal.Parse(totalPriceData);
                if (checkoutInfo.PaymentType != null)
                {
                    string paymentType = checkoutInfo.PaymentType.ToString();
                    CheckoutInfo CheckoutInfo = new CheckoutInfo
                    (
                        0,
                        paymentType,
                        TotalAmount,
                        games,
                        UserId,
                        DateTime.Now
                    );

                    return RedirectToPage("/Success");
                }
                
            }
            return RedirectToPage("/Checkout");
        }
    }
}
