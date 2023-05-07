using Factory;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLibrary.Pages
{
    public class IndexModel : PageModel
    { 
        public List<Game> Games { get; set; }
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ModelState.Clear();
            GameService gameService = GameFactory.gameservice;
            Games = gameService.GetGames();

            // Retrieve user ID
            int? userId = HttpContext.Session.GetInt32("UserId");

            // If the user is logged in, get the user information
            if (userId.HasValue)
            {
                // Assuming you have a UserService to get user information
                UserService userService = UserFactory.userservice;
                var user = userService.GetUserById(userId.Value);
                ViewData["User"] = user;
            }
        }
    }
}