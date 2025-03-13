using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Product_History : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NewName = table.Column<string>(type: "text", nullable: false),
                    NewPrice = table.Column<double>(type: "double precision", nullable: false),
                    NewAvailableQuantity = table.Column<int>(type: "integer", nullable: false),
                    NewCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    midificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductHistories_Categories_NewCategoryId",
                        column: x => x.NewCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductHistories_NewCategoryId",
                table: "ProductHistories",
                column: "NewCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductHistories");
        }
    }
}
