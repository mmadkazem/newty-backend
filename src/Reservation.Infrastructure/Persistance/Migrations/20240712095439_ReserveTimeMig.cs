using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ReserveTimeMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReserveItem_ReserveTimeReceipt_ReserveTimeReceiptId",
                table: "ReserveItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveItem_Services_ServiceId",
                table: "ReserveItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Businesses_BusinessReceiptId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Businesses_BusinessSenderId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Transaction_TransactionReceiptId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Transaction_TransactionSenderId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Users_UserId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveTimeReceipt",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveItem",
                table: "ReserveItem");

            migrationBuilder.RenameTable(
                name: "ReserveTimeReceipt",
                newName: "ReserveTimesReceipt");

            migrationBuilder.RenameTable(
                name: "ReserveItem",
                newName: "ReserveItems");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimeReceipt_UserId",
                table: "ReserveTimesReceipt",
                newName: "IX_ReserveTimesReceipt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimeReceipt_TransactionSenderId",
                table: "ReserveTimesReceipt",
                newName: "IX_ReserveTimesReceipt_TransactionSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimeReceipt_TransactionReceiptId",
                table: "ReserveTimesReceipt",
                newName: "IX_ReserveTimesReceipt_TransactionReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimeReceipt_BusinessSenderId",
                table: "ReserveTimesReceipt",
                newName: "IX_ReserveTimesReceipt_BusinessSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimeReceipt_BusinessReceiptId",
                table: "ReserveTimesReceipt",
                newName: "IX_ReserveTimesReceipt_BusinessReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveItem_ServiceId",
                table: "ReserveItems",
                newName: "IX_ReserveItems_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveItem_ReserveTimeReceiptId",
                table: "ReserveItems",
                newName: "IX_ReserveItems_ReserveTimeReceiptId");

            migrationBuilder.AddColumn<Guid>(
                name: "ReserveTimeSenderId",
                table: "ReserveItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReserveTimesReceipt",
                table: "ReserveTimesReceipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReserveItems",
                table: "ReserveItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ReserveTimesSender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    IsPay = table.Column<bool>(type: "boolean", nullable: false),
                    BusinessSenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessReceiptId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveTimesSender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveTimesSender_Businesses_BusinessReceiptId",
                        column: x => x.BusinessReceiptId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimesSender_Businesses_BusinessSenderId",
                        column: x => x.BusinessSenderId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ReserveTimeSenderId",
                table: "ReserveItems",
                column: "ReserveTimeSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesSender_BusinessReceiptId",
                table: "ReserveTimesSender",
                column: "BusinessReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesSender_BusinessSenderId",
                table: "ReserveTimesSender",
                column: "BusinessSenderId");

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
                name: "FK_ReserveTimesReceipt_Transaction_TransactionReceiptId",
                table: "ReserveTimesReceipt",
                column: "TransactionReceiptId",
                principalTable: "Transaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesReceipt_Transaction_TransactionSenderId",
                table: "ReserveTimesReceipt",
                column: "TransactionSenderId",
                principalTable: "Transaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimesReceipt_Users_UserId",
                table: "ReserveTimesReceipt",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_ReserveTimesReceipt_Businesses_BusinessReceiptId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Businesses_BusinessSenderId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Transaction_TransactionReceiptId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Transaction_TransactionSenderId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimesReceipt_Users_UserId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropTable(
                name: "ReserveTimesSender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveTimesReceipt",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveItems",
                table: "ReserveItems");

            migrationBuilder.DropIndex(
                name: "IX_ReserveItems_ReserveTimeSenderId",
                table: "ReserveItems");

            migrationBuilder.DropColumn(
                name: "ReserveTimeSenderId",
                table: "ReserveItems");

            migrationBuilder.RenameTable(
                name: "ReserveTimesReceipt",
                newName: "ReserveTimeReceipt");

            migrationBuilder.RenameTable(
                name: "ReserveItems",
                newName: "ReserveItem");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimesReceipt_UserId",
                table: "ReserveTimeReceipt",
                newName: "IX_ReserveTimeReceipt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimesReceipt_TransactionSenderId",
                table: "ReserveTimeReceipt",
                newName: "IX_ReserveTimeReceipt_TransactionSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimesReceipt_TransactionReceiptId",
                table: "ReserveTimeReceipt",
                newName: "IX_ReserveTimeReceipt_TransactionReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimesReceipt_BusinessSenderId",
                table: "ReserveTimeReceipt",
                newName: "IX_ReserveTimeReceipt_BusinessSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveTimesReceipt_BusinessReceiptId",
                table: "ReserveTimeReceipt",
                newName: "IX_ReserveTimeReceipt_BusinessReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveItems_ServiceId",
                table: "ReserveItem",
                newName: "IX_ReserveItem_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveItems_ReserveTimeReceiptId",
                table: "ReserveItem",
                newName: "IX_ReserveItem_ReserveTimeReceiptId");

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
                name: "FK_ReserveItem_Services_ServiceId",
                table: "ReserveItem",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeReceipt_Businesses_BusinessReceiptId",
                table: "ReserveTimeReceipt",
                column: "BusinessReceiptId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeReceipt_Businesses_BusinessSenderId",
                table: "ReserveTimeReceipt",
                column: "BusinessSenderId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeReceipt_Transaction_TransactionReceiptId",
                table: "ReserveTimeReceipt",
                column: "TransactionReceiptId",
                principalTable: "Transaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeReceipt_Transaction_TransactionSenderId",
                table: "ReserveTimeReceipt",
                column: "TransactionSenderId",
                principalTable: "Transaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeReceipt_Users_UserId",
                table: "ReserveTimeReceipt",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
