using System.Diagnostics;
using HqmLesson02.Models;
using Microsoft.AspNetCore.Mvc;

namespace HqmLesson02.Controllers
{
    public class HqmHomeController : Controller
    {
        private readonly ILogger<HqmHomeController> _logger;

        public HqmHomeController(ILogger<HqmHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult HqmIndex()
        {
            return View();
        }

        public IActionResult HqmAbout()
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
