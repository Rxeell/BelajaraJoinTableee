using BelajaraJoinTable.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelajaraJoinTable.Repository
{
    public interface ISiswaRepository
    {
        Task <List<Siswa>> GetAll();

        Task<Siswa> FindByID(int? id);

        Task Save(Siswa siswa);

        Task Update(int id, Siswa siswa);

        Task Delete(Siswa siswa);
    }
}
