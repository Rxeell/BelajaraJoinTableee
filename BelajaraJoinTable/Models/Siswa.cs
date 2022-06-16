using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajaraJoinTable.Models
{
    public class Siswa
    {
        [Key]
        public int IdSiswa { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Nama { get; set; }

        [DisplayName("Jenis Kelamin")]
        [Required]
        public string JenisKelamin { get; set; }

        [DisplayName("Tanggal Lahir")]
        [Required]
        public DateTime TanggalLahir { get; set; }

        [DisplayName("Tinggi Badan")]
        [Required]
        public string TinggiBadan { get; set; }

        [Column(TypeName = "nvarchar(12)")]

        [DisplayName("Nomor Handphone")]
        [Required]
        public string NomorHandphone { get; set; }

        [Required]
        public string Alamat { get; set; }

        [Column(TypeName = "nvarchar(1)")]
        [Required]
        [DisplayName("Golongan Darah")]
        public string GolonganDarah { get; set; }

        public string Hobi { get; set; }
    }
}
