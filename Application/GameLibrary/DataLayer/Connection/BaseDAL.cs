using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Connection
{
	public abstract class BaseDAL
	{
		private readonly string _connectionString = "Server=mssqlstud.fhict.local;Database=dbi513745;User Id=dbi513745;Password=Egh8c4pTS0;";

		protected IDbConnection GetConnection()
		{
			IDbConnection connection = new SqlConnection(_connectionString);
			return connection;
		}
	}
}
