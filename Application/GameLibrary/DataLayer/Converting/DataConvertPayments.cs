using DataLayer.Converting.GamesDataConvert;
using LogicLayer.Models;
using LogicLayer.Models.CheckoutRelated;
using LogicLayer.Models.GamesFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Converting
{
    public static class DataConvertPayments
    {
        public static CheckoutInfo ConvertDataRowToPayment(DataRow row)
        {
            int PurchaseID = Convert.ToInt32(row["PurchaseID"]);
            int GameID = Convert.ToInt32(row["GameId"]);
            List<int> GameIDs = new List<int> { GameID };
            int UserID = Convert.ToInt32(row["UserID"]);
            decimal TotalPrice = Convert.ToDecimal(row["TotalPrice"]);
            string PaymentType = Convert.ToString(row["PaymentType"])!;
            DateTime DateOfPurchase = Convert.ToDateTime(row["DateOfPurchase"]);


            CheckoutInfo discount = new CheckoutInfo(PurchaseID, PaymentType, TotalPrice, GameIDs, UserID, DateOfPurchase);

            return discount;
        }
    }
}

