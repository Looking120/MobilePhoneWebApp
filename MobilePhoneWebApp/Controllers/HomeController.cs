using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.Models;
using System.Diagnostics;

namespace MobilePhoneWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.IsHomePage = true;
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.IsHomePage = false;
            return View();
        }

        public IActionResult Customer()
        {
            ViewBag.IsHomePage = true;
            return View();
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}