using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter_Klon1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDislikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dislike",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeitragId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dislike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dislike_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dislike_Beitrag_BeitragId",
                        column: x => x.BeitragId,
                        principalTable: "Beitrag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dislike_BeitragId",
                table: "Dislike",
                column: "BeitragId");

            migrationBuilder.CreateIndex(
                name: "IX_Dislike_UserId",
                table: "Dislike",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dislike");
        }
    }
}
