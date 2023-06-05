using Factory;
using LogicLayer.Models.CheckoutRelated;
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
            ViewData["PurchasedGames"] = new List<Game>();
            ModelState.Clear();
            GameService gameService = GameFactory.gameservice;
            Games = gameService.GetGames();

            // Retrieve user ID
            int? userId = HttpContext.Session.GetInt32("UserId");

            // If the user is logged in, get the user information
            if (userId.HasValue)
            {
                UserService userService = UserFactory.userservice;
                var user = userService.GetUserById(userId.Value);
                ViewData["User"] = user;

                CheckoutService checkoutService = CheckoutFactory.checkoutservice;
                var checkoutInfos = checkoutService.GetPaymentById(Convert.ToInt32(userId));
                
                List<Game> purchasedGames = new List<Game>();

                // If there is checkoutInfo, get the Games for each GameId in the checkoutInfo
                if (checkoutInfos != null)
                {
                    foreach (var checkoutInfo in checkoutInfos)
                    {
                        foreach (var gameId in checkoutInfo.GameIds)
                        {
                            var game = gameService.GetGameById(gameId);
                            if (game != null && !purchasedGames.Contains(game))
                            {
                                purchasedGames.Add(game);
                            }
                        }
                    }
                }

                ViewData["PurchasedGames"] = purchasedGames;
            }
        }

        public IActionResult OnGetAutocomplete(string term)
        {
            GameService gameService = GameFactory.gameservice;
            var games = gameService.SearchGames(term)
                    .Select(g => new { label = g.Title, id = g.GameId })
                    .ToList();

            return new JsonResult(games);
        }

    }
}