using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaASP.Data.Migrations
{
    public partial class RelacionesMigracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventasArticulos_AspNetUsers_AplicationUserId1",
                table: "ventasArticulos");

            migrationBuilder.DropIndex(
                name: "IX_ventasArticulos_AplicationUserId1",
                table: "ventasArticulos");

            migrationBuilder.DropColumn(
                name: "AplicationUserId1",
                table: "ventasArticulos");

            migrationBuilder.AlterColumn<string>(
                name: "AplicationUserId",
                table: "ventasArticulos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ventasArticulos_AplicationUserId",
                table: "ventasArticulos",
                column: "AplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ventasArticulos_AspNetUsers_AplicationUserId",
                table: "ventasArticulos",
                column: "AplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventasArticulos_AspNetUsers_AplicationUserId",
                table: "ventasArticulos");

            migrationBuilder.DropIndex(
                name: "IX_ventasArticulos_AplicationUserId",
                table: "ventasArticulos");

            migrationBuilder.AlterColumn<int>(
                name: "AplicationUserId",
                table: "ventasArticulos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AplicationUserId1",
                table: "ventasArticulos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ventasArticulos_AplicationUserId1",
                table: "ventasArticulos",
                column: "AplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ventasArticulos_AspNetUsers_AplicationUserId1",
                table: "ventasArticulos",
                column: "AplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
