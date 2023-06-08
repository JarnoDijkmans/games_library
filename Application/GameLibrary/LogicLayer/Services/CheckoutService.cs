using DataLayer.DAL;
using LogicLayer.Interfaces;
using LogicLayer.Models.CartRelated;
using LogicLayer.Models.CheckoutRelated;
using LogicLayer.Models.GamesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class CheckoutService
    {
        private IDiscount _discount;
        private readonly ICheckoutDAL _checkout;
        private readonly IDiscountDAL _dal;
        private DiscountStrategyFactory _strategyFactory;
        private IDiscount _birthdateDiscount;
        private IDiscount _codeDiscount;


        public CheckoutService(DiscountStrategyFactory strategyFactory, IDiscountDAL dal, ICheckoutDAL checkout)
        {
            this._strategyFactory = strategyFactory;
            this._dal = dal;
            this._checkout = checkout;
        }

		public decimal ApplyDiscount(string discountCode, decimal basePrice, DateTime birthdate)
		{
			if (birthdate.Day == DateTime.UtcNow.Day && birthdate.Month == DateTime.UtcNow.Month)
			{
				if (_birthdateDiscount == null)
				{
					_birthdateDiscount = _strategyFactory.CreateStrategy("BirthDate", 5);
				}
				basePrice = _birthdateDiscount.ApplyDiscount(basePrice);
			}

			_codeDiscount = null;
			// apply discount code, if any
			if (!string.IsNullOrEmpty(discountCode))
			{
				List<Discount> discounts = _dal.RetrieveData();
				bool discountFound = false;

				foreach (Discount discount in discounts)
				{
					if (discount.Code == discountCode)
					{
						discountFound = true;

						if (_codeDiscount == null)
						{
							_codeDiscount = _strategyFactory.CreateStrategy(discount.DiscountType, discount.DiscountValue);
						}

						basePrice = _codeDiscount.ApplyDiscount(basePrice);
						break;
					}
				}
			}

			return basePrice;
		}


		public List <CheckoutInfo> GetPaymentById(int id)
        {
            return _checkout.GetPaymentInfoByUserID(id);
        }

        public bool StorePayment(CheckoutInfo payment)
        {
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

        public decimal CalculateSubtotal(CartViewModel cart)
        {
            decimal subtotal = cart.GamesInCart.Sum(game => game.Price);
            return subtotal;
        }

        public decimal CalculateAmountDiscount(decimal totalPriceBeforeDiscount, decimal totalpriceAfterDiscount)
        {
            decimal discount = totalPriceBeforeDiscount - totalpriceAfterDiscount;
            return discount;
        }

		public bool ValidateDiscountCode(string discountCode)
		{
			if (string.IsNullOrEmpty(discountCode))
			{
				return true; 
			}
			else
			{
				List<Discount> discounts = _dal.RetrieveData();
				foreach (Discount discount in discounts)
				{
					if (discount.Code == discountCode)
					{
						return true;  
					}
				}
			}

			throw new ValidationException("Invalid DiscountCode, Try again.");  
		}
	}
}
