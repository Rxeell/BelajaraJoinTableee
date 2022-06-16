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
    public class SiswaPelajaransController : Controller
    {
        private readonly SispelDbContext _context;

        public SiswaPelajaransController(SispelDbContext context)
        {
            _context = context;
        }

        // GET: SiswaPelajarans
        public async Task<IActionResult> Index()
        {
            var sispelDbContext = _context.SiswaPelajaran.Include(s => s.Pelajaran).Include(s => s.Siswa);
            return View(await sispelDbContext.ToListAsync());
        }

        // GET: SiswaPelajarans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SiswaPelajaran == null)
            {
                return NotFound();
            }

            var siswaPelajaran = await _context.SiswaPelajaran
                .Include(s => s.Pelajaran)
                .Include(s => s.Siswa)
                .FirstOrDefaultAsync(m => m.IdSiswaPelajaran == id);
            if (siswaPelajaran == null)
            {
                return NotFound();
            }

            return View(siswaPelajaran);
        }

        // GET: SiswaPelajarans/Create
        public IActionResult Create()
        {
            ViewData["IdPelajaran"] = new SelectList(_context.Pelajaran, "IdPelajaran", "IdPelajaran");
            ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "Alamat");
            return View();
        }

        // POST: SiswaPelajarans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSiswaPelajaran,IdSiswa,IdPelajaran")] SiswaPelajaran siswaPelajaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siswaPelajaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPelajaran"] = new SelectList(_context.Pelajaran, "IdPelajaran", "IdPelajaran", siswaPelajaran.IdPelajaran);
            ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "Alamat", siswaPelajaran.IdSiswa);
            return View(siswaPelajaran);
        }

        // GET: SiswaPelajarans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SiswaPelajaran == null)
            {
                return NotFound();
            }

            var siswaPelajaran = await _context.SiswaPelajaran.FindAsync(id);
            if (siswaPelajaran == null)
            {
                return NotFound();
            }
            ViewData["IdPelajaran"] = new SelectList(_context.Pelajaran, "IdPelajaran", "IdPelajaran", siswaPelajaran.IdPelajaran);
            ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "Alamat", siswaPelajaran.IdSiswa);
            return View(siswaPelajaran);
        }

        // POST: SiswaPelajarans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSiswaPelajaran,IdSiswa,IdPelajaran")] SiswaPelajaran siswaPelajaran)
        {
            if (id != siswaPelajaran.IdSiswaPelajaran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siswaPelajaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiswaPelajaranExists(siswaPelajaran.IdSiswaPelajaran))
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
            ViewData["IdPelajaran"] = new SelectList(_context.Pelajaran, "IdPelajaran", "IdPelajaran", siswaPelajaran.IdPelajaran);
            ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "Alamat", siswaPelajaran.IdSiswa);
            return View(siswaPelajaran);
        }

        // GET: SiswaPelajarans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SiswaPelajaran == null)
            {
                return NotFound();
            }

            var siswaPelajaran = await _context.SiswaPelajaran
                .Include(s => s.Pelajaran)
                .Include(s => s.Siswa)
                .FirstOrDefaultAsync(m => m.IdSiswaPelajaran == id);
            if (siswaPelajaran == null)
            {
                return NotFound();
            }

            return View(siswaPelajaran);
        }

        // POST: SiswaPelajarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SiswaPelajaran == null)
            {
                return Problem("Entity set 'SispelDbContext.SiswaPelajaran'  is null.");
            }
            var siswaPelajaran = await _context.SiswaPelajaran.FindAsync(id);
            if (siswaPelajaran != null)
            {
                _context.SiswaPelajaran.Remove(siswaPelajaran);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiswaPelajaranExists(int id)
        {
          return (_context.SiswaPelajaran?.Any(e => e.IdSiswaPelajaran == id)).GetValueOrDefault();
        }
    }
}
