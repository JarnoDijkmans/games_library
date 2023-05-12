using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models.GamesFolder;
using DataLayer.Converting.GamesDataConvert;
using DataLayer.DAL;

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
		//public DataTable ReadData()
		//{
		//	DataTable dt = new DataTable();
		//	try
		//	{
		//		con.Open();
		//		using (var command = new SqlCommand())
		//		{
		//			command.Connection = (SqlConnection)con;
		//			command.CommandText = cmd;
		//			var data = command.ExecuteReader();
		//			dt.Load(data);
		//		}
		//	}
		//	catch
		//	{
		//		return null;
		//	}

		//	finally
		//	{
		//		con.Close();
		//	}
		//	return dt;
		//}


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

        public DataTable ReadDataQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = (SqlConnection)con;
                    command.CommandText = query;
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





        //     private Game ExecuteQueryAndReturnGame(string query)
        //     {
        //         try
        //{
        //	con.Open();
        //                using (SqlCommand command = new SqlCommand(query))
        //                {
        //                    using (SqlDataReader reader = command.ExecuteReader())
        //                    {
        //                       if (reader.Read())
        //                       {
        //                          // Convert the SqlDataReader to a DataRow
        //                          DataTable dt = new DataTable();
        //                          dt.Load(reader);
        //                          DataRow row = dt.Rows[0];

        //				// Call the CreateGameFromDataRow method
        //                          return DataConvertingGames.ConvertDataRowToGame(row, GameDAL gameDal);
        //                       }
        //                    }
        //                }
        //         }
        //                 return null;
        //     }
    }
}
