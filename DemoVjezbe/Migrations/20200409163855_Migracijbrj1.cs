using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoVjezbe.Migrations
{
    public partial class Migracijbrj1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NazivModela",
                table: "Automobil",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VrstaGoriva",
                table: "Automobil",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VrstaGoriva",
                table: "Automobil");

            migrationBuilder.AlterColumn<string>(
                name: "NazivModela",
                table: "Automobil",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
