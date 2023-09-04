using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Ogrenci_Kurs_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSetDers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ders_Ogretmenler_OgretmenID",
                table: "Ders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ders",
                table: "Ders");

            migrationBuilder.RenameTable(
                name: "Ders",
                newName: "Dersler");

            migrationBuilder.RenameIndex(
                name: "IX_Ders_OgretmenID",
                table: "Dersler",
                newName: "IX_Dersler_OgretmenID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dersler",
                table: "Dersler",
                column: "DersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dersler_Ogretmenler_OgretmenID",
                table: "Dersler",
                column: "OgretmenID",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dersler_Ogretmenler_OgretmenID",
                table: "Dersler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dersler",
                table: "Dersler");

            migrationBuilder.RenameTable(
                name: "Dersler",
                newName: "Ders");

            migrationBuilder.RenameIndex(
                name: "IX_Dersler_OgretmenID",
                table: "Ders",
                newName: "IX_Ders_OgretmenID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ders",
                table: "Ders",
                column: "DersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ders_Ogretmenler_OgretmenID",
                table: "Ders",
                column: "OgretmenID",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
