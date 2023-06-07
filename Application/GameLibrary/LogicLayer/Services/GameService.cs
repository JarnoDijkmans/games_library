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
			return dal.AddGame(game);
		}

		public Game GetGameById(int id)
		{
			return dal.GetGameById(id);
		}

		public List<Game> SearchGames(string name)
		{
			return dal.SearchGames(name);
		}

		public List<Genre> GetGenres()
		{
			return dal.GetAllGenres();
		}

        public int GetGenreIdByName(string name)
        {
            var genre = dal.GetAllGenres().FirstOrDefault(g => g.Name == name);
            return genre.GenreId;
        }

        public List<Feature> GetFeatures()
		{
			return dal.GetAllFeatures();
		}

		public bool UpdateGame(Game game)
		{
			if (dal.UpdateGame(game))
			{
				return true;
			}
			else { return false; }
		}


        public int GetFeatureIdByName(string name)
        {
            var feature = dal.GetAllFeatures().FirstOrDefault(g => g.Name == name);
            return feature.FeatureID;
        }
    }
}
