using LogicLayer.Models.CheckoutRelated;

namespace DataLayer.DAL
{
    public interface IDiscountDAL
    {
        public List<Discount> RetrieveData();
        public Discount GetDiscountByCode(string code);
    }
}