using DataLayer.Connection;
using DataLayer.Converting;
using DataLayer.Converting.GamesDataConvert;
using LogicLayer.Models.CheckoutRelated;
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
    }
}
