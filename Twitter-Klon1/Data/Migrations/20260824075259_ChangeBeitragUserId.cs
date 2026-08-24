using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter_Klon1.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBeitragUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beitrag_AspNetUsers_UserId1",
                table: "Beitrag");

            migrationBuilder.DropIndex(
                name: "IX_Beitrag_UserId1",
                table: "Beitrag");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Beitrag");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Beitrag",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ErstellungsDatum",
                table: "Beitrag",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Beitrag_UserId",
                table: "Beitrag",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrag_AspNetUsers_UserId",
                table: "Beitrag",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beitrag_AspNetUsers_UserId",
                table: "Beitrag");

            migrationBuilder.DropIndex(
                name: "IX_Beitrag_UserId",
                table: "Beitrag");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Beitrag",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ErstellungsDatum",
                table: "Beitrag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Beitrag",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beitrag_UserId1",
                table: "Beitrag",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrag_AspNetUsers_UserId1",
                table: "Beitrag",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
