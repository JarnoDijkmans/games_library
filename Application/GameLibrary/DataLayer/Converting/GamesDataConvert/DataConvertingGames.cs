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

namespace DataLayer.Converting.GamesDataConvert
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
                    List<Genre> genreList = DataConvertingGenre.ConvertDataRowToGenres(genreRow);
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
                    List<Feature> featureList = DataConvertingFeatures.ConvertDataRowToFeatures(featureRow);
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
                    List<GameImage> gameImage = DataConvertingImages.ConvertDataToImage(GameImageRow);
                    gameImages.AddRange(gameImage);
                }

            }


            Game game = new Game(GameId, Title, Price, Description, Requirements, ReleaseDate, gameImages, genres, features, Trailer);
            return game;
        }
    }
}
