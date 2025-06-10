using HqmLesson08.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HqmLesson08.Controllers
{
    public class HqmAccountController : Controller
    {
        private static List<HqmAccount> hqmListAccount = new List<HqmAccount>()
        {
            new HqmAccount
            {
                HqmId = 231090067,
                HqmFullName = "Ha Quang Minh",
                HqmEmail = "haquangminhk23cnt3@gmail.com",
                HqmPhone = "0846409694",
                HqmAddress = "Hà Nội",
                HqmAvatar = "avatar1.jpg",
                HqmBirthday = new DateTime(2005, 6, 2),
                HqmGender = "Nam",
                HqmPassword = "123456@",
                HqmFacebook = "https://www.facebook.com/ha.q.minh206/"
            },
            new HqmAccount
            {
                HqmId = 2,
                HqmFullName = "Trần Thị B",
                HqmEmail = "tranthib@example.com",
                HqmPhone = "0909876543",
                HqmAddress = "Đà Nẵng",
                HqmAvatar = "avatar2.jpg",
                HqmBirthday = new DateTime(1998, 10, 1),
                HqmGender = "Nữ",
                HqmPassword = "abcdef",
                HqmFacebook = "https://facebook.com/tranthib"
            },
            new HqmAccount
            {
                HqmId = 3,
                HqmFullName = "Lê Văn C",
                HqmEmail = "levanc@example.com",
                HqmPhone = "0938123456",
                HqmAddress = "TP.HCM",
                HqmAvatar = "avatar3.jpg",
                HqmBirthday = new DateTime(1990, 3, 20),
                HqmGender = "Nam",
                HqmPassword = "pass123",
                HqmFacebook = "https://facebook.com/levanc"
            },
            new HqmAccount
            {
                HqmId = 4,
                HqmFullName = "Phạm Thị D",
                HqmEmail = "phamthid@example.com",
                HqmPhone = "0987654321",
                HqmAddress = "Cần Thơ",
                HqmAvatar = "avatar4.jpg",
                HqmBirthday = new DateTime(2000, 7, 15),
                HqmGender = "Nữ",
                HqmPassword = "mypass",
                HqmFacebook = "https://facebook.com/phamthid"
            },
            new HqmAccount
            {
                HqmId = 5,
                HqmFullName = "Đỗ Mạnh E",
                HqmEmail = "domanhe@example.com",
                HqmPhone = "0977777777",
                HqmAddress = "Hải Phòng",
                HqmAvatar = "avatar5.jpg",
                HqmBirthday = new DateTime(1992, 12, 25),
                HqmGender = "Nam",
                HqmPassword = "securepw",
                HqmFacebook = "https://facebook.com/domanhe"
            }
        };
        // GET: HqmAccountController
        public ActionResult HqmIndex()
        {
            return View(hqmListAccount);
        }

        // GET: HqmAccountController/Details/5
        public ActionResult HqmDetails(int id)
        {
            var hqmAccount = hqmListAccount.FirstOrDefault(x => x.HqmId == id);
            return View(hqmAccount);
        }

        // GET: HqmAccountController/Create
        public ActionResult HqmCreate()
        {
            var hqmModel = new HqmAccount();
            return View(hqmModel);
        }

        // POST: HqmAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HqmCreate(HqmAccount hqmModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    hqmListAccount.Add(hqmModel);

                    return RedirectToAction(nameof(HqmIndex));
                }

                // Nếu dữ liệu không hợp lệ, trả lại View với dữ liệu cũ
                return View(hqmModel);
            }
            catch (Exception ex)
            {
                // Ghi log nếu cần
                ModelState.AddModelError("", "Có lỗi xảy ra khi thêm mới tài khoản." + ex.Message);
                return View(hqmModel);
            }
        }

        // GET: HqmAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HqmAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: HqmAccountController/Delete/5
        public ActionResult HqmDelete(int id)
        {
            var hqmAccount = hqmListAccount.FirstOrDefault(e => e.HqmId == id);
            if (hqmAccount != null) hqmListAccount.Remove(hqmAccount);
            return RedirectToAction("HqmIndex");
        }

        // POST: HqmAccountController/Delete/5
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
