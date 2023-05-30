using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.Discount
{
    public class FixedAmountDiscount : IDiscount
    {
        private decimal _fixedAmount;

        public FixedAmountDiscount(decimal fixedAmount)
        {
            _fixedAmount = fixedAmount;
        }

        public decimal ApplyDiscount(decimal basePrice)
        {
            return basePrice - _fixedAmount;
        }

        public decimal ApplyBirthdayDiscount(decimal basePrice, DateTime birthdate)
        {
            // No birthday discount is applied
            return basePrice;
        }
    }
}
