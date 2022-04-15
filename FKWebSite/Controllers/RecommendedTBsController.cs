using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FKWebSite.Models;

namespace FKWebSite.Controllers
{
    public class RecommendedTBsController : Controller
    {
        private readonly FKContext _context;

        public RecommendedTBsController(FKContext context)
        {
            _context = context;
        }

        // GET: RecommendedTBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecommendedTBs.ToListAsync());
        }

        // GET: RecommendedTBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendedTB = await _context.RecommendedTBs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recommendedTB == null)
            {
                return NotFound();
            }

            return View(recommendedTB);
        }

        // GET: RecommendedTBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecommendedTBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Link")] RecommendedTB recommendedTB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recommendedTB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recommendedTB);
        }

        // GET: RecommendedTBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendedTB = await _context.RecommendedTBs.FindAsync(id);
            if (recommendedTB == null)
            {
                return NotFound();
            }
            return View(recommendedTB);
        }

        // POST: RecommendedTBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Link")] RecommendedTB recommendedTB)
        {
            if (id != recommendedTB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recommendedTB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecommendedTBExists(recommendedTB.Id))
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
            return View(recommendedTB);
        }

        // GET: RecommendedTBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendedTB = await _context.RecommendedTBs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recommendedTB == null)
            {
                return NotFound();
            }

            return View(recommendedTB);
        }

        // POST: RecommendedTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recommendedTB = await _context.RecommendedTBs.FindAsync(id);
            _context.RecommendedTBs.Remove(recommendedTB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecommendedTBExists(int id)
        {
            return _context.RecommendedTBs.Any(e => e.Id == id);
        }
    }
}
