using LogicLayer.Models;
using LogicLayer.Models.CheckoutRelated;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Converting
{
    public static class DataConvertDiscounts
    {
        public static Discount ConvertDataRowToDiscount(DataRow row)
        {
            string code = Convert.ToString(row["Code"])!;
            string discountType = Convert.ToString(row["DiscountType"])!;
            int discountValue = Convert.ToInt32(row["DiscountValue"]);



            Discount discount = new Discount(code, discountType, discountValue);

            return discount;
        }
    }
}
