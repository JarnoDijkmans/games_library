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
    }
}
