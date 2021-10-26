using Microsoft.EntityFrameworkCore.Migrations;

namespace Pk.Migrations
{
    public partial class CorrecaoMovimentacaoMonitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Setor",
                table: "MovimentacoesPc");

            migrationBuilder.DropColumn(
                name: "Setor",
                table: "MovimentacoesMonitor");

            migrationBuilder.DropColumn(
                name: "Setor",
                table: "MovimentacoesEquipamento");

            migrationBuilder.AddColumn<int>(
                name: "SetorId",
                table: "MovimentacoesPc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SetorId",
                table: "MovimentacoesMonitor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SetorId",
                table: "MovimentacoesEquipamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesPc_SetorId",
                table: "MovimentacoesPc",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesMonitor_SetorId",
                table: "MovimentacoesMonitor",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesEquipamento_SetorId",
                table: "MovimentacoesEquipamento",
                column: "SetorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacoesEquipamento_Setores_SetorId",
                table: "MovimentacoesEquipamento",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacoesMonitor_Setores_SetorId",
                table: "MovimentacoesMonitor",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacoesPc_Setores_SetorId",
                table: "MovimentacoesPc",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacoesEquipamento_Setores_SetorId",
                table: "MovimentacoesEquipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacoesMonitor_Setores_SetorId",
                table: "MovimentacoesMonitor");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacoesPc_Setores_SetorId",
                table: "MovimentacoesPc");

            migrationBuilder.DropIndex(
                name: "IX_MovimentacoesPc_SetorId",
                table: "MovimentacoesPc");

            migrationBuilder.DropIndex(
                name: "IX_MovimentacoesMonitor_SetorId",
                table: "MovimentacoesMonitor");

            migrationBuilder.DropIndex(
                name: "IX_MovimentacoesEquipamento_SetorId",
                table: "MovimentacoesEquipamento");

            migrationBuilder.DropColumn(
                name: "SetorId",
                table: "MovimentacoesPc");

            migrationBuilder.DropColumn(
                name: "SetorId",
                table: "MovimentacoesMonitor");

            migrationBuilder.DropColumn(
                name: "SetorId",
                table: "MovimentacoesEquipamento");

            migrationBuilder.AddColumn<string>(
                name: "Setor",
                table: "MovimentacoesPc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Setor",
                table: "MovimentacoesMonitor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Setor",
                table: "MovimentacoesEquipamento",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
