using Homework_4_Chervenko.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework_4_Chervenko.Controllers
{
    public class DeveloperController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WelcomePage(Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(developer);
        }

        [HttpPost]
        public IActionResult AddDeveloper(Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", developer);
            }
            return RedirectToAction("WelcomePage", developer);
        }
    }
}
