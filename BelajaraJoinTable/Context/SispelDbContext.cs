using BelajaraJoinTable.Models;
using Microsoft.EntityFrameworkCore;

namespace BelajaraJoinTable.Context
{
    public class SispelDbContext : DbContext
    {
        public SispelDbContext(DbContextOptions<SispelDbContext> options) : base(options)
        { }

        public DbSet<Siswa> Siswa { get; set; }
        public DbSet<Pelajaran> Pelajaran { get; set; }
        public DbSet<SiswaPelajaran> SiswaPelajaran { get; set; }
    }
}
