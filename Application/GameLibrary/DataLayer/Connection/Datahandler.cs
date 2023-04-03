using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Connection
{
	public class Datahandler : BaseDAL
	{
		private IDbConnection con;
		protected virtual string cmd { get; }

		public Datahandler()
		{
			this.con = base.GetConnection();
		}

		//Retrieves all data from the database
		public DataTable ReadData()
		{
			DataTable dt = new DataTable();
			try
			{
				con.Open();
				using (var command = new SqlCommand())
				{
					command.Connection = (SqlConnection)con;
					command.CommandText = cmd;
					var data = command.ExecuteReader();
					dt.Load(data);
				}
			}
			catch
			{
				return null;
			}

			finally
			{
				con.Close();
			}
			return dt;
		}

		//Executes a given SQL query and returns the number of rows affected
		public int executeQuery(string query)
		{
			try
			{
				con.Open();
				using (var command = new SqlCommand())
				{
					command.Connection = (SqlConnection)con;
					command.CommandText = query;
					return command.ExecuteNonQuery();
				}
			}
			catch
			{
				return 0;
			}
			finally
			{
				con.Close();
			}

		}

		public int executeIdScalar(string query)
		{
			try
			{
				con.Open();
				using (var command = new SqlCommand())
				{
					command.Connection = (SqlConnection)con;
					command.CommandText = query;
					int newId = (int)command.ExecuteScalar();

					return newId;
				}
			}
			catch { return 0; }

			finally
			{
				con.Close();
			}
		}
	}
}
