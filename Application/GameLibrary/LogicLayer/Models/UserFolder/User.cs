using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.UserFolder
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DisplayName { get; set; }
        public string Birthdate { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string username { get; set; }


        protected User(int id, string firstName, string lastName, string displayName, string birthdate, string phone, string country, string address, string city, string imageURL, int role, string email, string password, string salt, string username)
        {
            Id = id;
            Firstname = firstName;
            Lastname = lastName;
            DisplayName = displayName;
            Birthdate = birthdate;
            Phone = phone;
            Country = country;
            Address = address;
            City = city;
            ImageUrl = imageURL;
            Role = role;
            Email = email;
            this.password = password;
            this.salt = salt;
            this.username = username;
        }

        protected User(int id, string firstName, string lastName, string displayName, string email, string country, string city, string address, string password)
        {
            Id = id;
            Firstname = firstName;
            Lastname = lastName;
            DisplayName = displayName;
            Email = email;
            Country = country;
            City = city;
            Address = address;
            this.password = password;
        }
    }


}

