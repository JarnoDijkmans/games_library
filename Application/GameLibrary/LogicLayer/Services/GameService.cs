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
		private List<Game> games = new List<Game>();

		public GameService(IGameDAL dal)
		{
			this.dal = dal;
		}

		public List<Game> GetGames()
		{
			// Get everything out of datalayer
			return dal.RetrieveData();
		}

		public bool AddGame(Game game)
		{
			return dal.AddGame(game);
		}

		public Game GetGameById(int id)
		{ 
			return dal.GetGameById(id);
		}
	}
}
