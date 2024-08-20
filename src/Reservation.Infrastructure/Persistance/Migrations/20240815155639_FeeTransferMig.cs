#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class FeeTransferMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TransferFee",
                table: "TransferFee");

            migrationBuilder.DeleteData(
                table: "TransferFee",
                keyColumn: "Id",
                keyValue: new Guid("e9494674-244f-4682-b2ee-3f1e4d8b3b10"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af027e84-1062-4257-91f8-33ccab010cae"));

            migrationBuilder.RenameTable(
                name: "TransferFee",
                newName: "TransferFees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransferFees",
                table: "TransferFees",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("021a54be-4266-4780-ad0c-7680688d9f36"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bojnourd" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7019) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("044947b9-e2fa-48b1-b0f2-361da01e10d3"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "isfahan", "esfahan" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6764) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0a6e7713-475a-4192-bc75-18bdf3849077"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kashan" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7580) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0f10d758-0cba-46df-92a9-8fdb3858cca7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sabzevar" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7387) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("12cba520-6cb8-48aa-a464-8dbfc45b4acc"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kish" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("15e161a8-554e-4d84-a011-f17e1e4bbc3f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zahedan" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7340) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("160c7d8e-d839-4b4c-a8c9-39cbe5a38d37"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "noshahr" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7766) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("172c2c8f-1800-4e0f-acd4-ef5a1e2f9213"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jahrom" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7152) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("19349721-8952-4623-9863-f17b856e4201"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khorramabad" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7226) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("19705072-6766-478e-b1f1-099603369129"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ilam" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6993) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1b6c2033-9ec8-4167-8273-058f83dc403a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "arak" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6872) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1cb92aa7-68a3-4e7c-a308-49d0dfed5841"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omidieh" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7529) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("223eba20-a0ed-4f63-ac3e-b4cc50c4923f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "maragheh" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7434) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2459068b-6b0c-47a1-a299-18900fbd4ed4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shiraz" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2ac079e7-d52d-46c3-8ef2-2f951e9a360d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahroud" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7465) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2b0f4a8c-ae50-483e-ab43-c377d5542c57"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omIdieh" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6943) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2d22b9f7-ec8f-446c-9eed-af22d21ff194"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gorgan" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7689) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2ffbaf0b-9621-4f8d-9156-6a18238f9b53"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar lengeh" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("36aedc91-6b85-4201-baee-394102453b86"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khoy" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7243) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("38d0d97a-dc59-4067-b255-81b0d237ed7c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "asalouyeh" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7513) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("392876fd-f90d-4825-a32b-46feafa7ef4d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zabol" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7323) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3f092d22-a361-4380-8201-1deac30c7eb8"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rafsanjan" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3f7f9b70-088e-4c51-ab5c-910f38623793"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "iranshahr" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6967) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4166380e-133a-4428-ba44-6298406dca2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lamard" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7719) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("44e5f7fb-a9e6-4f1e-bb25-03924a06c124"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lar" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7704) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4a46d1f1-8bb0-4cb8-85c7-1929cb06e3b7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zanjan" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4df58cb6-68cf-459a-a09c-9b233a1db4ab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kolaleh" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7657) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("511680d1-3191-4d44-aad6-5f46f4eee182"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ahwaz", "ahvaz" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6676) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5319fd9d-5d6f-4c8f-9cef-5385dfcbc545"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bushehr", "booshehr" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7086) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("56245a47-a6dd-408e-8f55-7886db01be2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "abadan" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("57f276e4-b2ce-4fc8-a346-180b1c412de1"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "chabahar" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("634826cc-9f97-48f9-a8c7-55155dcf0073"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yasouj" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7797) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6979e8ce-5f2a-468e-b579-4ce2c27100c9"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tehran" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6393) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("718e45e8-a398-4725-bfe6-ad184b0e9541"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sanandaj" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("73c81768-44a1-4a94-be4e-f79eaf577167"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rasht" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7291) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("75c76800-2a81-4b4e-a6d6-ad18827ece45"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "dezful" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("76482101-3aaa-4ba9-a95e-a1d300e7c92e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ramsar" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("882113bb-a3d9-44a9-a0a3-7774c98c3b0e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "birjand" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7104) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8a48d0ae-4297-46a6-926e-19e936a08428"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jiroft" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7168) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8c49b9f4-90c8-4fab-be77-6403bfeeb487"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahrekord" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7481) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("921c90cc-0170-4b2c-9ceb-702c78e3b775"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "karaj" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7595) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("974203f2-f7d6-410f-91bc-89a7a706f964"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yazd" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7812) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("99e93656-edd9-4d2d-bd43-8b81437dba0f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "syrjan" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c592f92-6aab-4d8c-8526-4d99631b5d95"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kerman" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7613) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a1786c97-9eaf-4c78-96ca-f31b935bc667"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bam" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a3231945-d2ca-4ff0-85c9-21ae34da5f42"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khark" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ad6c225d-3315-44c1-a0ae-39bb7e60722c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ardabil" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ad8c177c-61c3-4243-aadc-092c897dc72f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "semnan" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7403) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b595d16b-7be5-48b4-b8b2-cc4d10c6946c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gachsaran" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7673) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b713db78-eac0-48e5-a576-7a14057a5542"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "makou" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7735) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c40478c3-8165-41f6-bc5c-73e82a9c7305"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "pars-abad" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d1de7180-20c8-4cf9-a90c-04720d91c50a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabriz" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6794) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d5e3997e-6cf9-4080-90ab-86a5d6b45953"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jask" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d5e46c30-604f-41f7-8188-84fca3b06b24"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mahshahr" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d6489a65-5488-4967-9ee5-77067554f936"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sari" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7371) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dabec0ed-ba17-4807-9041-d6706aa0aa49"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabas" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7497) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dda8a974-f10d-4b38-9c5a-bf085d85f5e4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qom", "ghom" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e1d368d9-45ab-4daf-a4bf-b4f09b575f4f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar abbas" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6734) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e3eec5c4-1fbb-4ff0-b54c-bfc6c5fbf7fa"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kermanshah" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7640) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f91c4eb3-621a-4db0-900c-fc24198f8718"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qeshm" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7546) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fe6295c8-50d1-4ce7-99c0-d681edecbbab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mashhad" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6717) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fe9a4b32-844e-49ec-ad99-21e49f771552"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "hamedan" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(7782) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ff002bb6-d9e4-431a-83d5-bff8b3679de4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "orumiyeh" }, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(6919) });

            migrationBuilder.InsertData(
                table: "TransferFees",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("e2635bc0-c7f5-47cf-88c6-dc9cf3c125a0"), new DateTime(2024, 8, 15, 19, 26, 39, 140, DateTimeKind.Local).AddTicks(972), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("4cafffeb-30af-4bb6-9457-cfaaac52bc71"), null, new DateTime(2024, 8, 15, 19, 26, 39, 139, DateTimeKind.Local).AddTicks(746), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TransferFees",
                table: "TransferFees");

            migrationBuilder.DeleteData(
                table: "TransferFees",
                keyColumn: "Id",
                keyValue: new Guid("e2635bc0-c7f5-47cf-88c6-dc9cf3c125a0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4cafffeb-30af-4bb6-9457-cfaaac52bc71"));

            migrationBuilder.RenameTable(
                name: "TransferFees",
                newName: "TransferFee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransferFee",
                table: "TransferFee",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("021a54be-4266-4780-ad0c-7680688d9f36"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bojnourd" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4484) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("044947b9-e2fa-48b1-b0f2-361da01e10d3"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "isfahan", "esfahan" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4319) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0a6e7713-475a-4192-bc75-18bdf3849077"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kashan" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5033) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0f10d758-0cba-46df-92a9-8fdb3858cca7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sabzevar" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4837) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("12cba520-6cb8-48aa-a464-8dbfc45b4acc"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kish" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4354) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("15e161a8-554e-4d84-a011-f17e1e4bbc3f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zahedan" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("160c7d8e-d839-4b4c-a8c9-39cbe5a38d37"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "noshahr" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5216) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("172c2c8f-1800-4e0f-acd4-ef5a1e2f9213"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jahrom" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("19349721-8952-4623-9863-f17b856e4201"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khorramabad" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("19705072-6766-478e-b1f1-099603369129"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ilam" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4468) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1b6c2033-9ec8-4167-8273-058f83dc403a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "arak" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4388) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1cb92aa7-68a3-4e7c-a308-49d0dfed5841"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omidieh" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4981) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("223eba20-a0ed-4f63-ac3e-b4cc50c4923f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "maragheh" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4885) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2459068b-6b0c-47a1-a299-18900fbd4ed4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shiraz" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2ac079e7-d52d-46c3-8ef2-2f951e9a360d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahroud" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4916) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2b0f4a8c-ae50-483e-ab43-c377d5542c57"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omIdieh" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4435) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2d22b9f7-ec8f-446c-9eed-af22d21ff194"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gorgan" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5136) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2ffbaf0b-9621-4f8d-9156-6a18238f9b53"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar lengeh" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4518) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("36aedc91-6b85-4201-baee-394102453b86"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khoy" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4692) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("38d0d97a-dc59-4067-b255-81b0d237ed7c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "asalouyeh" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4965) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("392876fd-f90d-4825-a32b-46feafa7ef4d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zabol" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4773) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3f092d22-a361-4380-8201-1deac30c7eb8"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rafsanjan" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4756) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3f7f9b70-088e-4c51-ab5c-910f38623793"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "iranshahr" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4450) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4166380e-133a-4428-ba44-6298406dca2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lamard" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5167) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("44e5f7fb-a9e6-4f1e-bb25-03924a06c124"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lar" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4a46d1f1-8bb0-4cb8-85c7-1929cb06e3b7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zanjan" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4df58cb6-68cf-459a-a09c-9b233a1db4ab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kolaleh" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5103) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("511680d1-3191-4d44-aad6-5f46f4eee182"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ahwaz", "ahvaz" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4235) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5319fd9d-5d6f-4c8f-9cef-5385dfcbc545"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bushehr", "booshehr" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4535) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("56245a47-a6dd-408e-8f55-7886db01be2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "abadan" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4371) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("57f276e4-b2ce-4fc8-a346-180b1c412de1"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "chabahar" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4632) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("634826cc-9f97-48f9-a8c7-55155dcf0073"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yasouj" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5248) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6979e8ce-5f2a-468e-b579-4ce2c27100c9"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tehran" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4055) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("718e45e8-a398-4725-bfe6-ad184b0e9541"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sanandaj" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("73c81768-44a1-4a94-be4e-f79eaf577167"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rasht" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("75c76800-2a81-4b4e-a6d6-ad18827ece45"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "dezful" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4709) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("76482101-3aaa-4ba9-a95e-a1d300e7c92e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ramsar" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4724) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("882113bb-a3d9-44a9-a0a3-7774c98c3b0e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "birjand" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4552) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8a48d0ae-4297-46a6-926e-19e936a08428"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jiroft" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4616) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8c49b9f4-90c8-4fab-be77-6403bfeeb487"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahrekord" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("921c90cc-0170-4b2c-9ceb-702c78e3b775"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "karaj" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("974203f2-f7d6-410f-91bc-89a7a706f964"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yazd" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5264) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("99e93656-edd9-4d2d-bd43-8b81437dba0f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "syrjan" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4901) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c592f92-6aab-4d8c-8526-4d99631b5d95"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kerman" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5065) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a1786c97-9eaf-4c78-96ca-f31b935bc667"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bam" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4501) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a3231945-d2ca-4ff0-85c9-21ae34da5f42"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khark" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4659) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ad6c225d-3315-44c1-a0ae-39bb7e60722c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ardabil" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4403) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ad8c177c-61c3-4243-aadc-092c897dc72f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "semnan" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b595d16b-7be5-48b4-b8b2-cc4d10c6946c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gachsaran" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5119) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b713db78-eac0-48e5-a576-7a14057a5542"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "makou" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5183) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c40478c3-8165-41f6-bc5c-73e82a9c7305"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "pars-abad" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4569) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d1de7180-20c8-4cf9-a90c-04720d91c50a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabriz" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4338) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d5e3997e-6cf9-4080-90ab-86a5d6b45953"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jask" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d5e46c30-604f-41f7-8188-84fca3b06b24"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mahshahr" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5199) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d6489a65-5488-4967-9ee5-77067554f936"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sari" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4821) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dabec0ed-ba17-4807-9041-d6706aa0aa49"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabas" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4949) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dda8a974-f10d-4b38-9c5a-bf085d85f5e4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qom", "ghom" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5015) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e1d368d9-45ab-4daf-a4bf-b4f09b575f4f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar abbas" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e3eec5c4-1fbb-4ff0-b54c-bfc6c5fbf7fa"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kermanshah" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5086) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f91c4eb3-621a-4db0-900c-fc24198f8718"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qeshm" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4999) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fe6295c8-50d1-4ce7-99c0-d681edecbbab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mashhad" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4279) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fe9a4b32-844e-49ec-ad99-21e49f771552"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "hamedan" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(5232) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ff002bb6-d9e4-431a-83d5-bff8b3679de4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "orumiyeh" }, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(4419) });

            migrationBuilder.InsertData(
                table: "TransferFee",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("e9494674-244f-4682-b2ee-3f1e4d8b3b10"), new DateTime(2024, 8, 15, 19, 26, 18, 708, DateTimeKind.Local).AddTicks(4484), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("af027e84-1062-4257-91f8-33ccab010cae"), null, new DateTime(2024, 8, 15, 19, 26, 18, 707, DateTimeKind.Local).AddTicks(878), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });
        }
    }
}
