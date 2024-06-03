using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class FinanceMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessRequestPays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    IsPay = table.Column<bool>(type: "boolean", nullable: false),
                    PayDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Authorizy = table.Column<string>(type: "text", nullable: true),
                    RefId = table.Column<int>(type: "integer", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessRequestPays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessRequestPays_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRequestPays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    IsPay = table.Column<bool>(type: "boolean", nullable: false),
                    PayDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Authorizy = table.Column<string>(type: "text", nullable: true),
                    RefId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReserveTimeId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRequestPays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRequestPays_ReserveTimes_ReserveTimeId",
                        column: x => x.ReserveTimeId,
                        principalTable: "ReserveTimes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRequestPays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRequestPays_BusinessId",
                table: "BusinessRequestPays",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequestPays_ReserveTimeId",
                table: "UserRequestPays",
                column: "ReserveTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequestPays_UserId",
                table: "UserRequestPays",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessRequestPays");

            migrationBuilder.DropTable(
                name: "UserRequestPays");
        }
    }
}
