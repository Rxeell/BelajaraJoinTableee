using BelajaraJoinTable.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelajaraJoinTable.Repository
{
    public interface IPelajaranRepository
    {
        Task<List<Pelajaran>> GetAll();

        Task<Pelajaran> FindByID(int? id);

        Task Save(Pelajaran pelajaran);

        Task Update(int id, Pelajaran pelajaran);

        Task Delete(Pelajaran pelajaran);
    }
}
