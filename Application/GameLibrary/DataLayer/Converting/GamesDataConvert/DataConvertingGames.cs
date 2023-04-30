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
            string ReleaseDate = Convert.ToString(row["Release_date"])!;
            string Publisher = Convert.ToString(row["Publisher"])!;
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

            List <Specification> specifications = new List<Specification>();
            DataTable specificationTable = gameDal.ReadData();

            foreach (DataRow SpecificationRow in specificationTable.Rows)
            {
                int specificationGameId = Convert.ToInt32(SpecificationRow["GameID"]);
                if (specificationGameId == GameId) 
                {
                    List<Specification> specification = DataConvertingSpecifications.ConvertDataToSpecification(SpecificationRow);
                    specifications.AddRange(specification);
                }
            }


            Game game = new Game(GameId, Title, Price, Description, ReleaseDate, Publisher, gameImages, genres, features, specifications, Trailer);
            return game;
        }
    }
}
