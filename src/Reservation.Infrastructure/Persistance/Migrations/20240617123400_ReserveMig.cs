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
            migrationBuilder.DropForeignKey(
                name: "FK_ReserveItem_ReserveTimeReceipt_ReserveTimeReceiptId",
                table: "ReserveItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveItem_ReserveTimeSender_ReserveTimeSenderId",
                table: "ReserveItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveItem_Services_ServiceId",
                table: "ReserveItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Businesses_BusinessId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Users_UserId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeSender_Businesses_BusinessInId",
                table: "ReserveTimeSender");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeSender_Businesses_BusinessReceiptId",
                table: "ReserveTimeSender");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_ReserveTimeReceipt_ReserveTimeId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveTimeSender",
                table: "ReserveTimeSender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveTimeReceipt",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveItem",
                table: "ReserveItem");

            migrationBuilder.RenameTable(
                name: "ReserveTimeSender",
                newName: "ReserveTimesSender");

            migrationBuilder.RenameTable(
                name: "ReserveTimeReceipt",
                newName: "ReserveTimesReceipt");

            migrationBuilder.RenameTable(
                name: "ReserveItem",
                newName: "ReserveItems");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimeSender_BusinessReceiptId",
                table: "ReserveTimesSender",
                newName: "IX_ReserveTimesSender_BusinessReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimeSender_BusinessInId",
                table: "ReserveTimesSender",
                newName: "IX_ReserveTimesSender_BusinessInId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimeReceipt_UserId",
                table: "ReserveTimesReceipt",
                newName: "IX_ReserveTimesReceipt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimeReceipt_BusinessId",
                table: "ReserveTimesReceipt",
                newName: "IX_ReserveTimesReceipt_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveItem_ServiceId",
                table: "ReserveItems",
                newName: "IX_ReserveItems_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveItem_ReserveTimeSenderId",
                table: "ReserveItems",
                newName: "IX_ReserveItems_ReserveTimeSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveItem_ReserveTimeReceiptId",
                table: "ReserveItems",
                newName: "IX_ReserveItems_ReserveTimeReceiptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReserveTimesSender",
                table: "ReserveTimesSender",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReserveTimesReceipt",
                table: "ReserveTimesReceipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReserveItems",
                table: "ReserveItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveItems_ReserveTimesReceipt_ReserveTimeReceiptId",
                table: "ReserveItems",
                column: "ReserveTimeReceiptId",
                principalTable: "ReserveTimesReceipt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveItems_ReserveTimesSender_ReserveTimeSenderId",
                table: "ReserveItems",
                column: "ReserveTimeSenderId",
                principalTable: "ReserveTimesSender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveItems_Services_ServiceId",
                table: "ReserveItems",
                column: "ServiceId",
                principalTable: "Services",
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
                name: "FK_ReserveTimesReceipt_Users_UserId",
                table: "ReserveTimesReceipt",
                column: "UserId",
                principalTable: "Users",
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
                name: "FK_Transaction_ReserveTimesReceipt_ReserveTimeId",
                table: "Transaction",
                column: "ReserveTimeId",
                principalTable: "ReserveTimesReceipt",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReserveItems_ReserveTimesReceipt_ReserveTimeReceiptId",
                table: "ReserveItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveItems_ReserveTimesSender_ReserveTimeSenderId",
                table: "ReserveItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveItems_Services_ServiceId",
                table: "ReserveItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Businesses_BusinessId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Users_UserId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesSender_Businesses_BusinessInId",
                table: "ReserveTimesSender");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesSender_Businesses_BusinessReceiptId",
                table: "ReserveTimesSender");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_ReserveTimesReceipt_ReserveTimeId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveTimesSender",
                table: "ReserveTimesSender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveTimesReceipt",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveItems",
                table: "ReserveItems");

            migrationBuilder.RenameTable(
                name: "ReserveTimesSender",
                newName: "ReserveTimeSender");

            migrationBuilder.RenameTable(
                name: "ReserveTimesReceipt",
                newName: "ReserveTimeReceipt");

            migrationBuilder.RenameTable(
                name: "ReserveItems",
                newName: "ReserveItem");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimesSender_BusinessReceiptId",
                table: "ReserveTimeSender",
                newName: "IX_ReserveTimeSender_BusinessReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimesSender_BusinessInId",
                table: "ReserveTimeSender",
                newName: "IX_ReserveTimeSender_BusinessInId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimesReceipt_UserId",
                table: "ReserveTimeReceipt",
                newName: "IX_ReserveTimeReceipt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimesReceipt_BusinessId",
                table: "ReserveTimeReceipt",
                newName: "IX_ReserveTimeReceipt_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveItems_ServiceId",
                table: "ReserveItem",
                newName: "IX_ReserveItem_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveItems_ReserveTimeSenderId",
                table: "ReserveItem",
                newName: "IX_ReserveItem_ReserveTimeSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveItems_ReserveTimeReceiptId",
                table: "ReserveItem",
                newName: "IX_ReserveItem_ReserveTimeReceiptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReserveTimeSender",
                table: "ReserveTimeSender",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReserveTimeReceipt",
                table: "ReserveTimeReceipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReserveItem",
                table: "ReserveItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveItem_ReserveTimeReceipt_ReserveTimeReceiptId",
                table: "ReserveItem",
                column: "ReserveTimeReceiptId",
                principalTable: "ReserveTimeReceipt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveItem_ReserveTimeSender_ReserveTimeSenderId",
                table: "ReserveItem",
                column: "ReserveTimeSenderId",
                principalTable: "ReserveTimeSender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveItem_Services_ServiceId",
                table: "ReserveItem",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeReceipt_Businesses_BusinessId",
                table: "ReserveTimeReceipt",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeReceipt_Users_UserId",
                table: "ReserveTimeReceipt",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeSender_Businesses_BusinessInId",
                table: "ReserveTimeSender",
                column: "BusinessInId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeSender_Businesses_BusinessReceiptId",
                table: "ReserveTimeSender",
                column: "BusinessReceiptId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_ReserveTimeReceipt_ReserveTimeId",
                table: "Transaction",
                column: "ReserveTimeId",
                principalTable: "ReserveTimeReceipt",
                principalColumn: "Id");
        }
    }
}
