using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CategoryMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Point",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryId",
                table: "Point",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryId",
                table: "Businesses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    AveragePoint = table.Column<double>(type: "double precision", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    AveragePoint = table.Column<double>(type: "double precision", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Point_CategoryId",
                table: "Point",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Point_SubCategoryId",
                table: "Point",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_SubCategoryId",
                table: "Businesses",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_SubCategories_SubCategoryId",
                table: "Businesses",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Categories_CategoryId",
                table: "Point",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_SubCategories_SubCategoryId",
                table: "Point",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_SubCategories_SubCategoryId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Categories_CategoryId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_SubCategories_SubCategoryId",
                table: "Point");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Point_CategoryId",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_SubCategoryId",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_SubCategoryId",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Businesses");
        }
    }
}
