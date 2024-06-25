using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class BusinessMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Business_BusinessId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Business_City_CityId",
                table: "Business");

            migrationBuilder.DropForeignKey(
                name: "FK_Business_Wallet_WalletId",
                table: "Business");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUser_Business_BusinessesId",
                table: "BusinessUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Artist_ArtistId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Business_BusinessId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Business_BusinessId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveItem_Service_ServiceId",
                table: "ReserveItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Business_BusinessId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeSender_Business_BusinessInId",
                table: "ReserveTimeSender");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeSender_Business_BusinessReceiptId",
                table: "ReserveTimeSender");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Artist_ArtistId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Business_BusinessId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsCredit_Business_BusinessId",
                table: "SmsCredit");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsTemplate_Business_BusinessId",
                table: "SmsTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVIP_Business_BusinessId",
                table: "UserVIP");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVIP_Users_UserId",
                table: "UserVIP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVIP",
                table: "UserVIP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmsTemplate",
                table: "SmsTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmsCredit",
                table: "SmsCredit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Business",
                table: "Business");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.RenameTable(
                name: "UserVIP",
                newName: "UsersVIP");

            migrationBuilder.RenameTable(
                name: "SmsTemplate",
                newName: "SmsTemplates");

            migrationBuilder.RenameTable(
                name: "SmsCredit",
                newName: "SmsCredits");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Business",
                newName: "Businesses");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.RenameIndex(
                name: "IX_UserVIP_UserId",
                table: "UsersVIP",
                newName: "IX_UsersVIP_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVIP_BusinessId",
                table: "UsersVIP",
                newName: "IX_UsersVIP_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_SmsTemplate_BusinessId",
                table: "SmsTemplates",
                newName: "IX_SmsTemplates_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_SmsCredit_BusinessId",
                table: "SmsCredits",
                newName: "IX_SmsCredits_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_BusinessId",
                table: "Services",
                newName: "IX_Services_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ArtistId",
                table: "Services",
                newName: "IX_Services_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_BusinessId",
                table: "Posts",
                newName: "IX_Posts_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Business_WalletId",
                table: "Businesses",
                newName: "IX_Businesses_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Business_CityId",
                table: "Businesses",
                newName: "IX_Businesses_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_BusinessId",
                table: "Artists",
                newName: "IX_Artists_BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersVIP",
                table: "UsersVIP",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmsTemplates",
                table: "SmsTemplates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmsCredits",
                table: "SmsCredits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Businesses_BusinessId",
                table: "Artists",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_City_CityId",
                table: "Businesses",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Wallet_WalletId",
                table: "Businesses",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUser_Businesses_BusinessesId",
                table: "BusinessUser",
                column: "BusinessesId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Artists_ArtistId",
                table: "Point",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Businesses_BusinessId",
                table: "Point",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Businesses_BusinessId",
                table: "Posts",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Services_Artists_ArtistId",
                table: "Services",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Businesses_BusinessId",
                table: "Services",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsCredits_Businesses_BusinessId",
                table: "SmsCredits",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsTemplates_Businesses_BusinessId",
                table: "SmsTemplates",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersVIP_Businesses_BusinessId",
                table: "UsersVIP",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersVIP_Users_UserId",
                table: "UsersVIP",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Businesses_BusinessId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_City_CityId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Wallet_WalletId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUser_Businesses_BusinessesId",
                table: "BusinessUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Artists_ArtistId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Businesses_BusinessId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Businesses_BusinessId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveItem_Services_ServiceId",
                table: "ReserveItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Businesses_BusinessId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeSender_Businesses_BusinessInId",
                table: "ReserveTimeSender");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeSender_Businesses_BusinessReceiptId",
                table: "ReserveTimeSender");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Artists_ArtistId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Businesses_BusinessId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsCredits_Businesses_BusinessId",
                table: "SmsCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsTemplates_Businesses_BusinessId",
                table: "SmsTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersVIP_Businesses_BusinessId",
                table: "UsersVIP");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersVIP_Users_UserId",
                table: "UsersVIP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersVIP",
                table: "UsersVIP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmsTemplates",
                table: "SmsTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmsCredits",
                table: "SmsCredits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.RenameTable(
                name: "UsersVIP",
                newName: "UserVIP");

            migrationBuilder.RenameTable(
                name: "SmsTemplates",
                newName: "SmsTemplate");

            migrationBuilder.RenameTable(
                name: "SmsCredits",
                newName: "SmsCredit");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "Businesses",
                newName: "Business");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.RenameIndex(
                name: "IX_UsersVIP_UserId",
                table: "UserVIP",
                newName: "IX_UserVIP_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersVIP_BusinessId",
                table: "UserVIP",
                newName: "IX_UserVIP_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_SmsTemplates_BusinessId",
                table: "SmsTemplate",
                newName: "IX_SmsTemplate_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_SmsCredits_BusinessId",
                table: "SmsCredit",
                newName: "IX_SmsCredit_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_BusinessId",
                table: "Service",
                newName: "IX_Service_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ArtistId",
                table: "Service",
                newName: "IX_Service_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_BusinessId",
                table: "Post",
                newName: "IX_Post_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Businesses_WalletId",
                table: "Business",
                newName: "IX_Business_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Businesses_CityId",
                table: "Business",
                newName: "IX_Business_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_BusinessId",
                table: "Artist",
                newName: "IX_Artist_BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVIP",
                table: "UserVIP",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmsTemplate",
                table: "SmsTemplate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmsCredit",
                table: "SmsCredit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Business",
                table: "Business",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Business_BusinessId",
                table: "Artist",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Business_City_CityId",
                table: "Business",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Business_Wallet_WalletId",
                table: "Business",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUser_Business_BusinessesId",
                table: "BusinessUser",
                column: "BusinessesId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Artist_ArtistId",
                table: "Point",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Business_BusinessId",
                table: "Point",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Business_BusinessId",
                table: "Post",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveItem_Service_ServiceId",
                table: "ReserveItem",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeReceipt_Business_BusinessId",
                table: "ReserveTimeReceipt",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeSender_Business_BusinessInId",
                table: "ReserveTimeSender",
                column: "BusinessInId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeSender_Business_BusinessReceiptId",
                table: "ReserveTimeSender",
                column: "BusinessReceiptId",
                principalTable: "Business",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Artist_ArtistId",
                table: "Service",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Business_BusinessId",
                table: "Service",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsCredit_Business_BusinessId",
                table: "SmsCredit",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsTemplate_Business_BusinessId",
                table: "SmsTemplate",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVIP_Business_BusinessId",
                table: "UserVIP",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVIP_Users_UserId",
                table: "UserVIP",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
