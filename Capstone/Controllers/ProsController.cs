using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class ProsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pros.Include(p => p.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Pros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pros = await _context.Pros
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProId == id);
            if (pros == null)
            {
                return NotFound();
            }

            return View(pros);
        }

        // GET: Pros/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Pros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProId,ApplicationUserId,Date,ProEntry")] Pros pros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", pros.ApplicationUserId);
            return View(pros);
        }

        // GET: Pros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pros = await _context.Pros.FindAsync(id);
            if (pros == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", pros.ApplicationUserId);
            return View(pros);
        }

        // POST: Pros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProId,ApplicationUserId,Date,ProEntry")] Pros pros)
        {
            if (id != pros.ProId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProsExists(pros.ProId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", pros.ApplicationUserId);
            return View(pros);
        }

        // GET: Pros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pros = await _context.Pros
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProId == id);
            if (pros == null)
            {
                return NotFound();
            }

            return View(pros);
        }

        // POST: Pros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pros = await _context.Pros.FindAsync(id);
            _context.Pros.Remove(pros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProsExists(int id)
        {
            return _context.Pros.Any(e => e.ProId == id);
        }
    }
}
