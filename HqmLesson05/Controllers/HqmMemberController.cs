using HqmLesson05.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace HqmLesson05.Controllers
{
    public class HqmMemberController : Controller
    {
        private static List<HqmMember> hqmListMember = new List<HqmMember>()
        {
            new HqmMember
            {
                HqmMemberId = "2310900067",
                HqmUserName = "QuangMinh",
                HqmPassword = "123456@",
                HqmFullName = "Ha Quang Minh",
                HqmEmail = "haquangminhk23cnt3@gmail.com"
            },
            new HqmMember
            {
                HqmMemberId = "2",
                HqmUserName = "jane_smith",
                HqmPassword = "pass456",
                HqmFullName = "Jane Smith",
                HqmEmail = "jane@example.com"
            },
            new HqmMember
            {
                HqmMemberId = "3",
                HqmUserName = "alice_nguyen",
                HqmPassword = "alice789",
                HqmFullName = "Alice Nguyen",
                HqmEmail = "alice@example.com"
            },
            new HqmMember
            {
                HqmMemberId = "4",
                HqmUserName = "bob_tran",
                HqmPassword = "bob321",
                HqmFullName = "Bob Tran",
                HqmEmail = "bob@example.com"
            },
            new HqmMember
            {
                HqmMemberId = "5",
                HqmUserName = "charlie_le",
                HqmPassword = "charlie000",
                HqmFullName = "Charlie Le",
                HqmEmail = "charlie@example.com"
            }
        };
        public IActionResult HqmIndex() // hien thi list member
        {
            return View(hqmListMember);
        }
    }
}
