using LogicLayer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
	public class Purchase
	{
		public int purchaseID;
		public Costumer User;
		public Game Game;
		public string PurhaseDate;
		public decimal TotalPrice;

		public Purchase (Costumer user, Game game, string purchaseDate, decimal totalprice)
		{
			this.User = user;
			this.Game = game;
			this.PurhaseDate = purchaseDate;
			this.TotalPrice = totalprice;
		}

	}
}
