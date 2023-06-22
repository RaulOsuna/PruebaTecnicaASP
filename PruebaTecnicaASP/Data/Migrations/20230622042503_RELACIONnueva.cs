using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaASP.Data.Migrations
{
    public partial class RELACIONnueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventasArticulos_Articulos_ArticuloId",
                table: "ventasArticulos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventasArticulos_AspNetUsers_UserId",
                table: "ventasArticulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ventasArticulos",
                table: "ventasArticulos");

            migrationBuilder.DropIndex(
                name: "IX_ventasArticulos_UserId",
                table: "ventasArticulos");

            migrationBuilder.RenameTable(
                name: "ventasArticulos",
                newName: "ventaArticulos");

            migrationBuilder.RenameIndex(
                name: "IX_ventasArticulos_ArticuloId",
                table: "ventaArticulos",
                newName: "IX_ventaArticulos_ArticuloId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_ventaArticulos",
                table: "ventaArticulos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ventaArticulos_UserId1",
                table: "ventaArticulos",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ventaArticulos_Articulos_ArticuloId",
                table: "ventaArticulos",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ventaArticulos_AspNetUsers_UserId1",
                table: "ventaArticulos",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventaArticulos_Articulos_ArticuloId",
                table: "ventaArticulos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventaArticulos_AspNetUsers_UserId1",
                table: "ventaArticulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ventaArticulos",
                table: "ventaArticulos");

            migrationBuilder.DropIndex(
                name: "IX_ventaArticulos_UserId1",
                table: "ventaArticulos");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ventaArticulos");

            migrationBuilder.RenameTable(
                name: "ventaArticulos",
                newName: "ventasArticulos");

            migrationBuilder.RenameIndex(
                name: "IX_ventaArticulos_ArticuloId",
                table: "ventasArticulos",
                newName: "IX_ventasArticulos_ArticuloId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ventasArticulos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ventasArticulos",
                table: "ventasArticulos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ventasArticulos_UserId",
                table: "ventasArticulos",
                column: "UserId");

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
    }
}
