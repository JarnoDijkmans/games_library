using DataLayer.Connection;
using DataLayer.Converting;
using DataLayer.Converting.GamesDataConvert;
using LogicLayer.Models.CheckoutRelated;
using LogicLayer.Models.GamesFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class DiscountDAL : Datahandler, IDiscountDAL
    {
        protected override string cmd
        {
            get
            {
                return "Select * FROM DiscountCodes";
            }
        }
        public List<Discount> RetrieveData()
        {
            List<Discount> discounts = new List<Discount>();

            DataTable dt = base.ReadDataQuery(cmd);

            foreach (DataRow dr in dt.Rows)
            {
                Discount discount = DataConvertDiscounts.ConvertDataRowToDiscount(dr);
                discounts.Add(discount);

            }
            return discounts;
        }

        public Discount GetDiscountByCode(string code)
        {
            string query = @$"SELECT * FROM DiscountCodes WHERE DiscountCodes.Code = '{code}'";

            DataTable dt = ReadDataQuery(query);

            if (dt.Rows.Count > 0)
            {

                Discount discount = DataConvertDiscounts.ConvertDataRowToDiscount(dt.Rows[0]);
                return discount;
            }
            else
            {
                throw new InvalidOperationException("No matching discount code found");
            }
        }
    }
}
