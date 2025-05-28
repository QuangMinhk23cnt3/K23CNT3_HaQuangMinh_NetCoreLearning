using HqmLab06.Models;
using Microsoft.AspNetCore.Mvc;

namespace HqmLab06.Controllers
{
    public class HqmEmployeeController : Controller
    {
        private static List<HqmEmployee> hqmListEmployees = new List<HqmEmployee>()
        {
            new HqmEmployee
            {
                HqmId = 1,
                HqmName = "Ha Quang Minh",
                HqmBirthDay = new DateTime(2005, 6, 2),
                HqmEmail = "haquangminhk23cnt3@gmail.com",
                HqmPhone = "0846409694",
                HqmSalary = 1500.0m,
                HqmStatus = true
            },
            new HqmEmployee
            {
                HqmId = 2,
                HqmName = "Tran Thi B",
                HqmBirthDay = new DateTime(1985, 3, 15),
                HqmEmail = "b@example.com",
                HqmPhone = "0923456789",
                HqmSalary = 1800.0m,
                HqmStatus = false
            },
            new HqmEmployee
            {
                HqmId = 3,
                HqmName = "Le Van C",
                HqmBirthDay = new DateTime(1992, 8, 10),
                HqmEmail = "c@example.com",
                HqmPhone = "0934567890",
                HqmSalary = 1700.0m,
                HqmStatus = true
            },
            new HqmEmployee
            {
                HqmId = 4,
                HqmName = "Pham Thi D",
                HqmBirthDay = new DateTime(1995, 11, 25),
                HqmEmail = "d@example.com",
                HqmPhone = "0945678901",
                HqmSalary = 1600.0m,
                HqmStatus = false
            },
            new HqmEmployee
            {
                HqmId = 5,
                HqmName = "Hoang Van E",
                HqmBirthDay = new DateTime(1988, 1, 5),
                HqmEmail = "e@example.com",
                HqmPhone = "0956789012",
                HqmSalary = 2000.0m,
                HqmStatus = true
            }
        };
        public IActionResult HqmIndex()
        {
            return View(hqmListEmployees);
        }

        public IActionResult HqmCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HqmCreate(HqmEmployee model)
        {
            if (ModelState.IsValid)
            {
                int newId = hqmListEmployees.Any() ? hqmListEmployees.Max(e => e.HqmId) + 1 : 1;
                model.HqmId = newId;

                hqmListEmployees.Add(model);

                return RedirectToAction("HqmIndex");
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult HqmEdit(int id)
        {
            var hqmEmp = hqmListEmployees.FirstOrDefault(e => e.HqmId == id);
            return View(hqmEmp);
        }

        [HttpPost]
        public IActionResult HqmEditPUT(HqmEmployee updatedEmp)
        {
            var hqmEmp = hqmListEmployees.FirstOrDefault(e => e.HqmId == updatedEmp.HqmId);
            if (hqmEmp != null)
            {
                hqmEmp.HqmName = updatedEmp.HqmName;
                hqmEmp.HqmBirthDay = updatedEmp.HqmBirthDay;
                hqmEmp.HqmEmail = updatedEmp.HqmEmail;
                hqmEmp.HqmPhone = updatedEmp.HqmPhone;
                hqmEmp.HqmSalary = updatedEmp.HqmSalary;
                hqmEmp.HqmStatus = updatedEmp.HqmStatus;
            }
            return RedirectToAction("HqmIndex");
        }

        public IActionResult HqmDelete(int id)
        {
            var hqmEmp = hqmListEmployees.FirstOrDefault(e => e.HqmId == id);
            if (hqmEmp != null) hqmListEmployees.Remove(hqmEmp);
            return RedirectToAction("HqmIndex");
        }
    }
}
