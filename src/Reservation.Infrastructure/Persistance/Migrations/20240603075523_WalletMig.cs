using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class WalletMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUser_Users_UsersVIPId",
                table: "BusinessUser");

            migrationBuilder.RenameColumn(
                name: "UsersVIPId",
                table: "BusinessUser",
                newName: "UsersNormalId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessUser_UsersVIPId",
                table: "BusinessUser",
                newName: "IX_BusinessUser_UsersNormalId");

            migrationBuilder.AddColumn<Guid>(
                name: "WalletId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UsersVIP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersVIP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersVIP_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersVIP_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Credit = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReserveTimeId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_ReserveTimes_ReserveTimeId",
                        column: x => x.ReserveTimeId,
                        principalTable: "ReserveTimes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReserveTimeId",
                table: "Transactions",
                column: "ReserveTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersVIP_BusinessId",
                table: "UsersVIP",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersVIP_UserId",
                table: "UsersVIP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUser_Users_UsersNormalId",
                table: "BusinessUser",
                column: "UsersNormalId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUser_Users_UsersNormalId",
                table: "BusinessUser");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UsersVIP");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UsersNormalId",
                table: "BusinessUser",
                newName: "UsersVIPId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessUser_UsersNormalId",
                table: "BusinessUser",
                newName: "IX_BusinessUser_UsersVIPId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUser_Users_UsersVIPId",
                table: "BusinessUser",
                column: "UsersVIPId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
