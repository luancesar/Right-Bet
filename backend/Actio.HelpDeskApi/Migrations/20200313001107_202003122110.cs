using Microsoft.EntityFrameworkCore.Migrations;

namespace Actio.HelpDeskApi.Migrations
{
    public partial class _202003122110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Usuario");
        }
    }
}
