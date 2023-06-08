using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Result : Exception
    {
        public Result(string message) : base(message)
        {

        }


        public bool ValidateFields(string title, string price, string description, string publisher, string releasDate, string trailer, string genre1, string genre2, string feature1, string feature2, string coverart, string spotlight, string thumbnail)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ValidationException("Please enter a title.");
            }
            if (string.IsNullOrEmpty(price))
            {
                throw new ValidationException("Please enter a price.");
            }
            if (!decimal.TryParse(price, out decimal parsedPrice))
            {
                throw new ValidationException("Please enter a numeric price.");
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ValidationException("Please enter a description.");
            }
            if (string.IsNullOrEmpty(releasDate))
            {
                throw new ValidationException("Please enter a release date");
            }
            DateTime parsedDate;
            if (!DateTime.TryParseExact(releasDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                throw new ValidationException("Release date format is not correct. Please enter in 'yyyy-MM-dd' format.");
            }
            if (string.IsNullOrEmpty(publisher))
            {
                throw new ValidationException("Please enter a publisher");
            }
            if (string.IsNullOrEmpty(trailer))
            {
                throw new ValidationException("Please enter a trailer URL");
            }
            if (string.IsNullOrEmpty(genre1) && string.IsNullOrEmpty(genre2))
            {
                throw new ValidationException("Please enter atleast 2 genres");
            }
            if (string.IsNullOrEmpty(feature1) && string.IsNullOrEmpty(feature2))
            {
                throw new ValidationException("Please enter atleast 2 Features");
            }
            if (string.IsNullOrEmpty(coverart))
            {
                throw new ValidationException("Please enter a CoverArt Image");
            }
            if (!coverart.Contains("\\Images\\") || !coverart.Contains(".png"))
            {
                throw new ValidationException("'\\Images\\' and '.png' should be included.");
            }
            if (string.IsNullOrEmpty(spotlight))
            {
                throw new ValidationException("Please enter a spotlight Image");
            }
            if (!spotlight.Contains("\\Images\\") || !spotlight.Contains(".png"))
            {
                throw new ValidationException("'\\Images\\' and '.png' should be included.");
            }
            if (string.IsNullOrEmpty(thumbnail))
            {
                throw new ValidationException("Please enter a thumbnail Image");
            }
            if (!thumbnail.Contains("\\Images\\") || !thumbnail.Contains(".png"))
            {
                throw new ValidationException("'\\Images\\' and '.png' should be included.");
            }
            return true;
        }

        public bool validateDetailImage(string detail)
        {
            if (string.IsNullOrEmpty(detail))
            {
                throw new ValidationException("Please enter a detail Image");
            }
            if (!detail.Contains("\\Images\\") || !detail.Contains(".png"))
            {
                throw new ValidationException("'\\Images\\' and '.png' should be included.");
            }
            return true;
        }


        public bool ValidateRegisterFields(string firstName, string lastName, string email, string birthdate, string phone, string country, string city, string txt_address, string password)
        {

            if (string.IsNullOrEmpty(firstName))
            {
                throw new ValidationException("Please enter a First Name.");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ValidationException("Please enter a Last Name.");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ValidationException("Please enter an Email.");
            }

            if (!email.Contains("@"))
            {
                throw new ValidationException("Invalid email address.");
            }

            if (string.IsNullOrEmpty(birthdate))
            {
                throw new ValidationException("Please enter a birthdate.");
            }

            if (string.IsNullOrEmpty(phone))
            {
                throw new ValidationException("Please enter a Phone number.");
            }

            if (string.IsNullOrEmpty(country))
            {
                throw new ValidationException("Please enter a Country.");
            }

            if (string.IsNullOrEmpty(city))
            {
                throw new ValidationException("Please enter a City.");
            }

            if (string.IsNullOrEmpty(txt_address))
            {
                throw new ValidationException("Please enter an Address.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ValidationException("Please enter a Password.");
            }
            return true;

        }
    }
}
