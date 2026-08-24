using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter_Klon1.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_AspNetUsers_UserId1",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_UserId1",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Like");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Like",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_AspNetUsers_UserId",
                table: "Like",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_AspNetUsers_UserId",
                table: "Like");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Like",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Like",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId1",
                table: "Like",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_AspNetUsers_UserId1",
                table: "Like",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
