using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApp7BySuraj.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string username, string password, string returnUrl = "/")
        {
            // Validate username and password, and authenticate user
            if (username == "admin" && password == "admin")
            {
                var claims = new[] { new System.Security.Claims.Claim("username", username), new System.Security.Claims.Claim(ClaimTypes.Role, "Admin") };
                var identity = new System.Security.Claims.ClaimsIdentity(claims, "MyCookieAuth");
                var principal = new System.Security.Claims.ClaimsPrincipal(identity);
                HttpContext.SignInAsync("MyCookieAuth", principal);
                return RedirectToAction("Admin", "Home");
            }

            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index", "Home");
        }
    }
}
