using DataLayer.Connection;
using DataLayer.Converting;
using DataLayer.Converting.GamesDataConvert;
using LogicLayer.Models.CheckoutRelated;
using LogicLayer.Models.UserFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class CheckoutDAL : Datahandler, ICheckoutDAL
    {
        protected override string cmd
        {
            get
            {
                return "Select * FROM DiscountCodes";
            }
        }
        public List<CheckoutInfo> RetrieveData()
        {
            List<CheckoutInfo> Payments = new List<CheckoutInfo>();

            DataTable dt = base.ReadDataQuery(cmd);

            foreach (DataRow dr in dt.Rows)
            {
                CheckoutInfo Payment = DataConvertPayments.ConvertDataRowToPayment(dr);
                Payments.Add(Payment);

            }
            return Payments;
        }

        public List <CheckoutInfo> GetPaymentInfoByUserID(int id)
        {
            string query = $@"SELECT P.*, G.* FROM Purchase P INNER JOIN PurchaseGame PG ON P.PurchaseID = PG.PurchaseID INNER JOIN Game G ON PG.GameID = G.GameID WHERE P.UserID = {id};";
            
            List<CheckoutInfo> Payments = new List<CheckoutInfo>();
            
            DataTable dt = ReadDataQuery(query);
            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CheckoutInfo Payment = DataConvertPayments.ConvertDataRowToPayment(dr);
                    Payments.Add(Payment);

                }
                return Payments;
            }
            else { return null; }
        }

        public bool StorePayment(CheckoutInfo checkoutinfo)
        {
            try
            {
                string insertPaymentQuery = $"INSERT INTO Purchase (UserID, TotalPrice, PaymentType, DateOfPurchase) OUTPUT INSERTED.PurchaseID VALUES ({checkoutinfo.userID}, {checkoutinfo.TotalAmount},'{checkoutinfo.PaymentType}', '{checkoutinfo.DateOfPurchase.ToString("yyyy-MM-dd HH:mm:ss")}')";

                int PurchaseID = executeIdScalar(insertPaymentQuery);
                if (PurchaseID > 0)
                {
                    foreach (int gameID in checkoutinfo.GameIds)
                    {
                        string insertPurchaseGameQuery = $"INSERT INTO PurchaseGame (PurchaseID, GameID) VALUES ({PurchaseID}, {gameID})";

                        if (executeQuery(insertPurchaseGameQuery) <= 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
                

               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
