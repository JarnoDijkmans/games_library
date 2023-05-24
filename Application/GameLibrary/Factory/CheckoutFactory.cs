using DataLayer.DAL;
using LogicLayer.Interfaces;
using LogicLayer.Models.Discount;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class CheckoutFactory
    {
        public static CheckoutService checkout { get; } =
            new CheckoutService(new CheckoutDAL());

        
    }
}
