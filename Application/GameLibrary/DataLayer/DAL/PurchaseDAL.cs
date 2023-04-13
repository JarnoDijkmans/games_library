using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models;

namespace DataLayer.DAL
{
    public class PurchaseDAL : IPurchaseDAL
	{
		public List<Purchase> GetAll()
		{
			// doe een query naar de database

			return new List<Purchase>();
		}
	}
}
