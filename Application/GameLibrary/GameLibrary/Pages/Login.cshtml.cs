using Factory;
using GameLibrary.Pages;
using LogicLayer.Services;
using LogicLayer.Users;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebApp.Pages
{
	public class LoginModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public string Message { get; private set; }

		private readonly Login login;

		[BindProperty]
		public Costumer customer { get; set; }
		
		
		

		public LoginModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			UserService userService = UserFactory.userservice;
			List<User> users = new List<User>();
			users.AddRange(userService.GetUsers());
		}

		public async Task OnPostAsync()
		{
			string username = Request.Form["username"];
			string password = Request.Form["password"];
			User? loggedInUser = login.validateUserCredentials(username, password);

			// Validate by simulating a database call (IsUserValid)
			if (ModelState.IsValid && loggedInUser != null)
			{
				ClaimsIdentity claimsIdentity = new ClaimsIdentity(
					new Claim[]
					{
						new Claim("id", "john@fontys.nl"),
						new Claim(ClaimTypes.Name, "John Wijnen"),
						new Claim(ClaimTypes.Role, "Admin"),
						new Claim(ClaimTypes.Role, "PremiumCustomer"),
					}, CookieAuthenticationDefaults.AuthenticationScheme);
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
				await HttpContext.SignInAsync(claimsPrincipal);
			}
			else
			{
				await HttpContext.ForbidAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			}
		}
	}
}