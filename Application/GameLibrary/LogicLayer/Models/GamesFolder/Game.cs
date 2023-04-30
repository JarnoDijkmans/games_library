using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.GamesFolder
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public List <GameImage> Images { get; set; }
        public List <Genre> Genres { get; set; }
        public List <Feature> Features { get; set; }
        public List <Specification> Specifications { get; set; }
        public string Trailer { get; set; }


        public Game(int gameId, string title, decimal price, string description, string releasDate, string publisher, List<GameImage> images, List<Genre> genres, List<Feature> features, List<Specification> specifications, string trailer)
        {
            this.GameId = gameId;
            this.Title = title;
            this.Price = price;
            this.Description = description;
            this.ReleaseDate = releasDate;
            this.Publisher = publisher;
            this.Images = images;
            this.Genres = genres;
            this.Features = features;
            this.Specifications = specifications;
            this.Trailer = trailer;  
        }
    }


}
