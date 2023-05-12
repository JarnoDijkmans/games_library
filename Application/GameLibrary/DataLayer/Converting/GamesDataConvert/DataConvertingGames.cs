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

            List<Genre> genres = DataConvertingGenre.ConvertDataRowToGenres(row);
            List<Feature> features = DataConvertingFeatures.ConvertDataRowToFeatures(row);
            List<GameImage> gameImages = DataConvertingImages.ConvertDataToImage(row);
            List<Specification> specifications = DataConvertingSpecifications.ConvertDataToSpecification(row);

            Game game = new Game(GameId, Title, Price, Description, ReleaseDate, Publisher, gameImages, genres, features, specifications, Trailer);
            return game;

        }
    }
}
