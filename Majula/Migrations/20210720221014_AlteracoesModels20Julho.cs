using Microsoft.EntityFrameworkCore.Migrations;

namespace Pk.Migrations
{
    public partial class AlteracoesModels20Julho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntidadeId",
                table: "Movimentacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonitorId",
                table: "Movimentacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Monitores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Processador",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_MonitorId",
                table: "Movimentacoes",
                column: "MonitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Monitores_MonitorId",
                table: "Movimentacoes",
                column: "MonitorId",
                principalTable: "Monitores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Monitores_MonitorId",
                table: "Movimentacoes");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacoes_MonitorId",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "EntidadeId",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "MonitorId",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Monitores");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Equipamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Processador",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
