using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaASP.Data.Migrations
{
    public partial class RelacionesMigracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_AspNetUsers_ApplicationUserId1",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_ApplicationUserId1",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Articulos");

            migrationBuilder.CreateTable(
                name: "ventasArticulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AplicationUserId = table.Column<int>(type: "int", nullable: false),
                    AplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArticulosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventasArticulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ventasArticulos_Articulos_ArticulosId",
                        column: x => x.ArticulosId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ventasArticulos_AspNetUsers_AplicationUserId1",
                        column: x => x.AplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ventasArticulos_AplicationUserId1",
                table: "ventasArticulos",
                column: "AplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ventasArticulos_ArticulosId",
                table: "ventasArticulos",
                column: "ArticulosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ventasArticulos");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Articulos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_ApplicationUserId1",
                table: "Articulos",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_AspNetUsers_ApplicationUserId1",
                table: "Articulos",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
