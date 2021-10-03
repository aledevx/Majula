using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pk.Migrations
{
    public partial class MovimentacoesPcMonitorEquip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.CreateTable(
                name: "MovimentacoesEquipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAtual = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacoesEquipamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacoesEquipamento_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacoesMonitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAtual = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MonitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacoesMonitor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacoesMonitor_Monitores_MonitorId",
                        column: x => x.MonitorId,
                        principalTable: "Monitores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacoesPc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAtual = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ComputadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacoesPc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacoesPc_Computadores_ComputadorId",
                        column: x => x.ComputadorId,
                        principalTable: "Computadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesEquipamento_EquipamentoId",
                table: "MovimentacoesEquipamento",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesMonitor_MonitorId",
                table: "MovimentacoesMonitor",
                column: "MonitorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesPc_ComputadorId",
                table: "MovimentacoesPc",
                column: "ComputadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacoesEquipamento");

            migrationBuilder.DropTable(
                name: "MovimentacoesMonitor");

            migrationBuilder.DropTable(
                name: "MovimentacoesPc");

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ComputadorId = table.Column<int>(type: "int", nullable: false),
                    DataAtual = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false),
                    MonitorId = table.Column<int>(type: "int", nullable: false),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Computadores_ComputadorId",
                        column: x => x.ComputadorId,
                        principalTable: "Computadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Monitores_MonitorId",
                        column: x => x.MonitorId,
                        principalTable: "Monitores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ComputadorId",
                table: "Movimentacoes",
                column: "ComputadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_EquipamentoId",
                table: "Movimentacoes",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_MonitorId",
                table: "Movimentacoes",
                column: "MonitorId");
        }
    }
}
