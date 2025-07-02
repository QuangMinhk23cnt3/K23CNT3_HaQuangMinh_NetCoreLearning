using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HqmLesson10EF.Models;

namespace HqmLesson10EF.Controllers
{
    public class HqmPostsController : Controller
    {
        private readonly HqmK23cnt3Leson10DbContext _context;

        public HqmPostsController(HqmK23cnt3Leson10DbContext context)
        {
            _context = context;
        }

        // GET: HqmPosts
        public async Task<IActionResult> HqmIndex()
        {
            return View(await _context.HqmPosts.ToListAsync());
        }

        // GET: HqmPosts/Details/5
        public async Task<IActionResult> HqmDetails(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var hqmPost = await _context.HqmPosts
                .FirstOrDefaultAsync(m => m.HqmId == hqmId);
            if (hqmPost == null)
            {
                return NotFound();
            }

            return View(hqmPost);
        }

        // GET: HqmPosts/HqmCreate
        public IActionResult HqmCreate()
        {
            return View();
        }

        // POST: HqmPosts/HqmCreate
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HqmCreate([Bind("HqmId,HqmTitle,HqmImage,HqmContent,HqmStatus")] HqmPost hqmPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hqmPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HqmIndex));
            }
            return View(hqmPost);
        }

        // GET: HqmPosts/Edit/5
        public async Task<IActionResult> Edit(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var hqmPost = await _context.HqmPosts.FindAsync(hqmId);
            if (hqmPost == null)
            {
                return NotFound();
            }
            return View(hqmPost);
        }

        // POST: HqmPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int hqmId, [Bind("HqmId,HqmTitle,HqmImage,HqmContent,HqmStatus")] HqmPost hqmPost)
        {
            if (hqmId != hqmPost.HqmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hqmPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HqmPostExists(hqmPost.HqmId))
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
            return View(hqmPost);
        }

        // GET: HqmPosts/Delete/5
        public async Task<IActionResult> Delete(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var hqmPost = await _context.HqmPosts
                .FirstOrDefaultAsync(m => m.HqmId == hqmId);
            if (hqmPost == null)
            {
                return NotFound();
            }

            return View(hqmPost);
        }

        // POST: HqmPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int hqmId)
        {
            var hqmPost = await _context.HqmPosts.FindAsync(hqmId);
            if (hqmPost != null)
            {
                _context.HqmPosts.Remove(hqmPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(HqmIndex));
        }

        private bool HqmPostExists(int id)
        {
            return _context.HqmPosts.Any(e => e.HqmId == id);
        }
    }
}
