using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaASP.Data.Migrations
{
    public partial class VentaCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventaArticulos_Articulos_ArticuloId",
                table: "ventaArticulos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventaArticulos_AspNetUsers_UserId",
                table: "ventaArticulos");

            migrationBuilder.DropIndex(
                name: "IX_ventaArticulos_ArticuloId",
                table: "ventaArticulos");

            migrationBuilder.DropIndex(
                name: "IX_ventaArticulos_UserId",
                table: "ventaArticulos");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ventaArticulos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ventaArticulos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticulosId",
                table: "ventaArticulos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ventaArticulos_ApplicationUserId",
                table: "ventaArticulos",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ventaArticulos_ArticulosId",
                table: "ventaArticulos",
                column: "ArticulosId");

            migrationBuilder.AddForeignKey(
                name: "FK_ventaArticulos_Articulos_ArticulosId",
                table: "ventaArticulos",
                column: "ArticulosId",
                principalTable: "Articulos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ventaArticulos_AspNetUsers_ApplicationUserId",
                table: "ventaArticulos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventaArticulos_Articulos_ArticulosId",
                table: "ventaArticulos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventaArticulos_AspNetUsers_ApplicationUserId",
                table: "ventaArticulos");

            migrationBuilder.DropIndex(
                name: "IX_ventaArticulos_ApplicationUserId",
                table: "ventaArticulos");

            migrationBuilder.DropIndex(
                name: "IX_ventaArticulos_ArticulosId",
                table: "ventaArticulos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ventaArticulos");

            migrationBuilder.DropColumn(
                name: "ArticulosId",
                table: "ventaArticulos");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ventaArticulos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ventaArticulos_ArticuloId",
                table: "ventaArticulos",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ventaArticulos_UserId",
                table: "ventaArticulos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ventaArticulos_Articulos_ArticuloId",
                table: "ventaArticulos",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ventaArticulos_AspNetUsers_UserId",
                table: "ventaArticulos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
