using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaASP.Data.Migrations
{
    public partial class imagenArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "ventaArticulos",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "ventaArticulos");
        }
    }
}
