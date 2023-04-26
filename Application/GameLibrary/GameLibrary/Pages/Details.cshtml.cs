using Factory;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// Other using statements

namespace WebApp.Pages
{
    public class DetailsModel : PageModel
    {
        public Game Game { get; set; }

        public IActionResult OnGet(int id)
        {
            GameService gameService = GameFactory.gameservice;
            // Fetch game data based on the ID, for example:
            Game = gameService.GetGameById(id);

            if (Game == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

