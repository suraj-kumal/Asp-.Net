using FormValidation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Signup()
        {
            ViewBag.Name = "Suraj Kumal";
            ViewBag.RollNo = "32";
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(string email, string password)
        {
            // Perform server-side validation and sign-up logic here
            return Json(new { success = true }); // Return success JSON response
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
