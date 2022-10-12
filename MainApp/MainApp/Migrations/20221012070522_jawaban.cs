using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainApp.Migrations
{
    public partial class jawaban : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solusi_Konsultasi_KonsultasiId",
                table: "Solusi");

            migrationBuilder.DropIndex(
                name: "IX_Solusi_KonsultasiId",
                table: "Solusi");

            migrationBuilder.DropColumn(
                name: "KonsultasiId",
                table: "Solusi");

            migrationBuilder.CreateTable(
                name: "Jawaban",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GejalaId = table.Column<int>(type: "int", nullable: false),
                    KonsultasiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jawaban", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jawaban_Gejala_GejalaId",
                        column: x => x.GejalaId,
                        principalTable: "Gejala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jawaban_Konsultasi_KonsultasiId",
                        column: x => x.KonsultasiId,
                        principalTable: "Konsultasi",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Jawaban_GejalaId",
                table: "Jawaban",
                column: "GejalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Jawaban_KonsultasiId",
                table: "Jawaban",
                column: "KonsultasiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jawaban");

            migrationBuilder.AddColumn<int>(
                name: "KonsultasiId",
                table: "Solusi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solusi_KonsultasiId",
                table: "Solusi",
                column: "KonsultasiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solusi_Konsultasi_KonsultasiId",
                table: "Solusi",
                column: "KonsultasiId",
                principalTable: "Konsultasi",
                principalColumn: "Id");
        }
    }
}
