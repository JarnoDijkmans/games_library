using DataLayer.DAL;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
	public class PurchaseFactory
	{
		public static PurchaseService purchaseservice { get; } =
		   new PurchaseService(new PurchaseDAL());
	}
}
