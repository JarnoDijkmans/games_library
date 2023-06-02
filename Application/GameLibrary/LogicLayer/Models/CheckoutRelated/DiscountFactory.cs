using LogicLayer.Interfaces;
using LogicLayer.Models.CheckoutRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.CheckoutRelated
{
    public class DiscountFactory : IDiscountFactory
    {
        public IDiscount GetDiscount(string type, decimal value)
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
            return discount;
        }
    }
}
