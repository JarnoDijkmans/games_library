using DataLayer.Connection;
using DataLayer.Converting.GamesDataConvert;
using LogicLayer.Models;
using LogicLayer.Models.GamesFolder;
using System;
using System.Collections;
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
                return "SELECT Game.GameID, Game.Title, Game.Price, Game.Description, Game.Release_date, Game.Publisher, Game.Trailer, STUFF((SELECT DISTINCT ', ' + Genre.Name FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Genres, STUFF((SELECT DISTINCT ', ' + Feature.Name FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Features, STUFF((SELECT ',' + CAST(Genre.GenreID AS VARCHAR) FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS GenreIDs, STUFF((SELECT ',' + CAST(Feature.FeatureID AS VARCHAR) FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS FeatureIDs, (SELECT STUFF((SELECT ',' + CAST(GameImages.ImageID AS VARCHAR) FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageIDs, (SELECT STUFF((SELECT ',' + GameImages.ImageURL FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageURLs, (SELECT STUFF((SELECT ',' + GameImages.ImageType FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageTypes, (SELECT SpecificationID, SpecificationType, REPLACE(OS, CHAR(13) + CHAR(10), '') AS OS, REPLACE(Processor, CHAR(13) + CHAR(10), '') AS Processor, REPLACE(Memory, CHAR(13) + CHAR(10), '') AS Memory, REPLACE(Storage, CHAR(13) + CHAR(10), '') AS Storage, REPLACE(DirectX, CHAR(13) + CHAR(10), '') AS DirectX, REPLACE(Graphics, CHAR(13) + CHAR(10), '') AS Graphics, REPLACE(Other, CHAR(13) + CHAR(10), '') AS Other, REPLACE(Logins, CHAR(13) + CHAR(10), '') AS Logins FROM Specifications WHERE Specifications.GameID = Game.GameID FOR JSON AUTO) AS SpecificationsJson FROM Game LEFT JOIN GameGenre ON Game.GameID = GameGenre.GameID LEFT JOIN Genre ON GameGenre.GenreID = Genre.GenreID LEFT JOIN GameFeature ON Game.GameID = GameFeature.GameID LEFT JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID GROUP BY Game.GameID, Game.Title, Game.Price, Game.Description, Game.Release_date, Game.Publisher, Game.Trailer;";
            }
        }
        public List<Game> RetrieveData()
        {
            List<Game> games = new List<Game>();

            DataTable dt = base.ReadDataQuery(cmd);
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

        public Game GetGameById(int id)
        {
            string query = $@"SELECT Game.GameID, Game.Title, Game.Price, Game.Description, Game.Release_date, Game.Publisher, Game.Trailer, STUFF((SELECT DISTINCT ', ' + Genre.Name FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Genres, STUFF((SELECT DISTINCT ', ' + Feature.Name FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Features, STUFF((SELECT ',' + CAST(Genre.GenreID AS VARCHAR) FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS GenreIDs, STUFF((SELECT ',' + CAST(Feature.FeatureID AS VARCHAR) FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS FeatureIDs, (SELECT STUFF((SELECT ',' + CAST(GameImages.ImageID AS VARCHAR) FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageIDs, (SELECT STUFF((SELECT ',' + GameImages.ImageURL FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageURLs, (SELECT STUFF((SELECT ',' + GameImages.ImageType FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageTypes, (SELECT SpecificationID, SpecificationType, REPLACE(OS, CHAR(13) + CHAR(10), '') AS OS, REPLACE(Processor, CHAR(13) + CHAR(10), '') AS Processor, REPLACE(Memory, CHAR(13) + CHAR(10), '') AS Memory, REPLACE(Storage, CHAR(13) + CHAR(10), '') AS Storage, REPLACE(DirectX, CHAR(13) + CHAR(10), '') AS DirectX, REPLACE(Graphics, CHAR(13) + CHAR(10), '') AS Graphics, REPLACE(Other, CHAR(13) + CHAR(10), '') AS Other, REPLACE(Logins, CHAR(13) + CHAR(10), '') AS Logins FROM Specifications WHERE Specifications.GameID = Game.GameID FOR JSON AUTO) AS SpecificationsJson FROM Game LEFT JOIN GameGenre ON Game.GameID = GameGenre.GameID LEFT JOIN Genre ON GameGenre.GenreID = Genre.GenreID LEFT JOIN GameFeature ON Game.GameID = GameFeature.GameID LEFT JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE game.GameID = {id} GROUP BY Game.GameID, Game.Title, Game.Price, Game.Description, Game.Release_date, Game.Publisher, Game.Trailer;";
            DataTable dt = ReadDataQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return DataConvertingGames.ConvertDataRowToGame(row, this);
            }
            else { return null; }
        }

        public List <Game> SearchGames(string name)
        
        {
            string query = $@"SELECT Game.GameID, Game.Title, Game.Price, Game.Description, Game.Release_date, Game.Publisher, Game.Trailer, STUFF((SELECT DISTINCT ', ' + Genre.Name FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Genres, STUFF((SELECT DISTINCT ', ' + Feature.Name FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Features, STUFF((SELECT ',' + CAST(Genre.GenreID AS VARCHAR) FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS GenreIDs, STUFF((SELECT ',' + CAST(Feature.FeatureID AS VARCHAR) FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS FeatureIDs, (SELECT STUFF((SELECT ',' + CAST(GameImages.ImageID AS VARCHAR) FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageIDs, (SELECT STUFF((SELECT ',' + GameImages.ImageURL FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageURLs, (SELECT STUFF((SELECT ',' + GameImages.ImageType FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageTypes, (SELECT SpecificationID, SpecificationType, REPLACE(OS, CHAR(13) + CHAR(10), '') AS OS, REPLACE(Processor, CHAR(13) + CHAR(10), '') AS Processor, REPLACE(Memory, CHAR(13) + CHAR(10), '') AS Memory, REPLACE(Storage, CHAR(13) + CHAR(10), '') AS Storage, REPLACE(DirectX, CHAR(13) + CHAR(10), '') AS DirectX, REPLACE(Graphics, CHAR(13) + CHAR(10), '') AS Graphics, REPLACE(Other, CHAR(13) + CHAR(10), '') AS Other, REPLACE(Logins, CHAR(13) + CHAR(10), '') AS Logins FROM Specifications WHERE Specifications.GameID = Game.GameID FOR JSON AUTO) AS SpecificationsJson FROM Game LEFT JOIN GameGenre ON Game.GameID = GameGenre.GameID LEFT JOIN Genre ON GameGenre.GenreID = Genre.GenreID LEFT JOIN GameFeature ON Game.GameID = GameFeature.GameID LEFT JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE game.Title LIKE '%{name}%' GROUP BY Game.GameID, Game.Title, Game.Price, Game.Description, Game.Release_date, Game.Publisher, Game.Trailer;";
            
            List<Game> games = new List<Game>();
            
            DataTable dt = ReadDataQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                Game game = DataConvertingGames.ConvertDataRowToGame(dr, this);
                games.Add(game);

            }
            return games;
        }
    }
}
