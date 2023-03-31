using LogicLayer;
using LogicLayer.Users;

namespace DataLayer.DAL
{
	public interface IUserDAL
	{
		public List<User> retrieveUsers();
		public bool RegisterUser(User user);
	}

	
}