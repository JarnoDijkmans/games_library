using DataLayer.DAL;
using LogicLayer.Models.Discount;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class DiscountFactory
    {
        public static Checkout checkout { get; } =
            new Checkout(new DiscountDAL());
    }
}
