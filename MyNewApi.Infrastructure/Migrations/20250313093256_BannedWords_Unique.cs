using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BannedWords_Unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BannedWords_Word",
                table: "BannedWords",
                column: "Word",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BannedWords_Word",
                table: "BannedWords");
        }
    }
}
