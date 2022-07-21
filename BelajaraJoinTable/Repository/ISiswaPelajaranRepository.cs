using BelajaraJoinTable.Models;
using System.Collections;

namespace BelajaraJoinTable.Repository
{
    public interface ISiswaPelajaranRepository
    {
        IEnumerable Pelajaran { get; }
        IEnumerable Siswa { get; }

        Task<List<SiswaPelajaran>> GetAll();

        Task<List<SiswaPelajaran>> IniBaru();

        Task<SiswaPelajaran> FindByID(int? id);

        Task Save(SiswaPelajaran siswapelajaran);

        Task Update(int id, SiswaPelajaran siswapelajaran);

        Task Delete(SiswaPelajaran siswapelajaran);
    }
}