using LogicLayer.Models.Discount;

namespace DataLayer.DAL
{
    public interface IDiscountDAL
    {
        public List<Discount> RetrieveData();
    }
}