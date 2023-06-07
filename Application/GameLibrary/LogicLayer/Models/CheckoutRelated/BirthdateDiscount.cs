using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.CheckoutRelated
{
    public class BirthdateDiscount : IDiscount
    {
        private decimal _birthdateDiscount;

        public BirthdateDiscount(decimal discount)
        {
            _birthdateDiscount = discount;
        }

        public decimal ApplyDiscount(decimal basePrice)
        {
            return basePrice - basePrice * (_birthdateDiscount / 100);
        }
    }
}

