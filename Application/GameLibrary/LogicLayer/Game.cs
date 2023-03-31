using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
	public class Game
	{
		public string GameId { get; set; }
		public string GameName { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public int Catagory { get; set; }
		public string ImageURL { get; set; }


		public Game(string gameId, string gameName, decimal price, string description, int catagory, string imageURL)
		{
			GameId = gameId;
			GameName = gameName;
			Price = price;
			Description = description;
			Catagory = catagory;
			ImageURL = imageURL;
		}
	}


}
