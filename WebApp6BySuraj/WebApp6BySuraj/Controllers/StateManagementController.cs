using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace WebApp6BySuraj.Controllers
{
    public class StateManagementController : Controller
    {
        // Action to set session data
        public IActionResult SetSessionData()
        {
            // Set some session data
            HttpContext.Session.SetString("UserName", "Suraj Kumal");
            HttpContext.Session.SetString("UserRole", "Administrator");
            HttpContext.Session.SetInt32("UserAge", 22);

            // Optionally, redirect to another action or view
            return RedirectToAction("DisplaySessionData");
        }

        // Action to display session data
        public IActionResult DisplaySessionData()
        {
            // Retrieve session data
            var userName = HttpContext.Session.GetString("UserName");
            var userRole = HttpContext.Session.GetString("UserRole");
            var userAge = HttpContext.Session.GetInt32("UserAge");

            // Pass the session data to the view using ViewBag
            ViewBag.UserName = userName;
            ViewBag.UserRole = userRole;
            ViewBag.UserAge = userAge;

            return View();
        }
        // Action to set session data and temp data
        public IActionResult SetData()
        {
            // Set session data
            HttpContext.Session.SetString("UserName", "JohnDoe");
            HttpContext.Session.SetString("UserRole", "Administrator");
            HttpContext.Session.SetString("LastLogin", DateTime.Now.ToString());
            HttpContext.Session.SetInt32("UserAge", 30);

            // Set temp data
            TempData["Message"] = "Data set successfully.";

            // Optionally, redirect to another action or view
            return RedirectToAction("DisplayData");
        }

        // Action to display session data and temp data
        public IActionResult DisplayData()
        {
            // Retrieve session data
            var userName = HttpContext.Session.GetString("UserName");
            var userRole = HttpContext.Session.GetString("UserRole");
            var lastLogin = HttpContext.Session.GetString("LastLogin");
            var userAge = HttpContext.Session.GetInt32("UserAge");

            // Retrieve temp data
            var message = TempData["Message"];

            // Pass the session and temp data to the view using ViewBag
            ViewBag.UserName = userName;
            ViewBag.UserRole = userRole;
            ViewBag.LastLogin = lastLogin;
            ViewBag.UserAge = userAge;
            ViewBag.Message = message;

            return View();
        }
        // Action to set TempData only
        public IActionResult SetTempData()
        {
            // Set TempData data
            TempData["Message"] = "Hello, Good Morning!";

            // Optionally, redirect to another action or view
            return RedirectToAction("DisplayTempData");
        }

        // Action to display TempData only
        public IActionResult DisplayTempData()
        {
            // Retrieve TempData data
            var message = TempData["Message"];

            // Pass the TempData data to the view using ViewBag
            ViewBag.Message = message;

            return View();
        }
        // Action to set cookies
        public IActionResult SetCookies()
        {
            // Set cookies
            Response.Cookies.Append("Username", "Suraj Kumal");
            Response.Cookies.Append("UserAge", "22");

            // Optionally, redirect to another action or view
            return RedirectToAction("DisplayCookies");
        }
        // Action to display cookies
        public IActionResult DisplayCookies()
        {
            // Retrieve cookies
            var username = Request.Cookies["Username"];
            var userAge = Request.Cookies["UserAge"];

            // Pass the cookies data to the view using ViewBag
            ViewBag.Username = username;
            ViewBag.UserAge = userAge;
            return View();
        }
        public IActionResult SetQueryString(string username, int userAge)
        {
            // Redirect to another action with query string parameters
            return RedirectToAction("DisplayQueryString", new { Username = username, UserAge = userAge });
        }

        // Action to display query string parameters
        public IActionResult DisplayQueryString(string username, int userAge)
        {
            // Pass query string parameters to the view using ViewBag
            ViewBag.Username = username;
            ViewBag.UserAge = userAge;

            return View();
        }
        // Action to render a form with a hidden field
        public IActionResult RenderForm()
        {
            // Pass a value to be stored in the hidden field
            ViewBag.HiddenValue = "I dont know its hidden";

            return View();
        }

        // Action to handle form submission and display the hidden field value
        [HttpPost]
        public IActionResult SubmitForm(string hiddenValue)
        {
            // Process the submitted form data
            // Here, we're just passing the hidden field value to the view
            ViewBag.HiddenValue = hiddenValue;

            return View("DisplayHiddenValue");
        }

        // Default action
        public IActionResult Index()
        {
            return View();
        }
    }
}
