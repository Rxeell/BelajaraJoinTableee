using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BelajaraJoinTable.Context;
using BelajaraJoinTable.Models;

namespace BelajaraJoinTable.Controllers
{
    public class PelajaransController : Controller
    {
        private readonly SispelDbContext _context;

        public PelajaransController(SispelDbContext context)
        {
            _context = context;
        }

        // GET: Pelajarans
        public async Task<IActionResult> Index()
        {
              return _context.Pelajaran != null ? 
                          View(await _context.Pelajaran.ToListAsync()) :
                          Problem("Entity set 'SispelDbContext.Pelajaran'  is null.");
        }

        // GET: Pelajarans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pelajaran == null)
            {
                return NotFound();
            }

            var pelajaran = await _context.Pelajaran
                .FirstOrDefaultAsync(m => m.IdPelajaran == id);
            if (pelajaran == null)
            {
                return NotFound();
            }

            return View(pelajaran);
        }

        // GET: Pelajarans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pelajarans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPelajaran,NamaPelajaran")] Pelajaran pelajaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelajaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pelajaran);
        }

        // GET: Pelajarans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pelajaran == null)
            {
                return NotFound();
            }

            var pelajaran = await _context.Pelajaran.FindAsync(id);
            if (pelajaran == null)
            {
                return NotFound();
            }
            return View(pelajaran);
        }

        // POST: Pelajarans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPelajaran,NamaPelajaran")] Pelajaran pelajaran)
        {
            if (id != pelajaran.IdPelajaran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelajaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PelajaranExists(pelajaran.IdPelajaran))
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
            return View(pelajaran);
        }

        // GET: Pelajarans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pelajaran == null)
            {
                return NotFound();
            }

            var pelajaran = await _context.Pelajaran
                .FirstOrDefaultAsync(m => m.IdPelajaran == id);
            if (pelajaran == null)
            {
                return NotFound();
            }

            return View(pelajaran);
        }

        // POST: Pelajarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pelajaran == null)
            {
                return Problem("Entity set 'SispelDbContext.Pelajaran'  is null.");
            }
            var pelajaran = await _context.Pelajaran.FindAsync(id);
            if (pelajaran != null)
            {
                _context.Pelajaran.Remove(pelajaran);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PelajaranExists(int id)
        {
          return (_context.Pelajaran?.Any(e => e.IdPelajaran == id)).GetValueOrDefault();
        }
    }
}
