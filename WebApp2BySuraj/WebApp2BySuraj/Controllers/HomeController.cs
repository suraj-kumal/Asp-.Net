using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp2BySuraj.Models;
using WebApp2BySuraj.Services;

namespace WebApp2BySuraj.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            string message = _service.GetMessage();
            return View(model: message);
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
