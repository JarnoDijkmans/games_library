using Factory;
using LogicLayer.Models.CartRelated;
using LogicLayer.Models.CheckoutRelated;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Models.UserFolder;
using LogicLayer.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
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
        public string ErrorMessage { get; set; }
        private int? UserId { get; set; }
        
        CheckoutService checkoutservice = CheckoutFactory.checkoutservice;
        
        GameService gameService = GameFactory.gameservice;
        public CartViewModel Cart { get; set; } = new CartViewModel();
        public IActionResult OnGet()
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

                Cart.GamesInCart = gameIds.Select(id => gameService.GetGameById(id)).ToList();

                Cart.Subtotal = checkoutservice.CalculateSubtotal(Cart);

                if (!string.IsNullOrEmpty(user.Birthdate))
                {
                    DateTime.TryParse(user.Birthdate, out DateTime parsedBirthdate);
                    var totalBeforeDiscount = Cart.Subtotal;
                    Cart.Subtotal = checkoutservice.ApplyDiscount("", Cart.Subtotal, parsedBirthdate);
                    Cart.DiscountedTotal = checkoutservice.CalculateAmountDiscount(totalBeforeDiscount, Cart.Subtotal);  
                }
                HttpContext.Session.SetString("TotalPrice", Cart.Subtotal.ToString());
                return Page();
            }
            else
            {
                return RedirectToPage("Index");
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
               
                Cart.GamesInCart = gameIds.Select(id => gameService.GetGameById(id)).ToList();

                Cart.Subtotal = checkoutservice.CalculateSubtotal(Cart);
                
                if (action == "apply")
                {
                    if (!string.IsNullOrEmpty(user.Birthdate))
                    {
                        DateTime.TryParse(user.Birthdate, out DateTime parsedBirthdate);
                        var totalBeforeDiscount = Cart.Subtotal;
                        Cart.Subtotal = checkoutservice.ApplyDiscount(discountCode, Cart.Subtotal, parsedBirthdate);
                        Cart.DiscountedTotal = checkoutservice.CalculateAmountDiscount(totalBeforeDiscount, Cart.Subtotal);
                        Cart.DiscountCode = discountCode;
                    }
                    else
                    {
                        ErrorMessage = "Something went wrong.";
                    }
                }
                if (action == "remove")
                {
                    Cart.Subtotal = checkoutservice.CalculateSubtotal(Cart);
                    if (!string.IsNullOrEmpty(user.Birthdate))
                    {
                        DateTime.TryParse(user.Birthdate, out DateTime parsedBirthdate);
                        var totalBeforeDiscount = Cart.Subtotal;
                        Cart.Subtotal = checkoutservice.ApplyDiscount("", Cart.Subtotal, parsedBirthdate);
                        Cart.DiscountedTotal = checkoutservice.CalculateAmountDiscount(totalBeforeDiscount, Cart.Subtotal);
                    }
                }
                HttpContext.Session.SetString("TotalPrice", Cart.Subtotal.ToString());
            }
        }
        public async Task<IActionResult> OnPostProcessPayment()
        {
            CheckoutService checkoutservice = CheckoutFactory.checkoutservice;

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
                decimal rawTotalAmount = decimal.Parse(totalPriceData);
                decimal TotalAmount = Math.Max(0, rawTotalAmount);
                TotalAmount = Math.Round(TotalAmount, 2);

                if (checkoutInfo.PaymentType != null)
                {
                    string paymentType = checkoutInfo.PaymentType.ToString();
                    CheckoutInfo Checkout = new CheckoutInfo
                    (
                        0,
                        paymentType,
                        TotalAmount,
                        games,
                        UserId,
                        DateTime.Now
                    );

                    checkoutservice.StorePayment(Checkout);

                    return RedirectToPage("/Library");
                }
                else
                {
                    TempData["ErrorMessage"] = "Please select a Payment option first.";
                    return RedirectToPage("/Checkout");
                }
                
            }
            return RedirectToPage("/Checkout");
        }
    }




}
