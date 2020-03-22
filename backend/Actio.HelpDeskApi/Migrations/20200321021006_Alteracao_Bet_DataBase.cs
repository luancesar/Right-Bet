using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Actio.HelpDeskApi.Migrations
{
    public partial class Alteracao_Bet_DataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Stake = table.Column<decimal>(nullable: false),
                    ODD = table.Column<decimal>(nullable: false),
                    Green = table.Column<bool>(nullable: false),
                    Lucro = table.Column<decimal>(nullable: false),
                    SaldoAtual = table.Column<decimal>(nullable: false),
                    Porcentagem = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bet");
        }
    }
}
