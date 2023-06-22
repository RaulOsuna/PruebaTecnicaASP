using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaASP.Data.Migrations
{
    public partial class DBAgregandoEstatusTienda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_AspNetUsers_ApplicationUserId1",
                table: "Articulos");

            migrationBuilder.AddColumn<bool>(
                name: "Estatus",
                table: "Tienda",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId1",
                table: "Articulos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_AspNetUsers_ApplicationUserId1",
                table: "Articulos",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_AspNetUsers_ApplicationUserId1",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Tienda");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId1",
                table: "Articulos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_AspNetUsers_ApplicationUserId1",
                table: "Articulos",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
