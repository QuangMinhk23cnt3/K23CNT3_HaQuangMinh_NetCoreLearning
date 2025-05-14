using HqmLesson04.Models;
using Microsoft.AspNetCore.Mvc;

namespace HqmLesson04.Controllers
{
    public class HqmBookController : Controller
    {
        private List<HqmBook> hqmBooks = new List<HqmBook>
        {
            new HqmBook
            {
                HqmId = "B001",
                HqmTitle = "C# Căn Bản",
                HqmDescription = "Cuốn sách giúp bạn làm quen với lập trình C# từ đầu.",
                HqmImage = "images/book-1.jpg",
                HqmPrice = 9.99f,
                HqmPage = 250
            },
            new HqmBook
            {
                HqmId = "B002",
                HqmTitle = "ASP.NET Core Toàn Tập",
                HqmDescription = "Hướng dẫn chi tiết phát triển ứng dụng web với ASP.NET Core.",
                HqmImage = "images/book-2.jpg",
                HqmPrice = 14.50f,
                HqmPage = 400
            },
            new HqmBook
            {
                HqmId = "B003",
                HqmTitle = "Lập Trình Hướng Đối Tượng",
                HqmDescription = "Hiểu rõ về nguyên lý và ứng dụng của OOP trong C#.",
                HqmImage = "images/book-3.jpg",
                HqmPrice = 12.00f,
                HqmPage = 320
            },
            new HqmBook
            {
                HqmId = "B004",
                HqmTitle = "Entity Framework Cơ Bản",
                HqmDescription = "Tìm hiểu cách làm việc với cơ sở dữ liệu sử dụng Entity Framework.",
                HqmImage = "images/book-4.jpg",
                HqmPrice = 11.25f,
                HqmPage = 280
            },
            new HqmBook
            {
                HqmId = "B005",
                HqmTitle = "Design Patterns Trong C#",
                HqmDescription = "Áp dụng các mẫu thiết kế phần mềm phổ biến vào C#.",
                HqmImage = "images/book-5.jpg",
                HqmPrice = 16.75f,
                HqmPage = 450
            }
        };
        // GET: /HqmBook/HqmIndex => Lay tat ca cac cuon sach
        public IActionResult HqmIndex()
        {
            // dua du lieu len view
            return View(hqmBooks);
        }

        // GET: /HqmBook/HqmCreate
        public IActionResult HqmCreate()
        {
            HqmBook hqmBook = new HqmBook();
            return View(hqmBook);
        }

        // POST: /HqmBook/HqmCreateSubmit
        public IActionResult HqmCreateSubmit()
        {
            //...
            return RedirectToAction("HqmIndex");
        }

        public IActionResult HqmEdit(string id)
        {
            return View();
        }

        // POST: /HqmBook/HqmEditSubmit
        public IActionResult HqmEditSubmit()
        {
            //...
            return RedirectToAction("HqmIndex");
        }
    }
}
