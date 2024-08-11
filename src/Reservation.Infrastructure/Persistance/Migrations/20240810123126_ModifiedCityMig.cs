using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedCityMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransferFees",
                keyColumn: "Id",
                keyValue: new Guid("090cd1fa-6d2b-447e-b776-d078ddcc7f6d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("672d679b-f9a7-4c2d-b984-31e816f1c139"));

            migrationBuilder.DropColumn(
                name: "State",
                table: "Cities");

            migrationBuilder.InsertData(
                table: "TransferFees",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("bf81c581-bd8d-482c-9838-e1bb76f8ab0a"), new DateTime(2024, 8, 10, 16, 1, 25, 575, DateTimeKind.Local).AddTicks(6272), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("aa24f2c7-6275-448f-bf59-0a657846aa73"), null, new DateTime(2024, 8, 10, 16, 1, 25, 575, DateTimeKind.Local).AddTicks(4558), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransferFees",
                keyColumn: "Id",
                keyValue: new Guid("bf81c581-bd8d-482c-9838-e1bb76f8ab0a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa24f2c7-6275-448f-bf59-0a657846aa73"));

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Cities",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "TransferFees",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("090cd1fa-6d2b-447e-b776-d078ddcc7f6d"), new DateTime(2024, 8, 8, 13, 59, 17, 618, DateTimeKind.Local).AddTicks(9774), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("672d679b-f9a7-4c2d-b984-31e816f1c139"), null, new DateTime(2024, 8, 8, 13, 59, 17, 618, DateTimeKind.Local).AddTicks(7846), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });
        }
    }
}
