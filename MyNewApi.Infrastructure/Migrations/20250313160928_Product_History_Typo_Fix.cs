using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Product_History_Typo_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "midificationTime",
                table: "ProductHistories",
                newName: "ModificationTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModificationTime",
                table: "ProductHistories",
                newName: "midificationTime");
        }
    }
}
