using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter_Klon1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLikeUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId_BeitragId",
                table: "Like",
                columns: new[] { "UserId", "BeitragId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Like_UserId_BeitragId",
                table: "Like");
        }
    }
}
