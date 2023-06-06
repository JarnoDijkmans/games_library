using Factory;
using LogicLayer.Models.CheckoutRelated;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class LibraryModel : PageModel
    {
        public List<Game> PurchasedGames { get; set; }
        CheckoutService checkoutservice = CheckoutFactory.checkoutservice;
        public ActionResult OnGet()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                GameService gameService = GameFactory.gameservice;
                var purchases = checkoutservice.GetPaymentById(Convert.ToInt32(userId));
                PurchasedGames = new List<Game>();
                foreach (var purchase in purchases) 
                { 
                    foreach(var gameId in purchase.GameIds)
                    {
                        var game = gameService.GetGameById(gameId);
                        if (game != null)
                        {
                            PurchasedGames.Add(game);
                        }
                    }
                }
                return this.Page();
            }
            

            else
            {
                return RedirectToPage("Index");
            }


        }
    }
}
