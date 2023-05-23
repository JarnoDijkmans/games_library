using LogicLayer.Models.GamesFolder;

namespace DataLayer.DAL
{
    public interface IGameDAL
    {
        bool AddGame(Game game);
        List<Genre> GetAllGenres();
        Game GetGameById(int id);
        List<Game> RetrieveData();
        List<Game> SearchGames(string name);
    }
}