using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DAL;
using LogicLayer.Models.GamesFolder;

namespace LogicLayer.Services
{
    public class GameService
	{
		private readonly IGameDAL dal;

		public GameService(IGameDAL dal)
		{
			this.dal = dal;
		}

		public List<Game> GetGames()
		{
			return dal.RetrieveData();
		}

		public bool AddGame(Game game)
		{
			if (game.Title.Length > 25)
				throw new InvalidOperationException("Title can not extend 25 chars");

			return dal.AddGame(game);
		}

		public Game GetGameById(int id)
		{ 
			return dal.GetGameById(id);
		}

		public List <Game> SearchGames(string name)
		{
			return dal.SearchGames(name);
		}
	}
}
