using DataLayer.DAL;
using LogicLayer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
	public class Login
	{
		private readonly IUserDAL dalUser;

		public Login(IUserDAL dalUser)
		{
			this.dalUser = dalUser;
		}

		public User validateUserCredentials(string email, string password)
		{
			List<User> users = new List<User>();
			users.AddRange((dalUser.retrieveUsers()));
			User? foundUser = null;
			User? user = null;
			foreach (User u in users)
			{
				if (u.Email == email && u.password == password)
				{
					user = u;
				}
			}
			if (user != null)
			{
				if (user.Role == 1)
				{
					foundUser = new Costumer(user.Id, user.Firstname, user.Lastname, user.DisplayName, user.Birthdate, user.Phone, user.Country, user.Address, user.City, user.ImageUrl, user.Role, user.Email, user.password, user.salt);
				}
			}
			return foundUser!;
		}
	}
}
