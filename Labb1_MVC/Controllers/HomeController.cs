using Labb1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Labb1_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorView = new ErrorViewModel
            {
                Message = HttpContext.Items["Message"]?.ToString() ?? "Ett oväntat fel inträffade."
            };
            return View(errorView);
        }
    }
}
