using DataLayer.DAL;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.UserFolder
{
    public class Costumer : User
    {
        UserService _userService;


        public Costumer(int id, string firstName, string lastName, string displayName, string birthdate, string phone, string country, string address, string city, string imageURL, int role, string email, string password, string salt, string username) : base(id, firstName, lastName, displayName, birthdate, phone, country, address, city, imageURL, role, email, password, salt, username)
        {

        }
        public Costumer(int id, string firstName, string lastName, string displayName, string email, string birthdate, string phone, string country, string city, string address, string imageURL, string password, string username, int role) : base(id, firstName, lastName, displayName, email, birthdate, phone, country, city, address, imageURL, password, username, role)
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
        public bool RegisterNewCostumer(User user)
        {
            return _userService.RegisterUser(user);
        }

    }
}
