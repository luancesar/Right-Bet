using Microsoft.EntityFrameworkCore.Migrations;

namespace Actio.HelpDeskApi.Migrations
{
    public partial class correcao_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BancaInical",
                table: "Usuario");

            migrationBuilder.AddColumn<decimal>(
                name: "BancaInicial",
                table: "Usuario",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BancaInicial",
                table: "Usuario");

            migrationBuilder.AddColumn<decimal>(
                name: "BancaInical",
                table: "Usuario",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
