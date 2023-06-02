using LogicLayer.Models.CheckoutRelated;

namespace DataLayer.DAL
{
    public interface IDiscountDAL
    {
        public List<Discount> RetrieveData();
    }
}