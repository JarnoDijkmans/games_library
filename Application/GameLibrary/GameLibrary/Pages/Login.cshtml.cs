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
using LogicLayer.Models;
using DataLayer.DAL;

namespace WebApp.Pages
{
	public class LoginModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public string Message { get; private set; }
		
		public Login login;

		[BindProperty]
		public loginUser FormLogin { get; set; } = new loginUser();




		public LoginModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			ModelState.Clear();
			UserService userService = UserFactory.userservice;
			List<User> users = new List<User>();
			users.AddRange(userService.GetUsers());
			loginUser FormLogin = UserFactory.CreateLoginUser();

		}

		public IActionResult OnPostAsync()
		{
			User? loggedInUser = login.validateUserCredentials(FormLogin.Email, FormLogin.Password);

			// Validate by simulating a database call (IsUserValid)
			if (ModelState.IsValid && loggedInUser != null)
			{
				return RedirectToPage("Index");
			}
			else
			{
				return Page();
			}
		}
	}
}