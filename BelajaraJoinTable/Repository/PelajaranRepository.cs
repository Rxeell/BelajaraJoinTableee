using BelajaraJoinTable.Context;
using BelajaraJoinTable.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelajaraJoinTable.Repository
{
    public class PelajaranRepository : IPelajaranRepository
    {
        private readonly SispelDbContext _context;

        public PelajaranRepository(SispelDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pelajaran>> GetAll()
        {
            return await _context.Pelajaran.ToListAsync();
        }
        public async Task<Pelajaran> FindByID(int? id)
        {
            return await _context.Pelajaran
            .FirstOrDefaultAsync(m => m.IdPelajaran == id);
        }
        public async Task Save(Pelajaran pelajaran)
        {
            await _context.AddAsync(pelajaran);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, Pelajaran pelajaran)
        {
            _context.Update(pelajaran);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Pelajaran pelajaran)
        {
            _context.Pelajaran.Remove(pelajaran);
            await _context.SaveChangesAsync();
        }

    }
}
