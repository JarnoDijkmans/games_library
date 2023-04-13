using LogicLayer.Models;

namespace DataLayer.DAL
{
    public interface IPurchaseDAL
	{
		List<Purchase> GetAll();
	}
}