using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SubCategoryMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Businesses_BusinessId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_BusinessId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");

            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryId",
                table: "Points",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryId",
                table: "Businesses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    AveragePoint = table.Column<int>(type: "integer", nullable: false),
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
                name: "IX_Points_SubCategoryId",
                table: "Points",
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
                name: "FK_Points_SubCategories_SubCategoryId",
                table: "Points",
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
                name: "FK_Points_SubCategories_SubCategoryId",
                table: "Points");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_Points_SubCategoryId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_SubCategoryId",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Businesses");

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BusinessId",
                table: "Categories",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Businesses_BusinessId",
                table: "Categories",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
