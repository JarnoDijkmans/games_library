using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.GamesFolder
{
    public class Game
    {
        public int GameId { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public string ReleaseDate { get; private set; }
        public string Publisher { get; private set; }
        public List <GameImage> Images { get; private set; }
        public List <Genre> Genres { get; private set; }
        public List <Feature> Features { get; private set; }
        public List <Specification> Specifications { get; private set; }
        public string Trailer { get; private set; }



        public Specification? MinimumSpecs ()
        {
            return Specifications.FirstOrDefault(s => s.SpecificationType == "Minimum");
        }

        public Specification? RecommendedSpecs ()
        {
            return Specifications.FirstOrDefault(s => s.SpecificationType == "Recommended");
        }
        public Game(int gameId, string title, decimal price, string description, string releasDate, string publisher, List<GameImage> images, List<Genre> genres, List<Feature> features, List<Specification> specifications, string trailer)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException($"{nameof(title)} may not be empty");
            if (price == null) throw new ArgumentException($"{nameof(price)} must be greater than zero");
            if (description == null) throw new ArgumentException($"{nameof(title)} may not be empty");
            DateTime parsedDate;
            if (!DateTime.TryParseExact(releasDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                throw new ValidationException("Release date format is not correct. Please enter in 'yyyy-MM-dd' format.");
            }
            if (string.IsNullOrWhiteSpace(publisher)) throw new ArgumentException($"{nameof(publisher)} may not be empty");
            if (string.IsNullOrWhiteSpace(trailer)) throw new ArgumentException($"{nameof(trailer)} may not be empty");
            //if (!images.All(image => image.ImageURL.StartsWith("/Images/") && image.ImageURL.EndsWith(".png")))
            //{
            //    throw new ArgumentException("All images must start with '/Images/' and end with '.png'");
            //}

            this.GameId = gameId;
            this.Title = title;
            this.Price = price;
            this.Description = description;
            this.ReleaseDate = releasDate;
            this.Publisher = publisher;
            this.Images = images ?? new List<GameImage>();
            this.Genres = genres ?? new List<Genre>();
            this.Features = features ?? new List<Feature>();
            this.Specifications = specifications ?? new List<Specification>();
            this.Trailer = trailer;
        }

        public Game()
        {

        }
    }


}
