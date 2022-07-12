using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BelajaraJoinTable.Context;
using BelajaraJoinTable.Models;
using BelajaraJoinTable.Repository;

public class SiswasController : Controller
{
    //private readonly SispelDbContext _context;
    private readonly ISiswaRepository _siswaRepository;
    public SiswasController(/*SispelDbContext context,*/ SiswaRepository siswaRepository)
    {
        //_context = context;
        _siswaRepository = siswaRepository;
    }


    // GET: Siswas
    public async Task<IActionResult> Index()
    {
        List<Siswa> siswa = new List<Siswa>();
        siswa =  await _siswaRepository.GetAll();
        return View(siswa);
        //return _context.Siswa != null ?
        //            View(await _context.Siswa.ToListAsync()) :
        //            Problem("Entity set 'SispelDbContext.Siswa'  is null.");
    }

    // GET: Siswas/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        //if (id == null || _context.Siswa == null)
        //{
        //    return NotFound();
        //}

        //var siswa = await _context.Siswa
        //    .FirstOrDefaultAsync(m => m.IdSiswa == id);

        var siswa = await _siswaRepository.FindByID(id);

        if (siswa == null)
        {
            return NotFound();
        }

        return View(siswa);
    }

    // GET: Siswas/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Siswas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdSiswa,Nama,JenisKelamin,TanggalLahir,TinggiBadan,NomorHandphone,Alamat,GolonganDarah,Hobi")] Siswa siswa)
    {
        //if (ModelState.IsValid)
        //{
        //    _context.Add(siswa);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        if (ModelState.IsValid)
        {
           await _siswaRepository.Save(siswa);
        }
        return View(siswa);
    }

    // GET: Siswas/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        //if (id == null || _context.Siswa == null)
        //{
        //    return NotFound();
        //}

        //var siswa = await _context.Siswa.FindAsync(id);
        var siswa = await _siswaRepository.FindByID(id);
        if (siswa == null)
        {
            return NotFound();
        }
        return View(siswa);
    }

    // POST: Siswas/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdSiswa,Nama,JenisKelamin,TanggalLahir,TinggiBadan,NomorHandphone,Alamat,GolonganDarah,Hobi")] Siswa siswa)
    {
        if (id != siswa.IdSiswa)
        {
            return NotFound();
        }


        if (ModelState.IsValid)
        {
            try
            {
               await _siswaRepository.Update(id, siswa);
                //_context.Update(siswa);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiswaExists(siswa.IdSiswa))
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
        return View(siswa);
    }

    // GET: Siswas/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        //if (id == null || _context.Siswa == null)
        //{
        //    return NotFound();
        //}

        //var siswa = await _context.Siswa
        //    .FirstOrDefaultAsync(m => m.IdSiswa == id);
        var siswa = await _siswaRepository.FindByID(id);
        if (siswa == null)
        {
            return NotFound();
        }

        return View(siswa);
    }

    // POST: Siswas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        //if (_context.Siswa == null)
        //{
        //    return Problem("Entity set 'SispelDbContext.Siswa'  is null.");
        //}
        var siswa = await _siswaRepository.FindByID(id);
        if (siswa != null)
        {
            //    _context.Siswa.Remove(siswa);
            //}

            //await _context.SaveChangesAsync();
            await _siswaRepository.Delete(siswa);
        }
        return RedirectToAction(nameof(Index));
    }

    private bool SiswaExists(int id)
    {
        //return (_context.Siswa?.Any(e => e.IdSiswa == id)).GetValueOrDefault();
        var siswa = _siswaRepository.FindByID(id);
        if (siswa != null)
        { return true; }
        else 
        { return false; }
    }
}