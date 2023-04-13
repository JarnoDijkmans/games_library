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
            List<Game> Games = new List<Game>();
            Games.AddRange(gameService.GetGames());
        }
    }
}