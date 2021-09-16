using Microsoft.EntityFrameworkCore.Migrations;

namespace Pk.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmazenamentoInterno1",
                table: "Computadores");

            migrationBuilder.DropColumn(
                name: "ArmazenamentoInterno2",
                table: "Computadores");

            migrationBuilder.DropColumn(
                name: "Cautela",
                table: "Computadores");

            migrationBuilder.DropColumn(
                name: "Destino",
                table: "Computadores");

            migrationBuilder.DropColumn(
                name: "Origem",
                table: "Computadores");

            migrationBuilder.RenameColumn(
                name: "ProcessoAquisicao",
                table: "Computadores",
                newName: "ArmazenamentoInterno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArmazenamentoInterno",
                table: "Computadores",
                newName: "ProcessoAquisicao");

            migrationBuilder.AddColumn<string>(
                name: "ArmazenamentoInterno1",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArmazenamentoInterno2",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cautela",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destino",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origem",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
