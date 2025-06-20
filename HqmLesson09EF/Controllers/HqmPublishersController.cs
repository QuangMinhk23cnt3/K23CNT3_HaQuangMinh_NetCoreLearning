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
    public class HqmPublishersController : Controller
    {
        private readonly HqmBookStoreContext _context;

        public HqmPublishersController(HqmBookStoreContext context)
        {
            _context = context;
        }

        // GET: HqmPublishers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Publishers.ToListAsync());
        }

        // GET: HqmPublishers/Details/5
        public async Task<IActionResult> Details(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == hqmId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: HqmPublishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HqmPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: HqmPublishers/Edit/5
        public async Task<IActionResult> Edit(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(hqmId);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: HqmPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int hqmId, [Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (hqmId != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: HqmPublishers/Delete/5
        public async Task<IActionResult> Delete(int? hqmId)
        {
            if (hqmId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == hqmId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: HqmPublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int hqmId)
        {
            var publisher = await _context.Publishers.FindAsync(hqmId);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(int hqmId)
        {
            return _context.Publishers.Any(e => e.PublisherId == hqmId);
        }
    }
}
