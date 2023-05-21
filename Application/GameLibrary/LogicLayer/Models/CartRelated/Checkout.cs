using DataLayer.DAL;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.Discount
{
    public class Checkout
    {
        private IDiscount _discount;
        private readonly IDiscountDAL dal;

        public Checkout(IDiscountDAL dal)
        {
            this.dal = dal;
        }

        public Checkout(IDiscount discount)
        {
            this._discount = discount;
        }
        public void SetDiscount (IDiscount discount)
        {
            this._discount = discount;
        }
        public decimal CalculateTotalPrice(decimal basePrice)
        {
            decimal finalPrice = this._discount.ApplyDiscount(basePrice);
            return finalPrice;
        }

        public void ApplyDiscountByCode(string discountCode)
        {
            var discounts = dal.RetrieveData();
            var discount = discounts.Find(d => d.Code == discountCode);

            if (discount != null)
            {
                IDiscount discountType;
                if (discount.DiscountType == "Percentage")
                {
                    discountType = new PercentageDiscount(discount.DiscountValue);
                }
                else if (discount.DiscountType == "FixedAmount")
                {
                    discountType = new FixedAmountDiscount(discount.DiscountValue);
                }
                else
                {
                    throw new Exception($"Unrecognized discount type: {discount.DiscountType}");
                }

                SetDiscount(discountType);
            }
            else
            {
                throw new Exception($"Discount code not found: {discountCode}");
            }
        }
    }
}
