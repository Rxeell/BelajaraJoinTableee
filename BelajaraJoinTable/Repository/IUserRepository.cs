using BelajaraJoinTable.Context;
using BelajaraJoinTable.Models;
using Microsoft.EntityFrameworkCore;

namespace BelajaraJoinTable.Repository
{
    public class IUserRepository
    {
        private SispelDbContext context;

        public IUserRepository(SispelDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SiswaPelajaran> GetStudents()
        {
            return context.SiswaPelajaran.ToList();
        }

        public SiswaPelajaran GetSiswaByID(int id)
        {
            return context.SiswaPelajaran.Find(id);
        }

        public void InsertStudent(SiswaPelajaran siswa)
        {
            context.SiswaPelajaran.Add(siswa);
        }

        public void DeleteStudent(int SiswaID)
        {
            SiswaPelajaran siswa = context.SiswaPelajaran.Find(SiswaID);
            context.SiswaPelajaran.Remove(SiswaPelajaran);
        }

        public void UpdateStudent(SiswaPelajaran siswa)
        {
            context.Entry(SiswaPelajaran).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

//        Siswa IGenericRepository.GetStudentByID(int siswa)
//        {
//            throw new NotImplementedException();
//        }

//        public void UpdateStudent(SiswaPelajaran siswa)
//        {
//            throw new NotImplementedException();
//        }

//        public void Insert(SiswaPelajaran siswa)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(int siswaID)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(SiswaPelajaran siswa)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
