using Factory;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class ShoppingCartModel : PageModel
    {
        public List<Game> GamesInCart { get; set; } = new List<Game>();
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
                // If the user is logged in, use the user ID as the key
                cartDataKey = $"CartData_{userId}";
            }
            else
            {
                // If the user is not logged in, use a temporary identifier
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
                // Create a new list if there's no existing cart data
                gameIds = new List<int>();
            }

            // Add the gameId to the list
            if (gameId.HasValue && !gameIds.Contains(gameId.Value))
            {
                gameIds.Add(gameId.Value);
            }

            // Serialize and store the updated list in the session
            string serializedCartData = JsonSerializer.Serialize(gameIds);
            HttpContext.Session.SetString(cartDataKey, serializedCartData);

            GameService gameService = GameFactory.gameservice;
            GamesInCart = gameIds.Select(id => gameService.GetGameById(id)).ToList();
        }


        [HttpPost("RemoveFromCart")]
        [ValidateAntiForgeryToken]
        public IActionResult OnPostRemoveFromCart(int gameId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            string cartDataKey;

            if (userId.HasValue)
            {
                // If the user is logged in, use the user ID as the key
                cartDataKey = $"CartData_{userId}";
            }
            else
            {
                // If the user is not logged in, use the temporary identifier for the session
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
                // Return an error response if the cart data is not found
                return new JsonResult(new { success = false, message = "No cart data found" });
            }
        }

        public void OnPost()
        {
            // Retrieving user ID
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                // Retrieving cart data
                string serializedCartData = HttpContext.Session.GetString($"CartData_{userId}");
                List<int> gameIds = JsonSerializer.Deserialize<List<int>>(serializedCartData);
            }
            else
            {
                // Handle the case when the user is not logged in
            }
        }
    }
}
