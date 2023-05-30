using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.Discount
{
    public class Discount
    {
        public string Code { get; private set; }
        public string DiscountType { get; private set; }
        public int DiscountValue { get; private set; }

        public Discount() { }

        public Discount(string code, string discountType, int discountValue)
        {
            Code = code;
            DiscountType = discountType;
            DiscountValue = discountValue;
        }


        public static IDiscount GetDiscount(string type, decimal value)
        {
            IDiscount discount;
            if (type == "Percentage")
            {
                discount = new PercentageDiscount(value);
            }
            else if (type == "FixedAmount")
            {
                discount = new FixedAmountDiscount(value);
            }
            else if (type == "BirthDate")
            {
                discount = new PercentageDiscount(value);
            }
            else
            {
                throw new Exception($"Unrecognized discount type: {type}");
            }
            return discount; ;
        }
    }
}
