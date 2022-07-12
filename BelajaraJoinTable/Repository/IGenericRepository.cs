using BelajaraJoinTable.Models;

namespace BelajaraJoinTable.Repository
{
    public interface IGenericRepository : IDisposable
    {
        IEnumerable<SiswaPelajaran> GetStudents();
        Siswa GetStudentByID(int siswa);
        void Insert(SiswaPelajaran siswa);
        void Delete(int siswaID);
        void Update(SiswaPelajaran siswa);
        void Save();
    }
}