using DataLayer.DAL;
using LogicLayer.Models.CheckoutRelated;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public static class CheckoutFactory
    {
        public static CheckoutService checkoutservice { get; } =
            new CheckoutService(new DiscountStrategyFactory(), new DiscountDAL(), new CheckoutDAL());
    }
}
