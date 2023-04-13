using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models.GamesFolder;

namespace LogicLayer.Models
{
    public class Purchase
    {
        public int purchaseID;
        public Costumer User;
        public Game Game;
        public string PurhaseDate;
        public decimal TotalPrice;

        public Purchase(Costumer user, Game game, string purchaseDate, decimal totalprice)
        {
            User = user;
            Game = game;
            PurhaseDate = purchaseDate;
            TotalPrice = totalprice;
        }

    }
}
