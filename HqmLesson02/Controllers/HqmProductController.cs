using Microsoft.AspNetCore.Mvc;

namespace HqmLesson02.Controllers
{
    public class HqmProductController : Controller
    {
        public IActionResult HqmIndex()
        {
            ViewData["messageData"] = "Du lieu tu viewData";
            ViewBag.messageData = "Du lieu tu ViewBag";
            TempData["messageData"] = "Du lieu TempData";
            return View();
        }
    }
}
