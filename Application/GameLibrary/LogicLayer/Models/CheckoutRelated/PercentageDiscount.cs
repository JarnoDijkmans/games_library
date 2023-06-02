using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.CheckoutRelated
{
    public class PercentageDiscount : IDiscount
    {
        private decimal _percentage;

        public PercentageDiscount(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal ApplyDiscount(decimal basePrice)
        {
            return basePrice - basePrice * (_percentage / 100);
        }

        public decimal ApplyBirthdayDiscount(decimal basePrice, DateTime birthdate)
        {
            return basePrice - basePrice * (_percentage / 100);
        }
    }
}
