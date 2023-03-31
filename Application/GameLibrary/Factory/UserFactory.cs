using DataLayer.DAL;
using LogicLayer.Models;
using LogicLayer.Services;

namespace Factory
{
	public class UserFactory
	{
		public static UserService userservice { get; } =
		new UserService(new UserDAL());

		public static RegisterUser CreateRegisterUser()
		{
			return new RegisterUser();
		}

	}	
}