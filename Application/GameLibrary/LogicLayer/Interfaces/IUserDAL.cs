using LogicLayer;
using LogicLayer.Models.UserFolder;

namespace DataLayer.DAL
{
    public interface IUserDAL
	{
		public List<User> retrieveUsers();
		public bool RegisterUser(User user);
	}

	
}