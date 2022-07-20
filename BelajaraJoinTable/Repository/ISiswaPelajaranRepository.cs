using BelajaraJoinTable.Models;

namespace BelajaraJoinTable.Repository
{
    public interface ISiswaPelajaranRepository
    {
        Task<List<SiswaPelajaran>> GetAll();

        Task<List<SiswaPelajaran>> IniBaru();

        Task<SiswaPelajaran> FindByID(int? id);

        Task Save(SiswaPelajaran siswaPelajaran);

        Task Update(int id, SiswaPelajaran siswaPelajaran);

        Task Delete(SiswaPelajaran siswaPelajaran);
    }
}