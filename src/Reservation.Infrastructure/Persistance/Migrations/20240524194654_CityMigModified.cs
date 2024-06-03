using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CityMigModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cities",
                type: "text",
                nullable: true);
        }
    }
}
