using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HaQuangMinh_2310900067.Models;

namespace HaQuangMinh_2310900067.Controllers
{
    public class HqmEmployeeesController : Controller
    {
        private readonly HaQuangMinh2310900067Context _context;

        public HqmEmployeeesController(HaQuangMinh2310900067Context context)
        {
            _context = context;
        }

        // GET: HqmEmployeees
        public async Task<IActionResult> HqmIndex()
        {
            return View(await _context.HqmEmployeees.ToListAsync());
        }

        // GET: HqmEmployeees/Details/5
        public async Task<IActionResult> HqmDetails(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var hqmEmployeee = await _context.HqmEmployeees
                .FirstOrDefaultAsync(m => m.HqmEmpId == hqmId);
            if (hqmEmployeee == null)
            {
                return NotFound();
            }

            return View(hqmEmployeee);
        }

        // GET: HqmEmployeees/Create
        public IActionResult HqmCreate()
        {
            return View();
        }

        // POST: HqmEmployeees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HqmCreate([Bind("HqmEmpId,HqmEmpName,HqmEmpLevel,HqmEmpStartDate,HqmEmpStatus")] HqmEmployeee hqmEmployeee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hqmEmployeee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HqmIndex));
            }
            return View(hqmEmployeee);
        }

        // GET: HqmEmployeees/Edit/5
        public async Task<IActionResult> HqmEdit(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var hqmEmployeee = await _context.HqmEmployeees.FindAsync(hqmId);
            if (hqmEmployeee == null)
            {
                return NotFound();
            }
            return View(hqmEmployeee);
        }

        // POST: HqmEmployeees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HqmEdit(int hqmId, [Bind("HqmEmpId,HqmEmpName,HqmEmpLevel,HqmEmpStartDate,HqmEmpStatus")] HqmEmployeee hqmEmployeee)
        {
            if (hqmId != hqmEmployeee.HqmEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hqmEmployeee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HqmEmployeeeExists(hqmEmployeee.HqmEmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(HqmIndex));
            }
            return View(hqmEmployeee);
        }

        // GET: HqmEmployeees/Delete/5
        public async Task<IActionResult> HqmDelete(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var hqmEmployeee = await _context.HqmEmployeees
                .FirstOrDefaultAsync(m => m.HqmEmpId == hqmId);
            if (hqmEmployeee == null)
            {
                return NotFound();
            }

            return View(hqmEmployeee);
        }

        // POST: HqmEmployeees/Delete/5
        [HttpPost, ActionName("HqmDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int hqmId)
        {
            var hqmEmployeee = await _context.HqmEmployeees.FindAsync(hqmId);
            if (hqmEmployeee != null)
            {
                _context.HqmEmployeees.Remove(hqmEmployeee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(HqmIndex));
        }

        private bool HqmEmployeeeExists(int hqmId)
        {
            return _context.HqmEmployeees.Any(e => e.HqmEmpId == hqmId);
        }
    }
}
