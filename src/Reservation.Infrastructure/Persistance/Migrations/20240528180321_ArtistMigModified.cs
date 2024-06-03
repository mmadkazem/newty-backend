using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ArtistMigModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Artists_ArtistId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ArtistId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "ArtistService",
                columns: table => new
                {
                    ArtistsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServicesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistService", x => new { x.ArtistsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_ArtistService_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistService_ServicesId",
                table: "ArtistService",
                column: "ServicesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistService");

            migrationBuilder.AddColumn<Guid>(
                name: "ArtistId",
                table: "Services",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ArtistId",
                table: "Services",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Artists_ArtistId",
                table: "Services",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }
    }
}
