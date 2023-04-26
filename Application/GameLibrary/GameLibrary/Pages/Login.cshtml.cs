using Factory;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using LogicLayer.Models;
using DataLayer.DAL;
using LogicLayer.Verify;
using GameLibrary.Pages;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public string Message { get; private set; }
		Verify Ac = UserFactory.CreateLoginUser();

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
		}

		public IActionResult OnPostAsync()
		{
			if (FormLogin.Email != null && FormLogin.Password != null )
			{
                User? loggedInUser = UserFactory.CreateLoginUser().validateUserCredentials(FormLogin.Email, FormLogin.Password);
                if (loggedInUser != null)
                {
                    return RedirectToPage("Index");
                }

				else
				{
                    ModelState.AddModelError(string.Empty, "Combination incorrect, please enter email and password");
                    return Page();
				}
            }
			
			// Validate by simulating a database call (IsUserValid)
			else
			{
                ModelState.AddModelError(string.Empty, "Combination incorrect, please enter email and password");
                return Page();
			}
		}
	}
}