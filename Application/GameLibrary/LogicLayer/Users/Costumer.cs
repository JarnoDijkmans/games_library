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

namespace LogicLayer.Users
{
	public class Costumer : User
	{
		UserService _userService;
		public Costumer(int id, string firstName, string lastName, string displayName, string birthdate, string phone,string country, string address, string city, string imageURL, int role, string email, string password, string salt) : base(id, firstName, lastName, displayName, birthdate, phone, country, address, city, imageURL, role, email, password, salt)
		{
		}
		public Costumer(int id, string firstName, string lastName, string displayName, string country, string address, string city, string email, string password) : base(id, firstName, lastName, displayName, country, address, city, email, password)
		{
			this.Id = id;
			this.Firstname= firstName;
			this.Lastname= lastName;
			this.DisplayName= displayName;
			this.Country= country;
			this.Address= address;
			this.City = city;
			this.Email= email;
			this.password= password;
		}
	public bool RegisterNewCostumer(User user)
	{
		return _userService.RegisterUser(user);
	}

	}
}
