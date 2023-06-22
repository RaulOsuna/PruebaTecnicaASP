using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaASP.Data.Migrations
{
    public partial class CambiosModeloArticulos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Tienda_TiendaId",
                table: "Articulos");

            migrationBuilder.AlterColumn<int>(
                name: "TiendaId",
                table: "Articulos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Articulos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Tienda_TiendaId",
                table: "Articulos",
                column: "TiendaId",
                principalTable: "Tienda",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Tienda_TiendaId",
                table: "Articulos");

            migrationBuilder.AlterColumn<int>(
                name: "TiendaId",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Tienda_TiendaId",
                table: "Articulos",
                column: "TiendaId",
                principalTable: "Tienda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
