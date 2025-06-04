using HqmLesson07.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HqmLesson07.Controllers
{
    public class HqmEmployeeController : Controller
    {
        // Mock data:
        private static List<HqmEmployee> hqmListEmployee = new List<HqmEmployee>()
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
        // GET: HqmEmployeeController
        public ActionResult HqmIndex()
        {
            return View(hqmListEmployee);
        }

        // GET: HqmEmployeeController/HqmDetails/5
        public ActionResult HqmDetails(int id)
        {
            var hqmEmployee = hqmListEmployee.FirstOrDefault(x => x.HqmId == id);
            return View(hqmEmployee);
        }

        // GET: HqmEmployeeController/HqmCreate
        public ActionResult HqmCreate()
        {
            var hqmEmployee = new HqmEmployee();
            return View(hqmEmployee);
        }

        // POST: HqmEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HqmCreate(HqmEmployee hqmModel)
        {
            try
            {
                // them moi nhan vien vao list
                hqmModel.HqmId = hqmListEmployee.Max(x => x.HqmId) + 1;
                hqmListEmployee.Add(hqmModel);
                return RedirectToAction(nameof(HqmIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: HqmEmployeeController/HqmEdit/5
        public ActionResult HqmEdit(int id)
        {
            var hqmEmployee = hqmListEmployee.FirstOrDefault(x=>x.HqmId == id);
            return View(hqmEmployee);
        }

        // POST: HqmEmployeeController/HqmEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HqmEdit(int id, HqmEmployee hqmModel)
        {
            try
            {
                for (int i = 0; i < hqmListEmployee.Count(); i++)
                {
                    if (hqmListEmployee[i].HqmId == id)
                    {
                        hqmListEmployee[i] = hqmModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(HqmIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: HqmEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HqmEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
