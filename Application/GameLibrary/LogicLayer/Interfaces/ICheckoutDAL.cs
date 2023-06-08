using LogicLayer.Models.CheckoutRelated;

namespace DataLayer.DAL
{
    public interface ICheckoutDAL
    {
        public List <CheckoutInfo> GetPaymentInfoByUserID(int id);
        public bool StorePayment(CheckoutInfo checkoutinfo);

        public bool HasUserPurchasedGame(int userId, int gameId);
    }
}