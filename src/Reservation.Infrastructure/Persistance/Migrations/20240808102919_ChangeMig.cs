using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Categories_CategoryId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_CategoryId",
                table: "Points");

            migrationBuilder.DeleteData(
                table: "TransferFees",
                keyColumn: "Id",
                keyValue: new Guid("7e7fd110-33b0-4c85-b644-421daf4a7259"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2a47a40a-5534-40c1-96d9-763a90a2a7ce"));

            migrationBuilder.DropColumn(
                name: "OTPCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "OTPCode",
                table: "Businesses");

            migrationBuilder.InsertData(
                table: "TransferFees",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("090cd1fa-6d2b-447e-b776-d078ddcc7f6d"), new DateTime(2024, 8, 8, 13, 59, 17, 618, DateTimeKind.Local).AddTicks(9774), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("672d679b-f9a7-4c2d-b984-31e816f1c139"), null, new DateTime(2024, 8, 8, 13, 59, 17, 618, DateTimeKind.Local).AddTicks(7846), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransferFees",
                keyColumn: "Id",
                keyValue: new Guid("090cd1fa-6d2b-447e-b776-d078ddcc7f6d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("672d679b-f9a7-4c2d-b984-31e816f1c139"));

            migrationBuilder.AddColumn<string>(
                name: "OTPCode",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Points",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OTPCode",
                table: "Businesses",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "TransferFees",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("7e7fd110-33b0-4c85-b644-421daf4a7259"), new DateTime(2024, 7, 24, 10, 58, 59, 870, DateTimeKind.Local).AddTicks(5995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "OTPCode", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("2a47a40a-5534-40c1-96d9-763a90a2a7ce"), null, new DateTime(2024, 7, 24, 10, 58, 59, 870, DateTimeKind.Local).AddTicks(3758), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "09111111111", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Points_CategoryId",
                table: "Points",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Categories_CategoryId",
                table: "Points",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
