using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoVjezbe.Migrations
{
    public partial class Inicijlna0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    ProizvodjacId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.ProizvodjacId);
                });

            migrationBuilder.CreateTable(
                name: "Automobil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivModela = table.Column<string>(nullable: true),
                    GodinaProizvodnje = table.Column<int>(nullable: false),
                    ProizvodjacId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automobil_Proizvodjac_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjac",
                        principalColumn: "ProizvodjacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobil_ProizvodjacId",
                table: "Automobil",
                column: "ProizvodjacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobil");

            migrationBuilder.DropTable(
                name: "Proizvodjac");
        }
    }
}
