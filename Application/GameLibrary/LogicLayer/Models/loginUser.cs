using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
	public class loginUser
	{
		[Required(ErrorMessage = "An e-mail address is required")]
		[EmailAddress(ErrorMessage = "The address is not a valid e-mail address")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "A password is required")]
		[MinLength(8, ErrorMessage = "A Password should have a minimum of 8 characters")]
		public string? Password { get; set; }
	}
}
