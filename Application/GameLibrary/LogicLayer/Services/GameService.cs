using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DAL;


namespace LogicLayer.Services
{
	public class GameService
	{
		private readonly IGameDAL dal;
		private List<Game> games = new List<Game>();

		public GameService(IGameDAL dal)
		{
			this.dal = dal;
		}

		public List<Game> GetGames()
		{
			// haal alles op van database
			games = dal.GetAll();

			// zet om naar een game dao
			var listOfGameDao = new List<Game>();
			foreach (var item in games)
			{
				var game = new Game(item.GameId, item.GameName, item.Price, item.Description, item.Catagory, item.ImageURL);
				listOfGameDao.Add(game);
			}

			return listOfGameDao;
		}

	}
}
