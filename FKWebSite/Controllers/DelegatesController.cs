using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FKWebSite.Models;
using Delegate = FKWebSite.Models.Delegate;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FKWebSite.Controllers
{
    public class DelegatesController : Controller
    {
        private readonly FKContext _context;
        private IHostingEnvironment host;

        public DelegatesController(FKContext context, IHostingEnvironment hostEnv)
        {
            _context = context;
            host = hostEnv;
        }

        // GET: Delegates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Delegates.ToListAsync());
        }

        // GET: Delegates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @delegate = await _context.Delegates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@delegate == null)
            {
                return NotFound();
            }

            return View(@delegate);
        }

        // GET: Delegates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Delegates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Delegate @delegate)
        {
            if (ModelState.IsValid)
            {
                uploadphoto(@delegate);
                _context.Add(@delegate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@delegate);
        }

        // GET: Delegates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @delegate = await _context.Delegates.FindAsync(id);
            if (@delegate == null)
            {
                return NotFound();
            }
            return View(@delegate);
        }

        // POST: Delegates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Delegate @delegate)
        {
            if (id != @delegate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    uploadphoto(@delegate);
                    _context.Update(@delegate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DelegateExists(@delegate.Id))
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
            return View(@delegate);
        }

        // GET: Delegates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @delegate = await _context.Delegates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@delegate == null)
            {
                return NotFound();
            }

            return View(@delegate);
        }

        // POST: Delegates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @delegate = await _context.Delegates.FindAsync(id);
            _context.Delegates.Remove(@delegate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DelegateExists(int id)
        {
            return _context.Delegates.Any(e => e.Id == id);
        }

        void uploadphoto(Delegate model)
        {
            if (model.File !=null)
            {
                string uploadsFolder = Path.Combine(host.WebRootPath, "Img/Delegates");
                string uniqueFileName = new Guid() + ".jpeg";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.File.CopyTo(fileStream);
                }
                model.Image = uniqueFileName; 
            }
        }

    }
}
