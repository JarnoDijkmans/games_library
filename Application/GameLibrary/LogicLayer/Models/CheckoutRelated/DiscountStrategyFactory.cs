using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.CheckoutRelated
{
    public class DiscountStrategyFactory
    {
        public IDiscount CreateStrategy(string type, decimal discountAmount)
        {
            IDiscount discount;

            if (type == "FixedAmount")
            {
                return new FixedAmountDiscount(discountAmount);
            }
            else if (type == "Percentage")
            {
                return new PercentageDiscount(discountAmount);
            }
            else if (type == "BirthDate")
            {
                return new BirthdateDiscount(discountAmount);
            }

            return null;
        }
    }
}

