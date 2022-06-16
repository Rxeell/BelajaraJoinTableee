using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajaraJoinTable.Models
{
    public class SiswaPelajaran
    {
        [Key]
        public int IdSiswaPelajaran { get; set; }

        [ForeignKey("Siswa")]
        public int IdSiswa { get; set; }
        public Siswa Siswa { get; set; }

        [ForeignKey("Pelajaran")]
        public int IdPelajaran { get; set; }
        public Pelajaran Pelajaran { get; set; }
    }
}
