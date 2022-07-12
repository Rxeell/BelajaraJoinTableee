﻿using BelajaraJoinTable.Context;
using BelajaraJoinTable.Models;
using Microsoft.EntityFrameworkCore;

namespace BelajaraJoinTable.Repository
{
    public class SiswaRepository : ISiswaRepository
    {
        private readonly SispelDbContext _context;

        public SiswaRepository(SispelDbContext context)
        {
            _context = context;
        }
        public async Task<List<Siswa>> GetAll()
        {
            return await _context.Siswa.ToListAsync();
        }
        public async Task<Siswa> FindByID(int? id)
        {
            return await _context.Siswa
            .FirstOrDefaultAsync(m => m.IdSiswa == id);
        }
        public async Task Save(Siswa siswa)
        {
            await _context.AddAsync(siswa);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, Siswa siswa)
        {
            _context.Update(siswa);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Siswa siswa)
        {
            _context.Siswa.Remove(siswa);
            await _context.SaveChangesAsync();
        }
    }
}
