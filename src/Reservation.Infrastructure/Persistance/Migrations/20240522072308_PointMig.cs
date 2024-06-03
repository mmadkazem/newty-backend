using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class PointMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Point_Artists_ArtistId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Businesses_BusinessId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Categories_CategoryId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Users_UserId",
                table: "Point");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Point",
                table: "Point");

            migrationBuilder.RenameTable(
                name: "Point",
                newName: "Points");

            migrationBuilder.RenameIndex(
                name: "IX_Point_UserId",
                table: "Points",
                newName: "IX_Points_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_CategoryId",
                table: "Points",
                newName: "IX_Points_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_BusinessId",
                table: "Points",
                newName: "IX_Points_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_ArtistId",
                table: "Points",
                newName: "IX_Points_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Points",
                table: "Points",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Artists_ArtistId",
                table: "Points",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Businesses_BusinessId",
                table: "Points",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Categories_CategoryId",
                table: "Points",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Users_UserId",
                table: "Points",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Artists_ArtistId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Businesses_BusinessId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Categories_CategoryId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Users_UserId",
                table: "Points");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Points",
                table: "Points");

            migrationBuilder.RenameTable(
                name: "Points",
                newName: "Point");

            migrationBuilder.RenameIndex(
                name: "IX_Points_UserId",
                table: "Point",
                newName: "IX_Point_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_CategoryId",
                table: "Point",
                newName: "IX_Point_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_BusinessId",
                table: "Point",
                newName: "IX_Point_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_ArtistId",
                table: "Point",
                newName: "IX_Point_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Point",
                table: "Point",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Artists_ArtistId",
                table: "Point",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Businesses_BusinessId",
                table: "Point",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Categories_CategoryId",
                table: "Point",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Users_UserId",
                table: "Point",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
