using DataLayer.DAL;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class UserService
	{
		private readonly IUserDAL dal;
		public List<User> user = new List<User>();

		public UserService(IUserDAL dal)
		{
			this.dal = dal;
		}

		public List<User> GetUsers()
		{
			return dal.retrieveUsers();
			
		}

		public bool RegisterUser(User user)
		{
			
			return dal.RegisterUser(user);
		}

        public User GetUserById(int id)
        {
            // Retrieve the user from the database using the provided ID
            var user = dal.retrieveUsers().FirstOrDefault(u => u.Id == id);

            return user;
        }

    } 
}
