﻿using DataLayer.Connection;
using DataLayer.Converting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using LogicLayer.Verify;
using LogicLayer.Models.UserFolder;

namespace DataLayer.DAL
{
    public class UserDAL : Datahandler, IUserDAL
	{
		protected override string cmd
		{
			get
			{
				return "SELECT [User].id,[firstname],[lastname],[displayname],[email],[birthday],[phone],[country],[address],[city],[imageUrl],[Roles].role as RoleID, [Account_Credentials].passwordhash, [Account_Credentials].salt, [Account_Credentials].username FROM[User] INNER JOIN Account_Credentials ON[User].id = Account_Credentials.userId INNER JOIN Roles ON[User].id = roles.userId";
			}
		}

		public List<User> retrieveUsers()
		{
			List<User> users = new List<User>();

			DataTable dt = base.ReadDataQuery(cmd);

			foreach (DataRow dr in dt.Rows)
			{
				int roleId = Convert.ToInt32(dr["RoleID"]);
				User user;
				if (roleId == 1)
				{
					user = ConvertDataCustomer.ConvertDataRowToCustomer(dr);
					users.Add(user);
				}
				else if (roleId == 2)
				{
                    user = ConvertDataCustomer.ConvertDataRowToCustomer(dr);
					users.Add(user);
                }
				else
				{
					throw new Exception($"Unknown role ID {roleId} for user with ID {dr["id"]}");
				}
			}
			return users;
		}

		public bool RegisterUser(User user)
		{
            string query = $"INSERT INTO [User] (firstname, lastname, displayname, email, birthday ,phone ,country, address, city, imageUrl) OUTPUT INSERTED.id " +
			  $"VALUES ('{user.Firstname}','{user.Lastname}', '{user.DisplayName}', '{user.Email}','{user.Birthdate}','{user.Phone}','{user.Country}','{user.Address}','{user.City}', 'Null');";

			int userId = executeIdScalar(query);

			if (userId == 0)
			{
				return false;
			}

            string rolesQuery = "";

            if (user.Role == 1)
            {
                rolesQuery = $"INSERT INTO [Roles](userid, role, name)" +
                    $"VALUES ({userId},1,'Customer');";
            }
            else if (user.Role == 2)
            {
                rolesQuery = $"INSERT INTO [Roles](userid, role, name)" +
                    $"VALUES ({userId},2,'Employee');";
            }

            int Queryresult = executeQuery(rolesQuery);



			if (Queryresult == 0)
			{
				string rollbackQuery = $"DELETE FROM [User] WHERE id = {userId};";
				executeQuery(rollbackQuery);
				return false;
			}

			(string Salt, string HashedPassword) output = Security.CreateSaltAndHash(user.password);

			string accountQuery = $"INSERT INTO [Account_Credentials](userid, passwordhash, salt, username)" +
				$"VALUES ({userId}, '{output.HashedPassword}', '{output.Salt}', '{user.Email}')";
			return executeQuery(accountQuery) == 0 ? false : true;
		}
	}
}