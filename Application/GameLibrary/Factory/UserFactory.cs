using DataLayer.DAL;
using LogicLayer;
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

		public static Verify CreateLoginUser()
		{
			return new Verify(new UserDAL());
		}

	}	
}