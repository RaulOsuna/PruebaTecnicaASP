using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaASP.Data.Migrations
{
    public partial class databaseact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventasArticulos_Articulos_ArticulosId",
                table: "ventasArticulos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventasArticulos_AspNetUsers_AplicationUserId",
                table: "ventasArticulos");

            migrationBuilder.RenameColumn(
                name: "ArticulosId",
                table: "ventasArticulos",
                newName: "ArticuloId");

            migrationBuilder.RenameColumn(
                name: "AplicationUserId",
                table: "ventasArticulos",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ventasArticulos_ArticulosId",
                table: "ventasArticulos",
                newName: "IX_ventasArticulos_ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_ventasArticulos_AplicationUserId",
                table: "ventasArticulos",
                newName: "IX_ventasArticulos_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ventasArticulos_Articulos_ArticuloId",
                table: "ventasArticulos",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ventasArticulos_AspNetUsers_UserId",
                table: "ventasArticulos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventasArticulos_Articulos_ArticuloId",
                table: "ventasArticulos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventasArticulos_AspNetUsers_UserId",
                table: "ventasArticulos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ventasArticulos",
                newName: "AplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ArticuloId",
                table: "ventasArticulos",
                newName: "ArticulosId");

            migrationBuilder.RenameIndex(
                name: "IX_ventasArticulos_UserId",
                table: "ventasArticulos",
                newName: "IX_ventasArticulos_AplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ventasArticulos_ArticuloId",
                table: "ventasArticulos",
                newName: "IX_ventasArticulos_ArticulosId");

            migrationBuilder.AddForeignKey(
                name: "FK_ventasArticulos_Articulos_ArticulosId",
                table: "ventasArticulos",
                column: "ArticulosId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ventasArticulos_AspNetUsers_AplicationUserId",
                table: "ventasArticulos",
                column: "AplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
