using DataLayer.DAL;
using LogicLayer.Interfaces;
using LogicLayer.Models.CheckoutRelated;
using LogicLayer.Models.GamesFolder;
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
        private readonly ICheckoutDAL _checkout;
        private readonly IDiscountDAL dal;
        private readonly IDiscountFactory discountFactory;

        public CheckoutService(IDiscountDAL dal, IDiscountFactory discountFactory)
        {
            this.dal = dal;
            this.discountFactory = discountFactory;
        }

        public CheckoutService(ICheckoutDAL checkout)
        {
            this._checkout = checkout;
        }

        public void SetDiscount(IDiscount discount)
        {
            _discount = discount;
        }
        public decimal CalculateTotalPrice(decimal basePrice)
        {
            if (_discount != null)
            {
                decimal finalPrice = _discount.ApplyDiscount(basePrice);
                return finalPrice;
            }
            else
            {
                return basePrice;
            }
        }

        public bool ApplyDiscountByCode(string discountCode)
        {
            var discounts = dal.RetrieveData();
            var discount = discounts.Find(d => d.Code == discountCode);

            if (discount != null)
            {
                IDiscount disc = discountFactory.GetDiscount(discount.DiscountType, discount.DiscountValue);
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
            IDiscount disc = discountFactory.GetDiscount(type, 5);

            SetDiscount(disc);

        }

        public decimal CalculateTotalPriceBirthDate(decimal baseprice, DateTime birthdate)
        {
            decimal finalPrice = _discount.ApplyBirthdayDiscount(baseprice, birthdate);
            return finalPrice;
        }

        public bool StoreCheckout(CheckoutInfo info)
        {
            return true;
        }

        public List <CheckoutInfo> GetPaymentById(int id)
        {
            return _checkout.GetPaymentInfoByUserID(id);
        }

        public bool StorePayment(CheckoutInfo payment)
        {
            GetPaymentById(payment.PaymentID);
            return _checkout.StorePayment(payment);
        }
        public bool HasUserPurchasedGame(int userId, int gameId)
        {
            if (_checkout.HasUserPurchasedGame(userId, gameId) == true)
            {
                return true;
            }
            else return false;
        }
    }
}
