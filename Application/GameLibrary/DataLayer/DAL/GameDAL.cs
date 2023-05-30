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
using static System.Net.Mime.MediaTypeNames;

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
            foreach (DataRow dr in dt.Rows)
            {
                Game game = DataConvertingGames.ConvertDataRowToGame(dr);
                games.Add(game);

            }
            return games;
        }

        public bool AddGame(Game game)
        {
            string query = $"INSERT INTO [Game](Title, Price, Description, Release_date, Publisher, Trailer) OUTPUT INSERTED.GameID " +
                    $"VALUES ('{game.Title}',{game.Price},'{game.Description}','{game.ReleaseDate}','{game.Publisher}','{game.Trailer}')";
            int gameID = executeIdScalar(query);
            if (gameID == 0)
            {
                return false;
            }
            foreach (Genre newGenre in game.Genres)
            {
                AddGenreToGame(gameID, newGenre);
            }
            foreach (Feature newFeature in game.Features)
            {
                AddFeatureToGame(gameID, newFeature);
            }
            foreach (GameImage image  in game.Images) 
            {
                AddImagesToGame(gameID, image);
            }
            foreach (Specification specification in game.Specifications)
            {
                AddSpecificationsToGame(gameID, specification);
            }

            return true;
        }

        public Game GetGameById(int id)
        {
            string query = $@"SELECT Game.GameID, Game.Title, Game.Price, Game.Description, Game.Release_date, Game.Publisher, Game.Trailer, STUFF((SELECT DISTINCT ', ' + Genre.Name FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Genres, STUFF((SELECT DISTINCT ', ' + Feature.Name FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Features, STUFF((SELECT ',' + CAST(Genre.GenreID AS VARCHAR) FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS GenreIDs, STUFF((SELECT ',' + CAST(Feature.FeatureID AS VARCHAR) FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS FeatureIDs, (SELECT STUFF((SELECT ',' + CAST(GameImages.ImageID AS VARCHAR) FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageIDs, (SELECT STUFF((SELECT ',' + GameImages.ImageURL FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageURLs, (SELECT STUFF((SELECT ',' + GameImages.ImageType FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageTypes, (SELECT SpecificationID, SpecificationType, REPLACE(OS, CHAR(13) + CHAR(10), '') AS OS, REPLACE(Processor, CHAR(13) + CHAR(10), '') AS Processor, REPLACE(Memory, CHAR(13) + CHAR(10), '') AS Memory, REPLACE(Storage, CHAR(13) + CHAR(10), '') AS Storage, REPLACE(DirectX, CHAR(13) + CHAR(10), '') AS DirectX, REPLACE(Graphics, CHAR(13) + CHAR(10), '') AS Graphics, REPLACE(Other, CHAR(13) + CHAR(10), '') AS Other, REPLACE(Logins, CHAR(13) + CHAR(10), '') AS Logins FROM Specifications WHERE Specifications.GameID = Game.GameID FOR JSON AUTO) AS SpecificationsJson FROM Game LEFT JOIN GameGenre ON Game.GameID = GameGenre.GameID LEFT JOIN Genre ON GameGenre.GenreID = Genre.GenreID LEFT JOIN GameFeature ON Game.GameID = GameFeature.GameID LEFT JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE game.GameID = {id} GROUP BY Game.GameID, Game.Title, Game.Price, Game.Description, Game.Release_date, Game.Publisher, Game.Trailer;";
            DataTable dt = ReadDataQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return DataConvertingGames.ConvertDataRowToGame(row);
            }
            else { return null; }
        }

        public bool UpdateGame(Game game)
        {
            string query = $@"UPDATE Game SET Title='{game.Title}', Price={game.Price}, Description='{game.Description}', Release_date='{game.ReleaseDate}', Publisher='{game.Publisher}', Trailer='{game.Trailer}' WHERE GameID={game.GameId}";

            int queryresult = executeQuery(query);

            if (queryresult == 0)
            {
                return false;
            }
            
            List<Genre> currentGenres = GetCurrentGenres(game.GameId);
            List<Genre> newGenres = new List<Genre>();
            foreach (var genre in game.Genres)
            {
                newGenres.Add(genre);
            }
            foreach (Genre currentGenre in currentGenres)
            {
                RemoveGenreFromGame(game.GameId, currentGenre);
            }
            foreach (Genre newGenre in newGenres)
            { 
                AddGenreToGame(game.GameId, newGenre);
            }


            List<Feature> currentFeatures = GetCurrentFeatures(game.GameId);
            List<Feature> newFeatures = new List<Feature>();
            foreach (var feature in game.Features)
            {
                newFeatures.Add(feature);
            }
            foreach (Feature currentFeature in currentFeatures)
            {
                RemoveFeatureFromGame(game.GameId, currentFeature);
            }
            foreach (Feature newFeature in newFeatures)
            {
                AddFeatureToGame(game.GameId, newFeature);
            }

            List<Specification> NewSpecifications = game.Specifications;
            foreach (Specification specification in NewSpecifications)
            {
                UpdateSpecifications(specification);
            }

            List<GameImage> currentImages = GetCurrentImages(game.GameId);
            List<GameImage> newGameImages = game.Images;

            foreach (GameImage currentImage in currentImages)
            {
                if (!newGameImages.Any(ni => ni.ImageId == currentImage.ImageId))
                {
                    DeleteImages( game.GameId, currentImage);
                }
            }

            foreach (GameImage image in newGameImages)
            {
               if (!currentImages.Any(ci => ci.ImageId == image.ImageId))
               {
                    AddImagesToGame(game.GameId, image );
               }

               else 
               {
                  UpdateImages(image);
               }
                
            }
           

            return true;



        }
    


        public List<Game> SearchGames(string name)

        {
            string query = $@"SELECT Game.GameID, Game.Title, Game.Price, Game.Description, Game.Release_date, Game.Publisher, Game.Trailer, STUFF((SELECT DISTINCT ', ' + Genre.Name FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Genres, STUFF((SELECT DISTINCT ', ' + Feature.Name FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 2, '') AS Features, STUFF((SELECT ',' + CAST(Genre.GenreID AS VARCHAR) FROM GameGenre INNER JOIN Genre ON GameGenre.GenreID = Genre.GenreID WHERE GameGenre.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS GenreIDs, STUFF((SELECT ',' + CAST(Feature.FeatureID AS VARCHAR) FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameFeature.GameID = Game.GameID FOR XML PATH('')), 1, 1, '') AS FeatureIDs, (SELECT STUFF((SELECT ',' + CAST(GameImages.ImageID AS VARCHAR) FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageIDs, (SELECT STUFF((SELECT ',' + GameImages.ImageURL FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageURLs, (SELECT STUFF((SELECT ',' + GameImages.ImageType FROM GameImages WHERE GameImages.GameID = Game.GameID FOR XML PATH('')), 1, 1, '')) AS ImageTypes, (SELECT SpecificationID, SpecificationType, REPLACE(OS, CHAR(13) + CHAR(10), '') AS OS, REPLACE(Processor, CHAR(13) + CHAR(10), '') AS Processor, REPLACE(Memory, CHAR(13) + CHAR(10), '') AS Memory, REPLACE(Storage, CHAR(13) + CHAR(10), '') AS Storage, REPLACE(DirectX, CHAR(13) + CHAR(10), '') AS DirectX, REPLACE(Graphics, CHAR(13) + CHAR(10), '') AS Graphics, REPLACE(Other, CHAR(13) + CHAR(10), '') AS Other, REPLACE(Logins, CHAR(13) + CHAR(10), '') AS Logins FROM Specifications WHERE Specifications.GameID = Game.GameID FOR JSON AUTO) AS SpecificationsJson FROM Game LEFT JOIN GameGenre ON Game.GameID = GameGenre.GameID LEFT JOIN Genre ON GameGenre.GenreID = Genre.GenreID LEFT JOIN GameFeature ON Game.GameID = GameFeature.GameID LEFT JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE game.Title LIKE '%{name}%' GROUP BY Game.GameID, Game.Title, Game.Price, Game.Description, Game.Release_date, Game.Publisher, Game.Trailer;";

            List<Game> games = new List<Game>();

            DataTable dt = ReadDataQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                Game game = DataConvertingGames.ConvertDataRowToGame(dr);
                games.Add(game);

            }
            return games;
        }

        public List<Genre> GetAllGenres()
        {
            string query = $@"Select GenreID AS GenreIDs, Name AS Genres FROM Genre";

            List<Genre> genres = new List<Genre>();

            DataTable dt = ReadDataQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                List<Genre> genresFromRow = DataConvertingGenre.ConvertDataRowToGenres(dr);
                genres.AddRange(genresFromRow);
            }

            return genres;
        }

        private List<Genre> GetCurrentGenres(int id)
        {
            string query = $@"Select GameGenre.GenreID AS GenreIDs, Genre.Name AS Genres FROM GameGenre INNER JOIN GENRE ON GameGenre.GenreID = Genre.GenreID WHERE GameID = {id};";

            List<Genre> genres = new List<Genre>();

            DataTable dt = ReadDataQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                List<Genre> genresFromRow = DataConvertingGenre.ConvertDataRowToGenres(dr);
                genres.AddRange(genresFromRow);
            }
            return genres;
        }

        private bool AddGenreToGame(int id, Genre genre )
        {
            string queryAddNewGenre = $"INSERT INTO [GameGenre](GameID, GenreID)" +
                        $"VALUES ({id}, {genre.GenreId}) ";
            int addGenreResult = executeQuery(queryAddNewGenre);
            if (addGenreResult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private bool RemoveGenreFromGame(int id, Genre genre)
        {
            string queryRemoveGenre = $"DELETE FROM GameGenre WHERE GameID = {id} AND GenreID = {genre.GenreId}";
            int removeGenreResult = executeQuery(queryRemoveGenre);
            if (removeGenreResult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public List<Feature> GetAllFeatures()
        {
            string query = $@"Select FeatureID AS FeatureIDs, Name AS Features FROM Feature";

            List<Feature> features = new List<Feature>();

            DataTable dt = ReadDataQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                List<Feature> featuresFromRow = DataConvertingFeatures.ConvertDataRowToFeatures(dr);
                features.AddRange(featuresFromRow);
            }
            return features;
        }

        private List<Feature> GetCurrentFeatures(int id)
        {
            string query = $@"Select GameFeature.FeatureID AS FeatureIDs, Feature.Name AS Features FROM GameFeature INNER JOIN Feature ON GameFeature.FeatureID = Feature.FeatureID WHERE GameID = {id};";

            List<Feature> features = new List<Feature>();

            DataTable dt = ReadDataQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                List<Feature> featureFromRow = DataConvertingFeatures.ConvertDataRowToFeatures(dr);
                features.AddRange(featureFromRow);
            }
            return features;
        }

        private bool RemoveFeatureFromGame(int id, Feature feature)
        {
            string queryRemoveFeature = $"DELETE FROM GameFeature WHERE GameID = {id} AND FeatureID = {feature.FeatureID}";
            int removeFeatureResult = executeQuery(queryRemoveFeature);
            if (removeFeatureResult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool AddFeatureToGame(int id, Feature feature)
        {
            string queryAddNewFeature = $"INSERT INTO [GameFeature](GameID, FeatureID)" +
                        $"VALUES ({id}, {feature.FeatureID}) ";
            int addFeatureResult = executeQuery(queryAddNewFeature);
            if (addFeatureResult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool UpdateSpecifications (Specification specification)
        {
            string query = $@"Update Specifications SET OS='{specification.OS}', Processor='{specification.Processor}', Memory='{specification.Memory}', Storage= '{specification.Storage}', DirectX= '{specification.DirectX}', Graphics='{specification.Graphics}', Other='{specification.Other}', Logins='{specification.Logins}' WHERE SpecificationID= '{specification.SpecificationID}'";
            int queryresult = executeQuery(query);

            if (queryresult == 0)
            {
                return false;
            }
            return true;
        }

        private bool AddSpecificationsToGame(int id ,Specification specification)
        {
            string query = $@"Insert INTO [Specifications] (GameID, SpecificationType, OS, Processor, Memory, Storage, DirectX, Graphics, Other, Logins)" +
                $"VALUES ({id}, '{specification.SpecificationType}','{specification.OS}', '{specification.Processor}','{specification.Memory}','{specification.Storage}','{specification.DirectX}','{specification.Graphics}','{specification.Other}','{specification.Logins}')";
            int queryresult = executeQuery(query);

            if (queryresult == 0)
            {
                return false;
            }
            return true;
        }

        private bool UpdateImages(GameImage images)
        {
            string query = $@"Update GameImages SET ImageType= '{images.ImageType}', ImageURL='{images.ImageURL}' WHERE ImageID = {images.ImageId}";
            int queryresult = executeQuery(query);

            if (queryresult == 0)
            {
                return false;
            }
            return true;
        }

        private bool AddImagesToGame(int id, GameImage images)
        {
            string query = $@"INSERT INTO [GameImages](GameID, ImageType, ImageURL)" +
                    $"VALUES ({id},'{images.ImageType}','{images.ImageURL}')";
            int queryResult = executeQuery(query);
            if (queryResult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool DeleteImages (int id, GameImage images)
        {
            string query = $"DELETE FROM GameImages WHERE GameID = {id} AND ImageID = {images.ImageId}";
            int queryResult = executeQuery(query);
            if (queryResult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private List <GameImage> GetCurrentImages (int id)
        {
            string query = $@"Select GameImages.ImageID AS ImageIDs, GameImages.ImageType AS ImageTypes, GameImages.ImageURL AS ImageURLs FROM GameImages WHERE GameID = {id};";

            List<GameImage> images = new List<GameImage>();

            DataTable dt = ReadDataQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                List<GameImage> imageFromRow = DataConvertingImages.ConvertDataToImage(dr);
                images.AddRange(imageFromRow);
            }
            return images;
        }
    }
}
