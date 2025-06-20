using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HqmLesson09EF.Models;

namespace HqmLesson09EF.Controllers
{
    public class HqmCategoriesController : Controller
    {
        private readonly HqmBookStoreContext _context;

        public HqmCategoriesController(HqmBookStoreContext context)
        {
            _context = context;
        }

        // GET: HqmCategories
        public async Task<IActionResult> HqmIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: HqmCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: HqmCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HqmCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HqmIndex));
            }
            return View(category);
        }

        // GET: HqmCategories/Edit/5
        public async Task<IActionResult> Edit(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(hqmId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: HqmCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int hqmId, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (hqmId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        // GET: HqmCategories/Delete/5
        public async Task<IActionResult> Delete(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == hqmId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: HqmCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int hqmId)
        {
            var category = await _context.Categories.FindAsync(hqmId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(HqmIndex));
        }

        private bool CategoryExists(int hqmId)
        {
            return _context.Categories.Any(e => e.CategoryId == hqmId);
        }
    }
}
