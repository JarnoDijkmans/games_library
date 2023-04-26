using DataLayer.Connection;
using DataLayer.Converting.GamesDataConvert;
using LogicLayer.Models;
using LogicLayer.Models.GamesFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class GameDAL : Datahandler, IGameDAL
    {
        protected override string cmd
        {
            get
            {
                return "SELECT Game.GameID,Game.Title,Game.Price,Game.Description,Game.Requirements,Game.Release_date,Game.Publisher,Game.Trailer,STUFF((SELECT DISTINCT ', ' + Genre.Name FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Genres, STUFF((SELECT DISTINCT ', ' + Feature.Name FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Features, STUFF((SELECT ',' + CAST(Genre.GenreID AS VARCHAR) FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS GenreIDs, STUFF((SELECT ',' + CAST(Feature.FeatureID AS VARCHAR) FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS FeatureIDs, (SELECT STUFF((SELECT ',' + CAST(GameImages.ImageID AS VARCHAR) FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageIDs, (SELECT STUFF((SELECT ',' + GameImages.ImageURL FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageURLs, (SELECT STUFF((SELECT ',' + GameImages.ImageType FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageTypes FROM Game LEFT JOIN GameGenre ON Game.GameID = GameGenre.GameID LEFT JOIN Genre ON GameGenre.GenreID = Genre.GenreID LEFT JOIN GameFeature ON Game.GameID = GameFeature.GameID LEFT JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID GROUP BY Game.GameID, Game.Title, Game.Price, Game.Description, Game.Requirements, Game.Release_date, Game.Publisher, Game.Trailer;";
            }
        }
        public List<Game> RetrieveData()
        {
            List<Game> games = new List<Game>();

            DataTable dt = base.ReadData();
            GameDAL gameDal = new GameDAL();

             foreach (DataRow dr in dt.Rows)
             {
                 Game game = DataConvertingGames.ConvertDataRowToGame(dr, gameDal);
                 games.Add(game);

             }
               return games;
        }

        public bool AddGame(Game game)
        {
            //Just a test.
            string query = $"test";
            int gameID = executeQuery(query);
            return gameID > 0;
        }

        private string GetGameByIdQuery(int gameId)
        {
            return $@"SELECT Game.GameID,Game.Title,Game.Price,Game.Description,Game.Requirements,Game.Release_date,Game.Publisher,Game.Trailer,
            STUFF((SELECT DISTINCT ', ' + Genre.Name FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Genres,
            STUFF((SELECT DISTINCT ', ' + Feature.Name FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Features,
            STUFF((SELECT ',' + CAST(Genre.GenreID AS VARCHAR) FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS GenreIDs,
            STUFF((SELECT ',' + CAST(Feature.FeatureID AS VARCHAR) FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS FeatureIDs,
            (SELECT STUFF((SELECT ',' + CAST(GameImages.ImageID AS VARCHAR) FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageIDs,
            (SELECT STUFF((SELECT ',' + GameImages.ImageURL FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageURLs,
            (SELECT STUFF((SELECT ',' + GameImages.ImageType FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageTypes
            FROM Game LEFT JOIN GameGenre ON Game.GameID = GameGenre.GameID LEFT JOIN Genre ON GameGenre.GenreID = Genre.GenreID
            LEFT JOIN GameFeature ON Game.GameID = GameFeature.GameID LEFT JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID
            WHERE Game.GameID = {gameId}
            GROUP BY Game.GameID, Game.Title, Game.Price, Game.Description, Game.Requirements, Game.Release_date, Game.Publisher, Game.Trailer;";
        }
        
        public Game GetGameById(int id)
        {
            string query = GetGameByIdQuery(id);
            DataTable dt = ReadDataQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return DataConvertingGames.ConvertDataRowToGame(row, this);
            }

            return null;
        }
    }
}
