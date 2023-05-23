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
using System.Text.Json;
using LogicLayer.Models.UserFolder;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public string Message { get; private set; }
		//Verify Ac = UserFactory.VerifyeLoginUser();

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
            if (FormLogin.Email != null && FormLogin.Password != null)
            {
                User? loggedInUser = UserFactory.VerifyeLoginUser().validateUserCredentials(FormLogin.Email, FormLogin.Password);
                if (loggedInUser != null && loggedInUser.Role == 1)
                {
                    HttpContext.Session.SetInt32("UserId", loggedInUser.Id);

                    // Get the temporary identifier from the cookie
                    string tempId = HttpContext.Request.Cookies["TempId"];

                    if (!string.IsNullOrEmpty(tempId))
                    {
                        string tempCartDataKey = $"CartData_{tempId}";
                        string userCartDataKey = $"CartData_{loggedInUser.Id}";

                        string tempCartData = HttpContext.Session.GetString(tempCartDataKey);
                        string userCartData = HttpContext.Session.GetString(userCartDataKey);

                        List<int> tempGameIds = string.IsNullOrEmpty(tempCartData) ? new List<int>() : JsonSerializer.Deserialize<List<int>>(tempCartData);
                        List<int> userGameIds = string.IsNullOrEmpty(userCartData) ? new List<int>() : JsonSerializer.Deserialize<List<int>>(userCartData);

                        // Merge the temporary cart data with the user's cart data
                        userGameIds.AddRange(tempGameIds);
                        userGameIds = userGameIds.Distinct().ToList();

                        // Update the user's cart data and remove the temporary cart data
                        HttpContext.Session.SetString(userCartDataKey, JsonSerializer.Serialize(userGameIds));
                        HttpContext.Session.Remove(tempCartDataKey);

                        // Remove the temporary identifier from the cookie
                        HttpContext.Response.Cookies.Delete("TempId");
                    }

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