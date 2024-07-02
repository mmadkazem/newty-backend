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
                name: "FK_Businesses_Wallet_WalletId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Businesses_BusinessId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesSender_Businesses_BusinessInId",
                table: "ReserveTimesSender");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesSender_Businesses_BusinessReceiptId",
                table: "ReserveTimesSender");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Artists_ArtistId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_ReserveTimesReceipt_ReserveTimeId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Wallet_WalletId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wallet_WalletId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTimesSender_BusinessInId",
                table: "ReserveTimesSender");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTimesReceipt_BusinessId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ReserveTimeId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "BusinessInId",
                table: "ReserveTimesSender");

            migrationBuilder.DropColumn(
                name: "ReserveTimeId",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "Wallets");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameColumn(
                name: "BusinessOutId",
                table: "ReserveTimesSender",
                newName: "BusinessSenderId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "ReserveTimesReceipt",
                newName: "TransactionSenderId");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Businesses",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_WalletId",
                table: "Transactions",
                newName: "IX_Transactions_WalletId");

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletId",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OTPCode",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Services",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BusinessReceiptId",
                table: "ReserveTimesSender",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessReceiptId",
                table: "ReserveTimesReceipt",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessSenderId",
                table: "ReserveTimesReceipt",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionReceiptId",
                table: "ReserveTimesReceipt",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletId",
                table: "Businesses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndHoursOfWor",
                table: "Businesses",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "OTPCode",
                table: "Businesses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartHoursOfWor",
                table: "Businesses",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "OTPCode", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("05328466-7352-4ee1-add8-fe1cb2607b11"), null, new DateTime(2024, 7, 2, 20, 24, 8, 225, DateTimeKind.Local).AddTicks(3966), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "09111111111", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesSender_BusinessSenderId",
                table: "ReserveTimesSender",
                column: "BusinessSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesReceipt_BusinessReceiptId",
                table: "ReserveTimesReceipt",
                column: "BusinessReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesReceipt_BusinessSenderId",
                table: "ReserveTimesReceipt",
                column: "BusinessSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesReceipt_TransactionReceiptId",
                table: "ReserveTimesReceipt",
                column: "TransactionReceiptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesReceipt_TransactionSenderId",
                table: "ReserveTimesReceipt",
                column: "TransactionSenderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Wallets_WalletId",
                table: "Businesses",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesReceipt_Businesses_BusinessReceiptId",
                table: "ReserveTimesReceipt",
                column: "BusinessReceiptId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesReceipt_Businesses_BusinessSenderId",
                table: "ReserveTimesReceipt",
                column: "BusinessSenderId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesReceipt_Transactions_TransactionReceiptId",
                table: "ReserveTimesReceipt",
                column: "TransactionReceiptId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesReceipt_Transactions_TransactionSenderId",
                table: "ReserveTimesReceipt",
                column: "TransactionSenderId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesSender_Businesses_BusinessReceiptId",
                table: "ReserveTimesSender",
                column: "BusinessReceiptId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesSender_Businesses_BusinessSenderId",
                table: "ReserveTimesSender",
                column: "BusinessSenderId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Artists_ArtistId",
                table: "Services",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Wallets_WalletId",
                table: "Transactions",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Wallets_WalletId",
                table: "Users",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Wallets_WalletId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Businesses_BusinessReceiptId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Businesses_BusinessSenderId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Transactions_TransactionReceiptId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Transactions_TransactionSenderId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesSender_Businesses_BusinessReceiptId",
                table: "ReserveTimesSender");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesSender_Businesses_BusinessSenderId",
                table: "ReserveTimesSender");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Artists_ArtistId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Wallets_WalletId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wallets_WalletId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTimesSender_BusinessSenderId",
                table: "ReserveTimesSender");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTimesReceipt_BusinessReceiptId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTimesReceipt_BusinessSenderId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTimesReceipt_TransactionReceiptId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTimesReceipt_TransactionSenderId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("05328466-7352-4ee1-add8-fe1cb2607b11"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OTPCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BusinessReceiptId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropColumn(
                name: "BusinessSenderId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropColumn(
                name: "TransactionReceiptId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropColumn(
                name: "EndHoursOfWor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "OTPCode",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "StartHoursOfWor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "Wallet");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameColumn(
                name: "BusinessSenderId",
                table: "ReserveTimesSender",
                newName: "BusinessOutId");

            migrationBuilder.RenameColumn(
                name: "TransactionSenderId",
                table: "ReserveTimesReceipt",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Businesses",
                newName: "Active");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_WalletId",
                table: "Transaction",
                newName: "IX_Transaction_WalletId");

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Services",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "BusinessReceiptId",
                table: "ReserveTimesSender",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessInId",
                table: "ReserveTimesSender",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletId",
                table: "Businesses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReserveTimeId",
                table: "Transaction",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesSender_BusinessInId",
                table: "ReserveTimesSender",
                column: "BusinessInId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesReceipt_BusinessId",
                table: "ReserveTimesReceipt",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReserveTimeId",
                table: "Transaction",
                column: "ReserveTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Wallet_WalletId",
                table: "Businesses",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesReceipt_Businesses_BusinessId",
                table: "ReserveTimesReceipt",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesSender_Businesses_BusinessInId",
                table: "ReserveTimesSender",
                column: "BusinessInId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesSender_Businesses_BusinessReceiptId",
                table: "ReserveTimesSender",
                column: "BusinessReceiptId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Artists_ArtistId",
                table: "Services",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_ReserveTimesReceipt_ReserveTimeId",
                table: "Transaction",
                column: "ReserveTimeId",
                principalTable: "ReserveTimesReceipt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Wallet_WalletId",
                table: "Transaction",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Wallet_WalletId",
                table: "Users",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
