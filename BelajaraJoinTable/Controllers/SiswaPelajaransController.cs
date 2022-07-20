using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BelajaraJoinTable.Context;
using BelajaraJoinTable.Models;
using BelajaraJoinTable.ViewModel;
using BelajaraJoinTable.Repository;

namespace BelajaraJoinTable.Controllers
{
    public class SiswaPelajaransController : Controller
    {
        //private readonly SispelDbContext _context;
        private readonly ISiswaPelajaranRepository _siswapelajaranRepository;
        public SiswaPelajaransController(ISiswaPelajaranRepository siswapelajaranRepository)
        {
            //_context = context;
            _siswapelajaranRepository = siswapelajaranRepository;
        }

        // GET: SiswaPelajarans
        public async Task<IActionResult> Index()
        {
            List<SiswaPelajaran> siswapelajaran = new List<SiswaPelajaran>();
            siswapelajaran = await _siswapelajaranRepository.IniBaru();
            return View(siswapelajaran);
            //var sispelDbContext = _context.SiswaPelajaran.Include(s => s.Pelajaran).Include(s => s.Siswa);
            //return View(await sispelDbContext.ToListAsync());
        }

        // GET: SiswaPelajarans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.SiswaPelajaran == null)
            //{
            //    return NotFound();
            //}

            //var SiswaPelajaran = await _context.SiswaPelajaran
            //    .Include(s => s.Pelajaran)
            //    .Include(s => s.Siswa)
            //    .FirstOrDefaultAsync(m => m.IdSiswaPelajaran == id);
            var siswaPelajaran = await _siswapelajaranRepository.FindByID(id);

            if (siswaPelajaran == null)
            {
                return NotFound();
            }

            return View(siswaPelajaran);
        }

        // GET: SiswaPelajarans/Create
        public IActionResult Create()
        {
            //ViewData["IdPelajaran"] = new SelectList(_context.Pelajaran, "IdPelajaran", "NamaPelajaran");
            //ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "Nama");
            return View();
        }

        // POST: SiswaPelajarans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("IdSiswaPelajaran,IdSiswa,IdPelajaran")] SiswaPelajaran siswapelajaran)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(siswaPelajaran);
        //        await _siswapelajaranRepository.Save(siswapelajaran);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdPelajaran"] = new SelectList(_context.Pelajaran, "IdPelajaran", "NamaPelajaran", siswaPelajaran.IdPelajaran);
        //    ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "Alamat", siswaPelajaran.IdSiswa);
        //    return View(siswapelajaran);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSiswaPelajaran,IdSiswa,IdPelajaran")] SiswaPelajaran siswapelajaran)
        {
            if (ModelState.IsValid)
            {
                SiswaPelajaran sp = new SiswaPelajaran();
                sp.IdPelajaran = siswapelajaran.IdPelajaran;
                sp.IdSiswa = siswapelajaran.IdSiswa;

                //_context.Add(siswaPelajaranVM);
                //_context.Add(sp);
                await _siswapelajaranRepository.Save(siswapelajaran);
                //return RedirectToAction(nameof(Index));
            }
            //ViewData["IdPelajaran"] = new SelectList(_context.Pelajaran, "IdPelajaran", "NamaPelajaran", siswaPelajaranVM.IdPelajaran);
            //ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "Nama", siswaPelajaran.IdSiswa);
            return View(siswapelajaran);
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
            var vm = new EditSiswaPelajaranVM();
            vm.IdPelajaran = siswaPelajaran.IdPelajaran;
            vm.IdSiswa = siswaPelajaran.IdSiswa;
            vm.IdSiswaPelajaran = siswaPelajaran.IdSiswaPelajaran;

            ViewData["IdPelajaran"] = new SelectList(_context.Pelajaran, "IdPelajaran", "NamaPelajaran", siswaPelajaran.IdPelajaran);
            ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "Nama", siswaPelajaran.IdSiswa);
            return View(vm);
        }
        // GET: SiswaPelajarans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.SiswaPelajaran == null)
            //{
            //    return NotFound();
            //}

            var siswapelajaran = await _siswapelajaranRepository.FindByID(id);
            if (siswapelajaran == null)
            {
                return NotFound();
            }
            //var vm = new EditSiswaPelajaranVM();
            //vm.IdPelajaran = siswaPelajaran.IdPelajaran;
            //vm.IdSiswa = siswaPelajaran.IdSiswa;
            //vm.IdSiswaPelajaran = siswaPelajaran.IdSiswaPelajaran;

            //ViewData["IdPelajaran"] = new SelectList(_siswapelajaranRepository.Pelajaran, "IdPelajaran", "NamaPelajaran", siswapelajaran.IdPelajaran);
            //ViewData["IdSiswa"] = new SelectList(_siswapelajaranRepository.Siswa, "IdSiswa", "Nama", siswapelajaran.IdSiswa);
            return View(siswapelajaran);
        }

        // POST: SiswaPelajarans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSiswaPelajaran,IdSiswa,IdPelajaran")] SiswaPelajaran siswapelajaran)
        {
            if (id != siswapelajaran.IdSiswaPelajaran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _siswapelajaranRepository.Update(id, siswapelajaran);
                    //SiswaPelajaran vm = new SiswaPelajaran();
                    //vm.IdSiswaPelajaran = siswaPelajaranvm.IdSiswaPelajaran;
                    //vm.IdSiswa = siswaPelajaranvm.IdSiswa;
                    //vm.IdPelajaran = siswaPelajaranvm.IdPelajaran;

                    //_context.Update(vm);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiswaPelajaranExists(siswapelajaran.IdSiswaPelajaran))
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
            //ViewData["IdPelajaran"] = new SelectList(_siswapelajaran.Pelajaran, "IdPelajaran", "NamaPelajaran", siswaPelajaranvm.IdPelajaran);
            //ViewData["IdSiswa"] = new SelectList(_siswapelajaran.Siswa, "IdSiswa", "Nama", siswaPelajaranvm.IdSiswa);
            return View(siswapelajaran);
        }

        // GET: SiswaPelajarans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.SiswaPelajaran == null)
            //{
            //    return NotFound();
            //}

            //var siswaPelajaran = await _context.SiswaPelajaran
            //    .Include(s => s.Pelajaran)
            //    .Include(s => s.Siswa)
            //    .FirstOrDefaultAsync(m => m.IdSiswaPelajaran == id);
            var siswapelajaran = await _siswapelajaranRepository.FindByID(id);
            if (siswapelajaran == null)
            {
                return NotFound();
            }

            return View(siswapelajaran);
        }

        // POST: SiswaPelajarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.SiswaPelajaran == null)
            //{
            //    return Problem("Entity set 'SispelDbContext.SiswaPelajaran'  is null.");
            //}
            var siswapelajaran = await _siswapelajaranRepository.FindByID(id);
            if (siswapelajaran != null)
            {
                //_context.SiswaPelajaran.Remove(siswaPelajaran);

                await _siswapelajaranRepository.Delete(siswapelajaran);
            }
            
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiswaPelajaranExists(int id)
        {
            //return (_context.SiswaPelajaran?.Any(e => e.IdSiswaPelajaran == id)).GetValueOrDefault();
            var siswaPelajaran = _siswapelajaranRepository.FindByID(id);
            if (siswaPelajaran != null)
            { return true; }
            else 
            { return false; }  
        }
    }
}
