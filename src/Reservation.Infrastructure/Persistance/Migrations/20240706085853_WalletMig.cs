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
                name: "FK_Businesses_SubCategories_SubCategoryId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Wallet_WalletId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_SubCategories_SubCategoryId",
                table: "Points");

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

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTimesSender_BusinessInId",
                table: "ReserveTimesSender");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTimesReceipt_BusinessId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropIndex(
                name: "IX_Points_SubCategoryId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_SubCategoryId",
                table: "Businesses");

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
                name: "SubCategoryId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "AveragePoint",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "Average",
                table: "Artists");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsPay",
                table: "ReserveTimesSender",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsPay",
                table: "ReserveTimesReceipt",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionReceiptId",
                table: "ReserveTimesReceipt",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentCategoryId",
                table: "Categories",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.AddColumn<int[]>(
                name: "Holidays",
                table: "Businesses",
                type: "integer[]",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "BusinessRequestPays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    IsPay = table.Column<bool>(type: "boolean", nullable: false),
                    PayDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Authorizy = table.Column<string>(type: "text", nullable: true),
                    RefId = table.Column<int>(type: "integer", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRequestPays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    IsPay = table.Column<bool>(type: "boolean", nullable: false),
                    PayDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Authorizy = table.Column<string>(type: "text", nullable: true),
                    RefId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRequestPays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRequestPays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "OTPCode", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("0a64004e-6eac-4aac-b74a-865b9113d2ff"), null, new DateTime(2024, 7, 6, 12, 28, 52, 661, DateTimeKind.Local).AddTicks(6705), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "09111111111", "Admin", null });

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRequestPays_BusinessId",
                table: "BusinessRequestPays",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequestPays_UserId",
                table: "UserRequestPays",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Wallets_WalletId",
                table: "Businesses",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
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
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

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

            migrationBuilder.DropTable(
                name: "BusinessRequestPays");

            migrationBuilder.DropTable(
                name: "UserRequestPays");

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

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a64004e-6eac-4aac-b74a-865b9113d2ff"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OTPCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsPay",
                table: "ReserveTimesSender");

            migrationBuilder.DropColumn(
                name: "BusinessReceiptId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropColumn(
                name: "BusinessSenderId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropColumn(
                name: "IsPay",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropColumn(
                name: "TransactionReceiptId",
                table: "ReserveTimesReceipt");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "EndHoursOfWor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "Holidays",
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

            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryId",
                table: "Points",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AveragePoint",
                table: "Categories",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

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
                name: "SubCategoryId",
                table: "Businesses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Average",
                table: "Artists",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    AveragePoint = table.Column<double>(type: "double precision", nullable: false),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesSender_BusinessInId",
                table: "ReserveTimesSender",
                column: "BusinessInId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesReceipt_BusinessId",
                table: "ReserveTimesReceipt",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_SubCategoryId",
                table: "Points",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_SubCategoryId",
                table: "Businesses",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReserveTimeId",
                table: "Transaction",
                column: "ReserveTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_SubCategories_SubCategoryId",
                table: "Businesses",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Wallet_WalletId",
                table: "Businesses",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_SubCategories_SubCategoryId",
                table: "Points",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id");

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
