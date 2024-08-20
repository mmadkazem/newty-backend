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
                name: "FK_BusinessCategory_Business_BusinessesId",
                table: "BusinessCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessRequestPay_Business_BusinessId",
                table: "BusinessRequestPay");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessService_Artist_ArtistId",
                table: "BusinessService");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessService_Business_BusinessId",
                table: "BusinessService");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUser_Business_BusinessesId",
                table: "BusinessUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupon_BusinessService_ServiceId",
                table: "Coupon");

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
                name: "FK_ReserveItem_BusinessService_ServiceId",
                table: "ReserveItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Business_BusinessReceiptId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Business_BusinessSenderId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeSender_Business_BusinessReceiptId",
                table: "ReserveTimeSender");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeSender_Business_BusinessSenderId",
                table: "ReserveTimeSender");

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
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessService",
                table: "BusinessService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Business",
                table: "Business");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.DeleteData(
                table: "TransferFee",
                keyColumn: "Id",
                keyValue: new Guid("77226619-ee74-493c-aea0-28d9638988fc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e78a53e7-027f-4b43-8890-496a6883db8f"));

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
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "BusinessService",
                newName: "Services");

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
                name: "IX_Post_BusinessId",
                table: "Posts",
                newName: "IX_Posts_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessService_BusinessId",
                table: "Services",
                newName: "IX_Services_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessService_ArtistId",
                table: "Services",
                newName: "IX_Services_ArtistId");

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
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("021a54be-4266-4780-ad0c-7680688d9f36"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bojnourd" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7026) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("044947b9-e2fa-48b1-b0f2-361da01e10d3"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "isfahan", "esfahan" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6683) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("0a6e7713-475a-4192-bc75-18bdf3849077"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kashan" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7689) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("0f10d758-0cba-46df-92a9-8fdb3858cca7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sabzevar" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7503) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("12cba520-6cb8-48aa-a464-8dbfc45b4acc"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kish" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6717) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("15e161a8-554e-4d84-a011-f17e1e4bbc3f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zahedan" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7457) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("160c7d8e-d839-4b4c-a8c9-39cbe5a38d37"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "noshahr" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("172c2c8f-1800-4e0f-acd4-ef5a1e2f9213"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jahrom" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("19349721-8952-4623-9863-f17b856e4201"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khorramabad" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7347) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("19705072-6766-478e-b1f1-099603369129"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ilam" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7011) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("1b6c2033-9ec8-4167-8273-058f83dc403a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "arak" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("1cb92aa7-68a3-4e7c-a308-49d0dfed5841"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omidieh" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7641) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("223eba20-a0ed-4f63-ac3e-b4cc50c4923f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "maragheh" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7549) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2459068b-6b0c-47a1-a299-18900fbd4ed4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shiraz" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6497) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2ac079e7-d52d-46c3-8ef2-2f951e9a360d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahroud" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7579) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2b0f4a8c-ae50-483e-ab43-c377d5542c57"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omIdieh" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6815) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2d22b9f7-ec8f-446c-9eed-af22d21ff194"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gorgan" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2ffbaf0b-9621-4f8d-9156-6a18238f9b53"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar lengeh" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("36aedc91-6b85-4201-baee-394102453b86"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khoy" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7363) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("38d0d97a-dc59-4067-b255-81b0d237ed7c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "asalouyeh" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7625) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("392876fd-f90d-4825-a32b-46feafa7ef4d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zabol" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7441) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("3f092d22-a361-4380-8201-1deac30c7eb8"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rafsanjan" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7425) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("3f7f9b70-088e-4c51-ab5c-910f38623793"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "iranshahr" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6993) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("4166380e-133a-4428-ba44-6298406dca2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lamard" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7855) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("44e5f7fb-a9e6-4f1e-bb25-03924a06c124"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lar" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("4a46d1f1-8bb0-4cb8-85c7-1929cb06e3b7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zanjan" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7472) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("4df58cb6-68cf-459a-a09c-9b233a1db4ab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kolaleh" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7793) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("511680d1-3191-4d44-aad6-5f46f4eee182"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ahwaz", "ahvaz" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6474) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("5319fd9d-5d6f-4c8f-9cef-5385dfcbc545"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bushehr", "booshehr" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7076) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("56245a47-a6dd-408e-8f55-7886db01be2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "abadan" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6733) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("57f276e4-b2ce-4fc8-a346-180b1c412de1"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "chabahar" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7306) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("634826cc-9f97-48f9-a8c7-55155dcf0073"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yasouj" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("6979e8ce-5f2a-468e-b579-4ce2c27100c9"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tehran" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6267) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("718e45e8-a398-4725-bfe6-ad184b0e9541"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sanandaj" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("73c81768-44a1-4a94-be4e-f79eaf577167"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rasht" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7410) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("75c76800-2a81-4b4e-a6d6-ad18827ece45"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "dezful" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7379) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("76482101-3aaa-4ba9-a95e-a1d300e7c92e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ramsar" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7394) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("882113bb-a3d9-44a9-a0a3-7774c98c3b0e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "birjand" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7095) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("8a48d0ae-4297-46a6-926e-19e936a08428"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jiroft" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7291) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("8c49b9f4-90c8-4fab-be77-6403bfeeb487"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahrekord" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7595) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("921c90cc-0170-4b2c-9ceb-702c78e3b775"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "karaj" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7704) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("974203f2-f7d6-410f-91bc-89a7a706f964"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yazd" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(8007) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("99e93656-edd9-4d2d-bd43-8b81437dba0f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "syrjan" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7564) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("9c592f92-6aab-4d8c-8526-4d99631b5d95"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kerman" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7719) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("a1786c97-9eaf-4c78-96ca-f31b935bc667"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bam" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7042) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("a3231945-d2ca-4ff0-85c9-21ae34da5f42"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khark" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7331) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("ad6c225d-3315-44c1-a0ae-39bb7e60722c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ardabil" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6765) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("ad8c177c-61c3-4243-aadc-092c897dc72f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "semnan" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7518) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("b595d16b-7be5-48b4-b8b2-cc4d10c6946c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gachsaran" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7808) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("b713db78-eac0-48e5-a576-7a14057a5542"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "makou" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("c40478c3-8165-41f6-bc5c-73e82a9c7305"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "pars-abad" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d1de7180-20c8-4cf9-a90c-04720d91c50a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabriz" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6701) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d5e3997e-6cf9-4080-90ab-86a5d6b45953"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jask" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7126) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d5e46c30-604f-41f7-8188-84fca3b06b24"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mahshahr" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7885) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d6489a65-5488-4967-9ee5-77067554f936"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sari" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7487) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("dabec0ed-ba17-4807-9041-d6706aa0aa49"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabas" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7610) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("dda8a974-f10d-4b38-9c5a-bf085d85f5e4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qom", "ghom" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7672) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("e1d368d9-45ab-4daf-a4bf-b4f09b575f4f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar abbas" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6662) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("e3eec5c4-1fbb-4ff0-b54c-bfc6c5fbf7fa"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kermanshah" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7776) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("f91c4eb3-621a-4db0-900c-fc24198f8718"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qeshm" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7657) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("fe6295c8-50d1-4ce7-99c0-d681edecbbab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mashhad" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6645) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("fe9a4b32-844e-49ec-ad99-21e49f771552"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "hamedan" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(7915) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("ff002bb6-d9e4-431a-83d5-bff8b3679de4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "orumiyeh" }, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(6799) });

            migrationBuilder.InsertData(
                table: "TransferFee",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("1c2af260-0847-493b-b301-ac7124e7c3c0"), new DateTime(2024, 8, 15, 19, 22, 42, 33, DateTimeKind.Local).AddTicks(9715), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("29aa2ac9-5a46-43a4-acef-5395c0c0f6bf"), null, new DateTime(2024, 8, 15, 19, 22, 42, 32, DateTimeKind.Local).AddTicks(1416), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Businesses_BusinessId",
                table: "Artists",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessCategory_Businesses_BusinessesId",
                table: "BusinessCategory",
                column: "BusinessesId",
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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessRequestPay_Businesses_BusinessId",
                table: "BusinessRequestPay",
                column: "BusinessId",
                principalTable: "Businesses",
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
                name: "FK_Coupon_Services_ServiceId",
                table: "Coupon",
                column: "ServiceId",
                principalTable: "Services",
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
                name: "FK_ReserveTimeSender_Businesses_BusinessReceiptId",
                table: "ReserveTimeSender",
                column: "BusinessReceiptId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeSender_Businesses_BusinessSenderId",
                table: "ReserveTimeSender",
                column: "BusinessSenderId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_BusinessCategory_Businesses_BusinessesId",
                table: "BusinessCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_City_CityId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Wallet_WalletId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessRequestPay_Businesses_BusinessId",
                table: "BusinessRequestPay");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUser_Businesses_BusinessesId",
                table: "BusinessUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupon_Services_ServiceId",
                table: "Coupon");

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
                name: "FK_ReserveTimeReceipt_Businesses_BusinessReceiptId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeReceipt_Businesses_BusinessSenderId",
                table: "ReserveTimeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeSender_Businesses_BusinessReceiptId",
                table: "ReserveTimeSender");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTimeSender_Businesses_BusinessSenderId",
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

            migrationBuilder.DeleteData(
                table: "TransferFee",
                keyColumn: "Id",
                keyValue: new Guid("1c2af260-0847-493b-b301-ac7124e7c3c0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("29aa2ac9-5a46-43a4-acef-5395c0c0f6bf"));

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
                newName: "BusinessService");

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
                table: "BusinessService",
                newName: "IX_BusinessService_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ArtistId",
                table: "BusinessService",
                newName: "IX_BusinessService_ArtistId");

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
                name: "PK_BusinessService",
                table: "BusinessService",
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

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("021a54be-4266-4780-ad0c-7680688d9f36"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bojnourd" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4463) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("044947b9-e2fa-48b1-b0f2-361da01e10d3"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "isfahan", "esfahan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4299) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("0a6e7713-475a-4192-bc75-18bdf3849077"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kashan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4991) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("0f10d758-0cba-46df-92a9-8fdb3858cca7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sabzevar" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4803) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("12cba520-6cb8-48aa-a464-8dbfc45b4acc"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kish" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("15e161a8-554e-4d84-a011-f17e1e4bbc3f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zahedan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4757) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("160c7d8e-d839-4b4c-a8c9-39cbe5a38d37"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "noshahr" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5168) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("172c2c8f-1800-4e0f-acd4-ef5a1e2f9213"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jahrom" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4576) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("19349721-8952-4623-9863-f17b856e4201"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khorramabad" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4646) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("19705072-6766-478e-b1f1-099603369129"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ilam" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4447) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("1b6c2033-9ec8-4167-8273-058f83dc403a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "arak" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4367) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("1cb92aa7-68a3-4e7c-a308-49d0dfed5841"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omidieh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4942) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("223eba20-a0ed-4f63-ac3e-b4cc50c4923f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "maragheh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4849) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2459068b-6b0c-47a1-a299-18900fbd4ed4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shiraz" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2ac079e7-d52d-46c3-8ef2-2f951e9a360d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahroud" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2b0f4a8c-ae50-483e-ab43-c377d5542c57"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omIdieh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4415) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2d22b9f7-ec8f-446c-9eed-af22d21ff194"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gorgan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5091) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2ffbaf0b-9621-4f8d-9156-6a18238f9b53"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar lengeh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4496) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("36aedc91-6b85-4201-baee-394102453b86"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khoy" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4662) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("38d0d97a-dc59-4067-b255-81b0d237ed7c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "asalouyeh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("392876fd-f90d-4825-a32b-46feafa7ef4d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zabol" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("3f092d22-a361-4380-8201-1deac30c7eb8"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rafsanjan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4724) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("3f7f9b70-088e-4c51-ab5c-910f38623793"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "iranshahr" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("4166380e-133a-4428-ba44-6298406dca2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lamard" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5122) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("44e5f7fb-a9e6-4f1e-bb25-03924a06c124"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lar" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5107) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("4a46d1f1-8bb0-4cb8-85c7-1929cb06e3b7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zanjan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4772) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("4df58cb6-68cf-459a-a09c-9b233a1db4ab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kolaleh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("511680d1-3191-4d44-aad6-5f46f4eee182"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ahwaz", "ahvaz" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4087) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("5319fd9d-5d6f-4c8f-9cef-5385dfcbc545"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bushehr", "booshehr" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4512) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("56245a47-a6dd-408e-8f55-7886db01be2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "abadan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("57f276e4-b2ce-4fc8-a346-180b1c412de1"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "chabahar" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4607) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("634826cc-9f97-48f9-a8c7-55155dcf0073"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yasouj" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5199) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("6979e8ce-5f2a-468e-b579-4ce2c27100c9"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tehran" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(3753) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("718e45e8-a398-4725-bfe6-ad184b0e9541"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sanandaj" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4834) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("73c81768-44a1-4a94-be4e-f79eaf577167"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rasht" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4708) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("75c76800-2a81-4b4e-a6d6-ad18827ece45"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "dezful" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4677) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("76482101-3aaa-4ba9-a95e-a1d300e7c92e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ramsar" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4693) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("882113bb-a3d9-44a9-a0a3-7774c98c3b0e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "birjand" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4529) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("8a48d0ae-4297-46a6-926e-19e936a08428"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jiroft" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("8c49b9f4-90c8-4fab-be77-6403bfeeb487"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahrekord" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4895) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("921c90cc-0170-4b2c-9ceb-702c78e3b775"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "karaj" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5006) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("974203f2-f7d6-410f-91bc-89a7a706f964"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yazd" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5215) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("99e93656-edd9-4d2d-bd43-8b81437dba0f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "syrjan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("9c592f92-6aab-4d8c-8526-4d99631b5d95"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kerman" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5022) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("a1786c97-9eaf-4c78-96ca-f31b935bc667"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bam" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4479) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("a3231945-d2ca-4ff0-85c9-21ae34da5f42"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khark" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4631) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("ad6c225d-3315-44c1-a0ae-39bb7e60722c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ardabil" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4383) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("ad8c177c-61c3-4243-aadc-092c897dc72f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "semnan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4818) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("b595d16b-7be5-48b4-b8b2-cc4d10c6946c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gachsaran" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("b713db78-eac0-48e5-a576-7a14057a5542"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "makou" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5138) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("c40478c3-8165-41f6-bc5c-73e82a9c7305"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "pars-abad" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4545) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d1de7180-20c8-4cf9-a90c-04720d91c50a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabriz" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4318) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d5e3997e-6cf9-4080-90ab-86a5d6b45953"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jask" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4560) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d5e46c30-604f-41f7-8188-84fca3b06b24"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mahshahr" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5153) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d6489a65-5488-4967-9ee5-77067554f936"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sari" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4787) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("dabec0ed-ba17-4807-9041-d6706aa0aa49"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabas" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4911) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("dda8a974-f10d-4b38-9c5a-bf085d85f5e4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qom", "ghom" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4973) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("e1d368d9-45ab-4daf-a4bf-b4f09b575f4f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar abbas" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4277) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("e3eec5c4-1fbb-4ff0-b54c-bfc6c5fbf7fa"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kermanshah" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5044) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("f91c4eb3-621a-4db0-900c-fc24198f8718"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qeshm" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4958) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("fe6295c8-50d1-4ce7-99c0-d681edecbbab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mashhad" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("fe9a4b32-844e-49ec-ad99-21e49f771552"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "hamedan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5184) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("ff002bb6-d9e4-431a-83d5-bff8b3679de4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "orumiyeh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4399) });

            migrationBuilder.InsertData(
                table: "TransferFee",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("77226619-ee74-493c-aea0-28d9638988fc"), new DateTime(2024, 8, 15, 19, 19, 15, 148, DateTimeKind.Local).AddTicks(5503), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("e78a53e7-027f-4b43-8890-496a6883db8f"), null, new DateTime(2024, 8, 15, 19, 19, 15, 146, DateTimeKind.Local).AddTicks(9772), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessCategory_Business_BusinessesId",
                table: "BusinessCategory",
                column: "BusinessesId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessRequestPay_Business_BusinessId",
                table: "BusinessRequestPay",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessService_Artist_ArtistId",
                table: "BusinessService",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessService_Business_BusinessId",
                table: "BusinessService",
                column: "BusinessId",
                principalTable: "Business",
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
                name: "FK_Coupon_BusinessService_ServiceId",
                table: "Coupon",
                column: "ServiceId",
                principalTable: "BusinessService",
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
                name: "FK_ReserveItem_BusinessService_ServiceId",
                table: "ReserveItem",
                column: "ServiceId",
                principalTable: "BusinessService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeReceipt_Business_BusinessReceiptId",
                table: "ReserveTimeReceipt",
                column: "BusinessReceiptId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeReceipt_Business_BusinessSenderId",
                table: "ReserveTimeReceipt",
                column: "BusinessSenderId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeSender_Business_BusinessReceiptId",
                table: "ReserveTimeSender",
                column: "BusinessReceiptId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTimeSender_Business_BusinessSenderId",
                table: "ReserveTimeSender",
                column: "BusinessSenderId",
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
