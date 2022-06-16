using System.ComponentModel.DataAnnotations;

namespace BelajaraJoinTable.Models
{
    public class Pelajaran
    {
        [Key]
        public int IdPelajaran { get; set; }

        public string NamaPelajaran { set; get; }
    }
}
