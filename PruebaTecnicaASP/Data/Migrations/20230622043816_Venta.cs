using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaASP.Data.Migrations
{
    public partial class Venta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventaArticulos_AspNetUsers_UserId1",
                table: "ventaArticulos");

            migrationBuilder.DropIndex(
                name: "IX_ventaArticulos_UserId1",
                table: "ventaArticulos");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ventaArticulos");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ventaArticulos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "ventaArticulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Precio",
                table: "ventaArticulos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_ventaArticulos_UserId",
                table: "ventaArticulos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ventaArticulos_AspNetUsers_UserId",
                table: "ventaArticulos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventaArticulos_AspNetUsers_UserId",
                table: "ventaArticulos");

            migrationBuilder.DropIndex(
                name: "IX_ventaArticulos_UserId",
                table: "ventaArticulos");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "ventaArticulos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "ventaArticulos");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ventaArticulos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ventaArticulos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ventaArticulos_UserId1",
                table: "ventaArticulos",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ventaArticulos_AspNetUsers_UserId1",
                table: "ventaArticulos",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
