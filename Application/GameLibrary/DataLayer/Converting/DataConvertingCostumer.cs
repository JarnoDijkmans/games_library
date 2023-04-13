using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models;

namespace DataLayer.Converting
{
    public static class ConvertDataCustomer
	{
		public static Costumer ConvertDataRowToCustomer(DataRow row)
		{
			int id = Convert.ToInt32(row["id"]);
			string firstName = Convert.ToString(row["firstname"])!;
			string lastName = Convert.ToString(row["lastname"])!;
			string displayName = Convert.ToString(row["displayname"])!;
			string birthday = Convert.ToString(row["birthday"])!;
			string phone = Convert.ToString(row["phone"])!;
			string country = Convert.ToString(row["country"])!;
			string address = Convert.ToString(row["address"])!;
			string city = Convert.ToString(row["city"])!;
			string imageUrl = Convert.ToString(row["imageURL"])!;
			int role = Convert.ToInt32(row["RoleID"]);
			string email = Convert.ToString(row["email"])!;
			string password = Convert.ToString(row["passwordhash"])!;
			string salt = Convert.ToString(row["salt"])!;
			string username = Convert.ToString(row["username"])!;


			Costumer customer = new Costumer(id, firstName, lastName, displayName, birthday, phone, country, address, city, imageUrl, role, email, password, salt, username);

			return customer;

		}
	}
}
