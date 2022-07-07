using BelajaraJoinTable.Context;
using BelajaraJoinTable.Models;
using Microsoft.EntityFrameworkCore;

namespace BelajaraJoinTable.Repository
{
    public class IUserRepository<T> : IGenericRepository<user>
    {
        private readonly SispelDbContext context;

        public DbSet<T> dbSet;
        public async Task<IEnumerable<SiswaPelajaran>> All()
        {
            return await context.SiswaPelajaran.
        }

        public Task<SiswaPelajaran> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SiswaPelajaran> Insert(SispelDbContext entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
