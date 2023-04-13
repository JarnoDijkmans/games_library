using DataLayer.DAL;
using LogicLayer.Models;
using LogicLayer.Services;
using LogicLayer.Verify;

namespace Factory
{
    public class UserFactory
	{
		public static UserService userservice { get; } =
		new UserService(new UserDAL());

		public static Verify CreateLoginUser()
		{
			return new Verify(new UserDAL());
		}
	}	
}