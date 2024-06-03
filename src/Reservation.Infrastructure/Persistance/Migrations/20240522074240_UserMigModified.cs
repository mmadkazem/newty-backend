using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UserMigModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Businesses_BusinessId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BusinessId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "BusinessUser",
                columns: table => new
                {
                    BusinessesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersVIPId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUser", x => new { x.BusinessesId, x.UsersVIPId });
                    table.ForeignKey(
                        name: "FK_BusinessUser_Businesses_BusinessesId",
                        column: x => x.BusinessesId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessUser_Users_UsersVIPId",
                        column: x => x.UsersVIPId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUser_UsersVIPId",
                table: "BusinessUser",
                column: "UsersVIPId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessUser");

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BusinessId",
                table: "Users",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Businesses_BusinessId",
                table: "Users",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");
        }
    }
}
