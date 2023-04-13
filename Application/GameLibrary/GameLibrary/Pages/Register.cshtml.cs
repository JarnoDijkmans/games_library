using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;
using System.Security.Claims;
using LogicLayer;
using DataLayer.DAL;
using Factory;
using LogicLayer.Services;
using System.Text.Json;
using LogicLayer.Models;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
	{
		[BindProperty]
		public RegisterUser FormRegister { get; set; } = new RegisterUser();

		public string PageTitle = "Register";

		public void OnGet()
		{
			ModelState.Clear();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			//TempData["Register"] = JsonSerializer.Serialize(FormRegister);
			UserService userService = UserFactory.userservice;

			Costumer user = new Costumer(0, FormRegister.FirstName, FormRegister.LastName,
			FormRegister.DisplayName, FormRegister.Email, FormRegister.Country, FormRegister.Address,
			FormRegister.City, FormRegister.Password);
			
			userService.RegisterUser(user);

			return RedirectToPage("Index");
		}
	}
}

