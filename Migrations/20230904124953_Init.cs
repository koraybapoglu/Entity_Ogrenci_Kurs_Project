using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Ogrenci_Kurs_Project.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    OgrenciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgrenciSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgrenciDogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OgrenciEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.OgrenciID);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    OgretmenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgretmenSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgretmenDogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OgretmenEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.OgretmenID);
                });

            migrationBuilder.CreateTable(
                name: "Ders",
                columns: table => new
                {
                    DersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DersAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcilisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OgretmenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ders", x => x.DersID);
                    table.ForeignKey(
                        name: "FK_Ders_Ogretmenler_OgretmenID",
                        column: x => x.OgretmenID,
                        principalTable: "Ogretmenler",
                        principalColumn: "OgretmenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kurslar",
                columns: table => new
                {
                    KursID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OgretmenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurslar", x => x.KursID);
                    table.ForeignKey(
                        name: "FK_Kurslar_Ogretmenler_OgretmenID",
                        column: x => x.OgretmenID,
                        principalTable: "Ogretmenler",
                        principalColumn: "OgretmenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenci_Kurslar",
                columns: table => new
                {
                    OgrenciKursID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciID = table.Column<int>(type: "int", nullable: false),
                    KursID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenci_Kurslar", x => x.OgrenciKursID);
                    table.ForeignKey(
                        name: "FK_Ogrenci_Kurslar_Kurslar_KursID",
                        column: x => x.KursID,
                        principalTable: "Kurslar",
                        principalColumn: "KursID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ogrenci_Kurslar_Ogrenciler_OgrenciID",
                        column: x => x.OgrenciID,
                        principalTable: "Ogrenciler",
                        principalColumn: "OgrenciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ders_OgretmenID",
                table: "Ders",
                column: "OgretmenID");

            migrationBuilder.CreateIndex(
                name: "IX_Kurslar_OgretmenID",
                table: "Kurslar",
                column: "OgretmenID");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenci_Kurslar_KursID",
                table: "Ogrenci_Kurslar",
                column: "KursID");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenci_Kurslar_OgrenciID",
                table: "Ogrenci_Kurslar",
                column: "OgrenciID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ders");

            migrationBuilder.DropTable(
                name: "Ogrenci_Kurslar");

            migrationBuilder.DropTable(
                name: "Kurslar");

            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Ogretmenler");
        }
    }
}
