using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ReserveTimeInAndOutMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReserveItemsIn");

            migrationBuilder.DropTable(
                name: "ReserveItemsOut");

            migrationBuilder.CreateTable(
                name: "ReserveItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReserveTimeInId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReserveTimeOutId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveItems_ReserveTimesIn_ReserveTimeInId",
                        column: x => x.ReserveTimeInId,
                        principalTable: "ReserveTimesIn",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReserveItems_ReserveTimesOut_ReserveTimeOutId",
                        column: x => x.ReserveTimeOutId,
                        principalTable: "ReserveTimesOut",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReserveItems_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ReserveTimeInId",
                table: "ReserveItems",
                column: "ReserveTimeInId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ReserveTimeOutId",
                table: "ReserveItems",
                column: "ReserveTimeOutId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ServiceId",
                table: "ReserveItems",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReserveItems");

            migrationBuilder.CreateTable(
                name: "ReserveItemsIn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    ReserveTimeInId = table.Column<Guid>(type: "uuid", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveItemsIn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveItemsIn_ReserveTimesIn_ReserveTimeInId",
                        column: x => x.ReserveTimeInId,
                        principalTable: "ReserveTimesIn",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReserveItemsIn_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReserveItemsOut",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    ReserveTimeOutId = table.Column<Guid>(type: "uuid", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveItemsOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveItemsOut_ReserveTimesOut_ReserveTimeOutId",
                        column: x => x.ReserveTimeOutId,
                        principalTable: "ReserveTimesOut",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReserveItemsOut_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItemsIn_ReserveTimeInId",
                table: "ReserveItemsIn",
                column: "ReserveTimeInId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItemsIn_ServiceId",
                table: "ReserveItemsIn",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItemsOut_ReserveTimeOutId",
                table: "ReserveItemsOut",
                column: "ReserveTimeOutId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItemsOut_ServiceId",
                table: "ReserveItemsOut",
                column: "ServiceId");
        }
    }
}
