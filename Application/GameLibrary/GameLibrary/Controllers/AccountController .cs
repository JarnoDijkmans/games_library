using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            // Clear the user's session data
            HttpContext.Session.Clear();

            // Redirect the user to the Login page
            return RedirectToAction("Login", "Login");
        }
    }
}
