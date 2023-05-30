using DataLayer.DAL;
using LogicLayer.Interfaces;
using LogicLayer.Models.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class CheckoutService
    {
        private IDiscount _discount;
        private readonly IDiscountDAL dal;

        public CheckoutService(IDiscountDAL dal)
        {
            this.dal = dal;
        }

        public CheckoutService(IDiscount discount)
        {
            _discount = discount;
        }
        public void SetDiscount(IDiscount discount)
        {
            _discount = discount;
        }
        public decimal CalculateTotalPrice(decimal basePrice)
        {
            decimal finalPrice = _discount.ApplyDiscount(basePrice);
            return finalPrice;
        }

        public bool ApplyDiscountByCode(string discountCode)
        {
            var discounts = dal.RetrieveData();
            var discount = discounts.Find(d => d.Code == discountCode);

            if (discount != null)
            {
                IDiscount disc = Discount.GetDiscount(discount.DiscountType, discount.DiscountValue);
                SetDiscount(disc);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ApplyBirthdayDiscount(string type)
        {
            IDiscount disc = Discount.GetDiscount(type, 5);

            SetDiscount(disc);
            
        }

        public decimal CalculateTotalPriceBirthDate(decimal baseprice, DateTime birthdate)
        {
            decimal finalPrice = _discount.ApplyBirthdayDiscount(baseprice, birthdate);
            return finalPrice;
        }
    }
}
