using Factory;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
// Other using statements

namespace WebApp.Pages
{
    public class DetailsModel : PageModel
    {
        public Game Game { get; set; }
        public int UserId { get; set; }

        public IActionResult OnGet(int id)
        {
            GameService gameService = GameFactory.gameservice;
            Game = gameService.GetGameById(id);

            if (Game == null)
            {
                return NotFound();
            }

            int? userId = HttpContext.Session.GetInt32("UserId");
            bool hasPurchased = false;

            if (userId.HasValue)
            {
                UserService userService = UserFactory.userservice;
                var user = userService.GetUserById(userId.Value);
                ViewData["User"] = user;


                CheckoutService checkoutService = CheckoutFactory.checkoutservice;
                hasPurchased = checkoutService.HasUserPurchasedGame(userId.Value, id);
            }

            //User purchased games
            ViewData["HasPurchased"] = hasPurchased;

            return Page();
        }

        public IActionResult OnPost(int gameId)
        {
             List<int> gameIds = new List<int>();

            // Retrieve the existing gameIds from the session if they exist
            if (HttpContext.Session.GetString("CartData") != null)
            {
                string serializedCartData = HttpContext.Session.GetString("CartData");
                gameIds = JsonSerializer.Deserialize<List<int>>(serializedCartData);
            }

            // Add the gameId to the list
            if (!gameIds.Contains(gameId))
            {
                gameIds.Add(gameId);
            }

            // Serialize and store the updated list in the session
            string newSerializedCartData = JsonSerializer.Serialize(gameIds);
            HttpContext.Session.SetString("CartData", newSerializedCartData);

            // Redirect to the shopping cart page
            return RedirectToPage("ShoppingCart", new { gameId });
        }
    }
}
