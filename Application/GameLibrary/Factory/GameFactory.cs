using DataLayer.DAL;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
	public static class GameFactory
	{
		public static GameService gameservice { get; } =
			new GameService(new GameDAL());
	}
}