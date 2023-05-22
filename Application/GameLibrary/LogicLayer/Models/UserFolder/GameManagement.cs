using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.UserFolder
{
    public class GameManagement : User
    {
        UserService _userService;

        public GameManagement(int id, string firstName, string lastName, string displayName, string email, string birthdate, string phone, string country, string city, string address, string imageURL, string password, string username, int role) : base(id, firstName, lastName, displayName,  email,  birthdate,  phone,  country,  city,  address,  imageURL,  password,  username,  role)
        {
            this.Id = id;
            this.Firstname = firstName;
            this.Lastname = lastName;
            this.DisplayName = displayName;
            this.Email = email;
            this.Birthdate = birthdate;
            this.Phone = phone;
            this.Country = country;
            this.City = city;
            this.Address = address;
            this.ImageUrl = imageURL;
            this.password = password;
            this.username = username;
            this.Role = role;
        }

    }
}
