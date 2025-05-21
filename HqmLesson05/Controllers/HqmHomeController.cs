using System.Diagnostics;
using HqmLesson05.Models;
using HqmLesson05.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace HqmLesson05.Controllers
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
            HqmMember hqmMember = new HqmMember();
            hqmMember.HqmMemberId = Guid.NewGuid().ToString();
            hqmMember.HqmUserName = "QuangMinh";
            hqmMember.HqmPassword = "123456@";
            hqmMember.HqmFullName = "Ha Quang Minh";
            hqmMember.HqmEmail = "haquangminhk23cnt3@gmail.com";
            return View(hqmMember);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
