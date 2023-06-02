using LogicLayer.Models.CheckoutRelated;

namespace DataLayer.DAL
{
    public interface ICheckoutDAL
    {
        List<CheckoutInfo> RetrieveData();
        public List <CheckoutInfo> GetPaymentInfoByUserID(int id);
    }
}