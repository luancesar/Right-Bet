using Microsoft.EntityFrameworkCore.Migrations;

namespace Actio.HelpDeskApi.Migrations
{
    public partial class Alteracao_Bet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BancaAtual",
                table: "Usuario",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BancaInical",
                table: "Usuario",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentagemFaturamento",
                table: "Usuario",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BancaAtual",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "BancaInical",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PorcentagemFaturamento",
                table: "Usuario");
        }
    }
}
