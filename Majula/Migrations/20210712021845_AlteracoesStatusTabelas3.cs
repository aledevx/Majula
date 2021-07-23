using Microsoft.EntityFrameworkCore.Migrations;

namespace Pk.Migrations
{
    public partial class AlteracoesStatusTabelas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitores_Computadores_ComputadorId",
                table: "Monitores");

            migrationBuilder.AlterColumn<int>(
                name: "ComputadorId",
                table: "Monitores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitores_Computadores_ComputadorId",
                table: "Monitores",
                column: "ComputadorId",
                principalTable: "Computadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitores_Computadores_ComputadorId",
                table: "Monitores");

            migrationBuilder.AlterColumn<int>(
                name: "ComputadorId",
                table: "Monitores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Monitores_Computadores_ComputadorId",
                table: "Monitores",
                column: "ComputadorId",
                principalTable: "Computadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
