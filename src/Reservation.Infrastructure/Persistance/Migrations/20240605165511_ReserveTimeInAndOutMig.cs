using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ReserveTimeInAndOutMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ReserveTimes_ReserveTimeId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestPays_ReserveTimes_ReserveTimeId",
                table: "UserRequestPays");

            migrationBuilder.DropTable(
                name: "ReserveItems");

            migrationBuilder.DropTable(
                name: "ReserveTimes");

            migrationBuilder.CreateTable(
                name: "ReserveTimesIn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    BusinessInId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessOutId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveTimesIn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveTimesIn_Businesses_BusinessInId",
                        column: x => x.BusinessInId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimesIn_Businesses_BusinessOutId",
                        column: x => x.BusinessOutId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReserveTimesOut",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveTimesOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveTimesOut_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimesOut_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReserveItemsIn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReserveTimeInId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReserveTimeOutId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesIn_BusinessInId",
                table: "ReserveTimesIn",
                column: "BusinessInId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesIn_BusinessOutId",
                table: "ReserveTimesIn",
                column: "BusinessOutId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesOut_BusinessId",
                table: "ReserveTimesOut",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesOut_UserId",
                table: "ReserveTimesOut",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ReserveTimesOut_ReserveTimeId",
                table: "Transactions",
                column: "ReserveTimeId",
                principalTable: "ReserveTimesOut",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequestPays_ReserveTimesOut_ReserveTimeId",
                table: "UserRequestPays",
                column: "ReserveTimeId",
                principalTable: "ReserveTimesOut",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ReserveTimesOut_ReserveTimeId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestPays_ReserveTimesOut_ReserveTimeId",
                table: "UserRequestPays");

            migrationBuilder.DropTable(
                name: "ReserveItemsIn");

            migrationBuilder.DropTable(
                name: "ReserveItemsOut");

            migrationBuilder.DropTable(
                name: "ReserveTimesIn");

            migrationBuilder.DropTable(
                name: "ReserveTimesOut");

            migrationBuilder.CreateTable(
                name: "ReserveTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    TotalEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    TotalStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    ReserveTimeId = table.Column<Guid>(type: "uuid", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ReserveTimes_ReserveTimeId",
                table: "Transactions",
                column: "ReserveTimeId",
                principalTable: "ReserveTimes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequestPays_ReserveTimes_ReserveTimeId",
                table: "UserRequestPays",
                column: "ReserveTimeId",
                principalTable: "ReserveTimes",
                principalColumn: "Id");
        }
    }
}
