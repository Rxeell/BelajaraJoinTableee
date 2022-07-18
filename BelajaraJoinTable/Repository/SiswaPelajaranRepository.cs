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
        public async Task Save(SiswaPelajaran siswapelajaran)
        {
            await _context.AddAsync(siswapelajaran);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, SiswaPelajaran siswapelajaran)
        {
            _context.Update(siswapelajaran);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(SiswaPelajaran siswapelajaran)
        {
            _context.SiswaPelajaran.Remove(siswapelajaran);
            await _context.SaveChangesAsync();
        }

        //Task ISiswaPelajaranRepository.FindByID(int? id)
        //{
        //    throw new NotImplementedException();
        
    }
}
