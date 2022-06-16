using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelajaraJoinTable.Migrations
{
    public partial class BljrJoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pelajaran",
                columns: table => new
                {
                    IdPelajaran = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaPelajaran = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelajaran", x => x.IdPelajaran);
                });

            migrationBuilder.CreateTable(
                name: "Siswa",
                columns: table => new
                {
                    IdSiswa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinggiBadan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorHandphone = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GolonganDarah = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Hobi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siswa", x => x.IdSiswa);
                });

            migrationBuilder.CreateTable(
                name: "SiswaPelajaran",
                columns: table => new
                {
                    IdSiswaPelajaran = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSiswa = table.Column<int>(type: "int", nullable: false),
                    IdPelajaran = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiswaPelajaran", x => x.IdSiswaPelajaran);
                    table.ForeignKey(
                        name: "FK_SiswaPelajaran_Pelajaran_IdPelajaran",
                        column: x => x.IdPelajaran,
                        principalTable: "Pelajaran",
                        principalColumn: "IdPelajaran",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiswaPelajaran_Siswa_IdSiswa",
                        column: x => x.IdSiswa,
                        principalTable: "Siswa",
                        principalColumn: "IdSiswa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiswaPelajaran_IdPelajaran",
                table: "SiswaPelajaran",
                column: "IdPelajaran");

            migrationBuilder.CreateIndex(
                name: "IX_SiswaPelajaran_IdSiswa",
                table: "SiswaPelajaran",
                column: "IdSiswa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiswaPelajaran");

            migrationBuilder.DropTable(
                name: "Pelajaran");

            migrationBuilder.DropTable(
                name: "Siswa");
        }
    }
}
