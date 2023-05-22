using DataLayer.DAL;
using LogicLayer.Models.UserFolder;
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

namespace LogicLayer.Models
{
    public class Costumer : User
    {
        UserService _userService;


        public Costumer(int id, string firstName, string lastName, string displayName, string birthdate, string phone, string country, string address, string city, string imageURL, int role, string email, string password, string salt, string username) : base(id, firstName, lastName, displayName, birthdate, phone, country, address, city, imageURL, role, email, password, salt, username)
        {

        }
        public Costumer(int id, string firstName, string lastName, string displayName, string email, string country, string address, string city, string password) : base(id, firstName, lastName, displayName, email, country, address, city, password)
        {
            Id = id;
            Firstname = firstName;
            Lastname = lastName;
            DisplayName = displayName;
            Email = email;
            Country = country;
            Address = address;
            City = city;
            this.password = password;
        }
        public bool RegisterNewCostumer(User user)
        {
            return _userService.RegisterUser(user);
        }

    }
}
