using Factory;
using LogicLayer.Models.CartRelated;
using LogicLayer.Models.UserFolder;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class CheckoutModel : PageModel
    {
        public decimal TotalPrice { get; set; }
        public int? UserId { get; set; }
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

                string totalPriceData = HttpContext.Session.GetString("TotalPrice");
                if (!string.IsNullOrEmpty(totalPriceData))
                {
                    Cart.Subtotal = Convert.ToDecimal(totalPriceData);
                }

                GameService gameService = GameFactory.gameservice;
                if (Cart == null)
                {
                    Cart = new CartViewModel();
                }
                Cart.GamesInCart = gameIds.Select(id => gameService.GetGameById(id)).ToList();
            }
        }
    }
}
