using Microsoft.AspNetCore.Mvc;
using WebApp1BySuraj.Models;
namespace WebApp1BySuraj.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyRazorPage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
         public IActionResult Create(Student student)
         {
             if (ModelState.IsValid)
             {
                 return RedirectToAction("Details", student);
             }
             return View(student);
         }

         public IActionResult Details(Student student)
         {
             return View(student);
         }

    }
}
