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
                name: "FK_Transaction_ReserveTimesReceipt_ReserveTimeId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Wallet_WalletId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wallet_WalletId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "Wallets");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_WalletId",
                table: "Transactions",
                newName: "IX_Transactions_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_ReserveTimeId",
                table: "Transactions",
                newName: "IX_Transactions_ReserveTimeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletId",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletId",
                table: "Businesses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndHoursOfWor",
                table: "Businesses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartHoursOfWor",
                table: "Businesses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Wallets_WalletId",
                table: "Businesses",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ReserveTimesReceipt_ReserveTimeId",
                table: "Transactions",
                column: "ReserveTimeId",
                principalTable: "ReserveTimesReceipt",
                principalColumn: "Id");

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
                name: "FK_Transactions_ReserveTimesReceipt_ReserveTimeId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Wallets_WalletId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wallets_WalletId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "EndHoursOfWor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "StartHoursOfWor",
                table: "Businesses");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "Wallet");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_WalletId",
                table: "Transaction",
                newName: "IX_Transaction_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ReserveTimeId",
                table: "Transaction",
                newName: "IX_Transaction_ReserveTimeId");

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
                name: "WalletId",
                table: "Businesses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Wallet_WalletId",
                table: "Businesses",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
