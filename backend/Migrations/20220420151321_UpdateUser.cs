using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Loja",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "TypeUserEnum",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Loja_UserId",
                table: "Loja",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loja_AspNetUsers_UserId",
                table: "Loja",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loja_AspNetUsers_UserId",
                table: "Loja");

            migrationBuilder.DropIndex(
                name: "IX_Loja_UserId",
                table: "Loja");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Loja");

            migrationBuilder.DropColumn(
                name: "TypeUserEnum",
                table: "AspNetUsers");
        }
    }
}
