using DataLayer.DAL;
using LogicLayer.Models;
using LogicLayer.Models.GamesFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataLayer.Converting
{
    public static class DataConvertingGames 
    {
        public static Game ConvertDataRowToGame(DataRow row, GameDAL gameDal)
        {
            int GameId = Convert.ToInt32(row["GameID"]);
            string Title = Convert.ToString(row["Title"])!;
            decimal Price = Convert.ToDecimal(row["Price"])!;
            string Description = Convert.ToString(row["Description"])!;
            string Requirements = Convert.ToString(row["Requirements"])!;
            string ReleaseDate = Convert.ToString(row["Release_date"])!;
            string Trailer = Convert.ToString(row["Trailer"])!;

            List<Genre> genres = new List<Genre>();
            DataTable genreTable = gameDal.ReadData();
            foreach (DataRow genreRow in genreTable.Rows)
            {
                int genreGameId = Convert.ToInt32(genreRow["GameID"]);
                if (genreGameId == GameId) 
                {
                    List<Genre> genreList = ConvertDataRowToGenres(genreRow);
                    genres.AddRange(genreList);
                }
            }

            List<Feature> features = new List<Feature>();
            DataTable featureTable = gameDal.ReadData();

            foreach (DataRow featureRow in featureTable.Rows)
            {
                int featureGameId = Convert.ToInt32(featureRow["GameID"]);
                if (featureGameId == GameId)
                {
                    List<Feature> featureList = ConvertDataRowToFeatures(featureRow);
                    features.AddRange(featureList);
                }
                
            }

            List<GameImage> gameImages = new List<GameImage>();
            DataTable gameImageTable = gameDal.ReadData();

            foreach (DataRow GameImageRow in gameImageTable.Rows)
            {
                int imageGameId = Convert.ToInt32(GameImageRow["GameID"]);
                if (imageGameId == GameId)
                {
                    List<GameImage> gameImage = ConvertDataToImage(GameImageRow);
                    gameImages.AddRange(gameImage);
                }
               
            }


            Game game = new Game(GameId, Title, Price, Description, Requirements, ReleaseDate, gameImages, genres, features, Trailer);
            return game;
        }


        public static List <GameImage> ConvertDataToImage (DataRow row)
        {
            string ImageIds = Convert.ToString(row["ImageIDs"])!;
            string ImageTypes = Convert.ToString(row["ImageTypes"])!;
            string ImageURLs = Convert.ToString(row["ImageURLs"])!;

            List <GameImage> gameImages = new List<GameImage>();

            if (!string.IsNullOrEmpty(ImageIds))
            {
                string[] genreIdArray = ImageIds.Split(',');
                string[] ImageTypesArray = ImageTypes.Split(',');
                string[] ImageURLsArray = ImageURLs.Split(',');

                for (int i = 0; i < genreIdArray.Length; i++)
                {
                    if (int.TryParse(genreIdArray[i].Trim(), out int imageId))
                    {
                        string imageType = ImageTypesArray.Length > i ? ImageTypesArray[i].Trim() : "";
                        string imageURL = ImageURLsArray.Length > i ? ImageURLsArray[i].Trim() : "";
                        GameImage image = new GameImage(imageId, imageType, imageURL);
                        gameImages.Add(image);
                    }
                }
            }
            return gameImages;
        }


        public static List<Genre> ConvertDataRowToGenres(DataRow row)
        {
            string genreIds = Convert.ToString(row["GenreIDs"])!;
            string name = Convert.ToString(row["Genres"])!;

            List<Genre> genres = new List<Genre>();

            if (!string.IsNullOrEmpty(genreIds))
            {
                string[] genreIdArray = genreIds.Split(',');
                string[] genreNameArray = name.Split(',');

                for (int i = 0; i < genreIdArray.Length; i++)
                {
                    if (int.TryParse(genreIdArray[i].Trim(), out int genreId))
                    {
                        string genreName = genreNameArray.Length > i ? genreNameArray[i].Trim() : "";
                        Genre genre = new Genre(genreId, genreName);
                        genres.Add(genre);
                    }
                }
            }
            return genres;
        }


        public static List<Feature> ConvertDataRowToFeatures(DataRow row)
        {
            string featureIds = Convert.ToString(row["FeatureIDs"])!;
            string name = Convert.ToString(row["Features"])!;

            List<Feature> features = new List<Feature>();

            if (!string.IsNullOrEmpty(featureIds))
            {
                string[] featureIdArray = featureIds.Split(',');
                string[] featureNameArray = name.Split(',');

                for (int i = 0; i < featureIdArray.Length; i++)
                {
                    if (int.TryParse(featureIdArray[i].Trim(), out int featureId))
                    {
                        string featureName = featureNameArray.Length > i ? featureNameArray[i].Trim() : "";
                        Feature feature = new Feature(featureId, featureName);
                        features.Add(feature);
                    }
                }
            }

            return features;
        }
    }
}
