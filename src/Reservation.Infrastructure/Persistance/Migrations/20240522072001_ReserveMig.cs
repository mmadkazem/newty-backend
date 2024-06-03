using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ReserveMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReserveTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveTimes_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReserveTimes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReserveItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReserveTimeId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveItems_ReserveTimes_ReserveTimeId",
                        column: x => x.ReserveTimeId,
                        principalTable: "ReserveTimes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReserveItems_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ReserveTimeId",
                table: "ReserveItems",
                column: "ReserveTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ServiceId",
                table: "ReserveItems",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimes_BusinessId",
                table: "ReserveTimes",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimes_UserId",
                table: "ReserveTimes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReserveItems");

            migrationBuilder.DropTable(
                name: "ReserveTimes");
        }
    }
}
