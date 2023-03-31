using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
	public class PurchaseService
	{
		private readonly IPurchaseDAL dal;
		private List<Purchase> purchase = new List<Purchase>();

		public PurchaseService(IPurchaseDAL dal)
		{
			this.dal = dal;
		}


	}
}
