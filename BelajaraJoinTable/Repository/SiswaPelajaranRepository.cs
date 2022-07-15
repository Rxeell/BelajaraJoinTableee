using BelajaraJoinTable.Context;
using BelajaraJoinTable.Models;
using Microsoft.EntityFrameworkCore;

namespace BelajaraJoinTable.Repository
{
    public class SiswaPelajaranRepository : ISiswaPelajaranRepository
    {
        private readonly SispelDbContext _context;

        public SiswaPelajaranRepository(SispelDbContext context)
        {
            _context = context;
        }
        public async Task<List<SiswaPelajaran>> GetAll()
        {
            return await _context.SiswaPelajaran.ToListAsync();
        }
        public async Task<SiswaPelajaran> FindByID(int? id)
        {
            return await _context.SiswaPelajaran
            .FirstOrDefaultAsync(m => m.IdSiswaPelajaran == id);
        }
        public async Task Save(SiswaPelajaran siswaPelajaran)
        {
            await _context.AddAsync(siswaPelajaran);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, SiswaPelajaran siswaPelajaran)
        {
            _context.Update(siswaPelajaran);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(SiswaPelajaran siswaPelajaran)
        {
            _context.SiswaPelajaran.Remove(siswaPelajaran);
            await _context.SaveChangesAsync();
        }

        Task ISiswaPelajaranRepository.FindByID(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
