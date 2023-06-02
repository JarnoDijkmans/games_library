using Factory;
using LogicLayer.Models.CartRelated;
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
    }
}
