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
        public string Requirements { get; set; }
        public string ReleaseDate { get; set; }
        public List <GameImage> Images { get; set; }
        public List <Genre> Genres { get; set; }
        public List <Feature> Features { get; set; }
        public string Trailer { get; set; }


        public Game(int gameId, string title, decimal price, string description, string requirements, string releasDate, List<GameImage> images, List<Genre> genres, List<Feature> features, string trailer)
        {
            this.GameId = gameId;
            this.Title = title;
            this.Price = price;
            this.Description = description;
            this.Requirements = requirements;
            this.ReleaseDate = releasDate;
            this.Images = images;
            this.Genres = genres;
            this.Features = features;
            this.Trailer = trailer;  
        }
    }


}
