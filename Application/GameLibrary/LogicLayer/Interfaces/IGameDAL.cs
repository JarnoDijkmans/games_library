using LogicLayer.Models.GamesFolder;

namespace DataLayer.DAL
{
    public interface IGameDAL
    {
        bool AddGame(Game game);
        public List<Game> RetrieveData();
        public Game GetGameById(int id);
    }
}