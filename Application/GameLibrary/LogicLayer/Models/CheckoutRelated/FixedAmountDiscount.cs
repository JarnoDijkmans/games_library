﻿using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.CheckoutRelated
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
            if (basePrice != 0) 
            {
				return basePrice - _fixedAmount;
			}
            return 0;
            
        }

        public decimal ApplyDiscount(decimal basePrice, DateTime birthdate)
        {
            // Ignore birthdate for this type of discount
            return ApplyDiscount(basePrice);
        }
    }
}