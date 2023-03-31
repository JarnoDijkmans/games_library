using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
	public class RegisterUser
	{
		[Required(ErrorMessage = "A Country is required")]
		[MinLength(4, ErrorMessage = "A country should have a minimum of 4 characters")]
		public string? Country { get; set; }
		[Required(ErrorMessage = "A firstname is required"),
		MinLength(3, ErrorMessage = "Your firstname should have a minimum of 3 characters")]
		public string? FirstName { get; set; }

		[Required(ErrorMessage = "A lastname is required"),
		 MinLength(4, ErrorMessage = "Your lastname should have a minimum of 4 characters")]
		public string? LastName { get; set; }

		[Required(ErrorMessage = "A lastname is required"),
		MinLength(5, ErrorMessage = "Your display name should have a minimum of 5 characters")]
		public string? DisplayName { get; set; }

		[Required(ErrorMessage = "An e-mail address is required")]
		[EmailAddress(ErrorMessage = "The address is not a valid e-mail address")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "A password is required")]
		[MinLength(8, ErrorMessage = "A Password should have a minimum of 8 characters")]
		public string? Password { get; set; }

		[Required(ErrorMessage = "A city is required")]
		[MinLength(4, ErrorMessage = "A city should have a minimum of 4 characters")]
		public string? City { get; set; }
		[Required(ErrorMessage = "An address is required")]
		public string? Address { get; set; }
	}
}
