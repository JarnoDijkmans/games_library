using DataLayer.Connection;
using DataLayer.Converting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Users;
using System.Reflection;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace DataLayer.DAL
{
	public class UserDAL : Datahandler, IUserDAL
	{
		protected override string cmd
		{
			get
			{
				return "SELECT [User].id,[firstname],[lastname],[displayname],[email],[birthday],[phone],[country],[address],[city],[imageUrl],[Roles].role as RoleID, [Account_Credentials].passwordhash, [Account_Credentials].salt FROM[User] INNER JOIN Account_Credentials ON[User].id = Account_Credentials.userId INNER JOIN Roles ON[User].id = roles.UserId";
			}
		}

		public List<User> retrieveUsers()
		{
			List<User> users = new List<User>();

			DataTable dt = base.ReadData();

			foreach (DataRow dr in dt.Rows)
			{
				int roleId = Convert.ToInt32(dr["RoleID"]);
				User user;
				if (roleId == 1)
				{
					user = ConvertDataCustomer.ConvertDataRowToCustomer(dr);
					users.Add(user);
				}
				//else if (roleId == 2)
				//{
				//    //user = ConvertDataEmployee.ConvertDataRowToEmployee(dr);
				//}
				else
				{
					throw new Exception($"Unknown role ID {roleId} for user with ID {dr["id"]}");
				}
			}
			return users;
		}

		public bool RegisterUser(User user)
		{
			string query = "INSERT INTO[User](firstname, lastname, displayname, email, birthday, phone, country, address, city, imageUrl)" +
			$"Values ('{user.Firstname}','{user.Lastname}', '{user.DisplayName}', '{user.Email}', '{user.Birthdate}', '{user.Phone}','{user.Country}','{user.Address}', '{user.City}', '{user.ImageUrl}');";
			return executeQuery(query) == 0 ? false : true;
		}
	}
}