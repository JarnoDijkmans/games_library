using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
	public class Result
	{
		//Didnt use it yet
		private bool success;
		private Exception? exception;

		public Result(bool success, Exception? exception) 
		{
			this.success = success;
			if(!success)
			{
				this.exception = exception;
			}
		}

		public bool Success { get { return success; } }

		public Exception? Exception
		{
			get
			{
				if(exception is null)
				{
					throw new ArgumentException("exception");
				}
				return exception;
			}
		}
	}
}
