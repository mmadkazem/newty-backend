#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CityMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_City_CityId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_City_CityId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DeleteData(
                table: "TransferFee",
                keyColumn: "Id",
                keyValue: new Guid("be415760-dfc5-435b-ae4c-d1ddc08acce4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1afb4190-f6a9-4453-9d37-f6275247dd83"));

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("021a54be-4266-4780-ad0c-7680688d9f36"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bojnourd" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1456) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("044947b9-e2fa-48b1-b0f2-361da01e10d3"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "isfahan", "esfahan" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0a6e7713-475a-4192-bc75-18bdf3849077"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kashan" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2015) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0f10d758-0cba-46df-92a9-8fdb3858cca7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sabzevar" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("12cba520-6cb8-48aa-a464-8dbfc45b4acc"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kish" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1246) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("15e161a8-554e-4d84-a011-f17e1e4bbc3f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zahedan" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("160c7d8e-d839-4b4c-a8c9-39cbe5a38d37"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "noshahr" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("172c2c8f-1800-4e0f-acd4-ef5a1e2f9213"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jahrom" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1573) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("19349721-8952-4623-9863-f17b856e4201"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khorramabad" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1649) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("19705072-6766-478e-b1f1-099603369129"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ilam" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1435) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1b6c2033-9ec8-4167-8273-058f83dc403a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "arak" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1cb92aa7-68a3-4e7c-a308-49d0dfed5841"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omidieh" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1963) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("223eba20-a0ed-4f63-ac3e-b4cc50c4923f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "maragheh" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1866) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2459068b-6b0c-47a1-a299-18900fbd4ed4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shiraz" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1152) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2ac079e7-d52d-46c3-8ef2-2f951e9a360d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahroud" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1898) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2b0f4a8c-ae50-483e-ab43-c377d5542c57"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omIdieh" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2d22b9f7-ec8f-446c-9eed-af22d21ff194"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gorgan" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2122) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2ffbaf0b-9621-4f8d-9156-6a18238f9b53"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar lengeh" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1491) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("36aedc91-6b85-4201-baee-394102453b86"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khoy" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1666) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("38d0d97a-dc59-4067-b255-81b0d237ed7c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "asalouyeh" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1946) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("392876fd-f90d-4825-a32b-46feafa7ef4d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zabol" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3f092d22-a361-4380-8201-1deac30c7eb8"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rafsanjan" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1732) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3f7f9b70-088e-4c51-ab5c-910f38623793"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "iranshahr" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1346) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4166380e-133a-4428-ba44-6298406dca2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lamard" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2155) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("44e5f7fb-a9e6-4f1e-bb25-03924a06c124"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lar" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4a46d1f1-8bb0-4cb8-85c7-1929cb06e3b7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zanjan" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4df58cb6-68cf-459a-a09c-9b233a1db4ab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kolaleh" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2089) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("511680d1-3191-4d44-aad6-5f46f4eee182"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ahwaz", "ahvaz" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1128) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5319fd9d-5d6f-4c8f-9cef-5385dfcbc545"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bushehr", "booshehr" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1508) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("56245a47-a6dd-408e-8f55-7886db01be2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "abadan" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1263) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("57f276e4-b2ce-4fc8-a346-180b1c412de1"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "chabahar" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1606) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("634826cc-9f97-48f9-a8c7-55155dcf0073"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yasouj" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2237) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6979e8ce-5f2a-468e-b579-4ce2c27100c9"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tehran" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(966) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("718e45e8-a398-4725-bfe6-ad184b0e9541"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sanandaj" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1849) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("73c81768-44a1-4a94-be4e-f79eaf577167"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rasht" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1716) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("75c76800-2a81-4b4e-a6d6-ad18827ece45"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "dezful" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1683) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("76482101-3aaa-4ba9-a95e-a1d300e7c92e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ramsar" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("882113bb-a3d9-44a9-a0a3-7774c98c3b0e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "birjand" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1525) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8a48d0ae-4297-46a6-926e-19e936a08428"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jiroft" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1590) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8c49b9f4-90c8-4fab-be77-6403bfeeb487"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahrekord" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1914) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("921c90cc-0170-4b2c-9ceb-702c78e3b775"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "karaj" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2031) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("974203f2-f7d6-410f-91bc-89a7a706f964"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yazd" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2253) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("99e93656-edd9-4d2d-bd43-8b81437dba0f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "syrjan" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1882) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c592f92-6aab-4d8c-8526-4d99631b5d95"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kerman" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2047) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a1786c97-9eaf-4c78-96ca-f31b935bc667"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bam" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1472) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a3231945-d2ca-4ff0-85c9-21ae34da5f42"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khark" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1633) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ad6c225d-3315-44c1-a0ae-39bb7e60722c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ardabil" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1297) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ad8c177c-61c3-4243-aadc-092c897dc72f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "semnan" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1833) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b595d16b-7be5-48b4-b8b2-cc4d10c6946c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gachsaran" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b713db78-eac0-48e5-a576-7a14057a5542"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "makou" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2171) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c40478c3-8165-41f6-bc5c-73e82a9c7305"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "pars-abad" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1541) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d1de7180-20c8-4cf9-a90c-04720d91c50a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabriz" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1229) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d5e3997e-6cf9-4080-90ab-86a5d6b45953"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jask" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1557) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d5e46c30-604f-41f7-8188-84fca3b06b24"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mahshahr" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2187) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d6489a65-5488-4967-9ee5-77067554f936"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sari" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dabec0ed-ba17-4807-9041-d6706aa0aa49"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabas" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1930) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dda8a974-f10d-4b38-9c5a-bf085d85f5e4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qom", "ghom" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1997) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e1d368d9-45ab-4daf-a4bf-b4f09b575f4f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar abbas" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1188) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e3eec5c4-1fbb-4ff0-b54c-bfc6c5fbf7fa"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kermanshah" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2072) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f91c4eb3-621a-4db0-900c-fc24198f8718"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qeshm" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1981) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fe6295c8-50d1-4ce7-99c0-d681edecbbab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mashhad" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1171) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fe9a4b32-844e-49ec-ad99-21e49f771552"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "hamedan" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(2220) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ff002bb6-d9e4-431a-83d5-bff8b3679de4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "orumiyeh" }, new DateTime(2024, 8, 15, 19, 25, 12, 119, DateTimeKind.Local).AddTicks(1313) });

            migrationBuilder.InsertData(
                table: "TransferFee",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("f26fa400-9458-4f8d-bf56-8dfe734f4420"), new DateTime(2024, 8, 15, 19, 25, 12, 120, DateTimeKind.Local).AddTicks(2482), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("6624bf00-1448-486c-88ce-631c81dab47d"), null, new DateTime(2024, 8, 15, 19, 25, 12, 118, DateTimeKind.Local).AddTicks(7995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Cities_CityId",
                table: "Businesses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Cities_CityId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DeleteData(
                table: "TransferFee",
                keyColumn: "Id",
                keyValue: new Guid("f26fa400-9458-4f8d-bf56-8dfe734f4420"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6624bf00-1448-486c-88ce-631c81dab47d"));

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("021a54be-4266-4780-ad0c-7680688d9f36"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bojnourd" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8103) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("044947b9-e2fa-48b1-b0f2-361da01e10d3"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "isfahan", "esfahan" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(7939) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("0a6e7713-475a-4192-bc75-18bdf3849077"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kashan" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8638) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("0f10d758-0cba-46df-92a9-8fdb3858cca7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sabzevar" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8448) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("12cba520-6cb8-48aa-a464-8dbfc45b4acc"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kish" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(7974) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("15e161a8-554e-4d84-a011-f17e1e4bbc3f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zahedan" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("160c7d8e-d839-4b4c-a8c9-39cbe5a38d37"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "noshahr" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8883) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("172c2c8f-1800-4e0f-acd4-ef5a1e2f9213"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jahrom" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8217) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("19349721-8952-4623-9863-f17b856e4201"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khorramabad" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8287) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("19705072-6766-478e-b1f1-099603369129"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ilam" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8088) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("1b6c2033-9ec8-4167-8273-058f83dc403a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "arak" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8007) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("1cb92aa7-68a3-4e7c-a308-49d0dfed5841"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omidieh" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8586) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("223eba20-a0ed-4f63-ac3e-b4cc50c4923f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "maragheh" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8494) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2459068b-6b0c-47a1-a299-18900fbd4ed4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shiraz" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(7883) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2ac079e7-d52d-46c3-8ef2-2f951e9a360d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahroud" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2b0f4a8c-ae50-483e-ab43-c377d5542c57"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "omIdieh" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8055) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2d22b9f7-ec8f-446c-9eed-af22d21ff194"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gorgan" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8739) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("2ffbaf0b-9621-4f8d-9156-6a18238f9b53"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar lengeh" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("36aedc91-6b85-4201-baee-394102453b86"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khoy" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8303) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("38d0d97a-dc59-4067-b255-81b0d237ed7c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "asalouyeh" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8571) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("392876fd-f90d-4825-a32b-46feafa7ef4d"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zabol" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("3f092d22-a361-4380-8201-1deac30c7eb8"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rafsanjan" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("3f7f9b70-088e-4c51-ab5c-910f38623793"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "iranshahr" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8071) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("4166380e-133a-4428-ba44-6298406dca2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lamard" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("44e5f7fb-a9e6-4f1e-bb25-03924a06c124"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "lar" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8754) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("4a46d1f1-8bb0-4cb8-85c7-1929cb06e3b7"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "zanjan" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8416) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("4df58cb6-68cf-459a-a09c-9b233a1db4ab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kolaleh" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8707) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("511680d1-3191-4d44-aad6-5f46f4eee182"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ahwaz", "ahvaz" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("5319fd9d-5d6f-4c8f-9cef-5385dfcbc545"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bushehr", "booshehr" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("56245a47-a6dd-408e-8f55-7886db01be2c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "abadan" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(7990) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("57f276e4-b2ce-4fc8-a346-180b1c412de1"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "chabahar" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("634826cc-9f97-48f9-a8c7-55155dcf0073"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yasouj" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8913) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("6979e8ce-5f2a-468e-b579-4ce2c27100c9"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tehran" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("718e45e8-a398-4725-bfe6-ad184b0e9541"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sanandaj" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8479) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("73c81768-44a1-4a94-be4e-f79eaf577167"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "rasht" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8351) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("75c76800-2a81-4b4e-a6d6-ad18827ece45"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "dezful" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8319) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("76482101-3aaa-4ba9-a95e-a1d300e7c92e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ramsar" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("882113bb-a3d9-44a9-a0a3-7774c98c3b0e"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "birjand" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("8a48d0ae-4297-46a6-926e-19e936a08428"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jiroft" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8232) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("8c49b9f4-90c8-4fab-be77-6403bfeeb487"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "shahrekord" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8540) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("921c90cc-0170-4b2c-9ceb-702c78e3b775"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "karaj" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8653) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("974203f2-f7d6-410f-91bc-89a7a706f964"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "yazd" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8929) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("99e93656-edd9-4d2d-bd43-8b81437dba0f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "syrjan" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8509) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("9c592f92-6aab-4d8c-8526-4d99631b5d95"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kerman" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("a1786c97-9eaf-4c78-96ca-f31b935bc667"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bam" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8119) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("a3231945-d2ca-4ff0-85c9-21ae34da5f42"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "khark" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8271) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("ad6c225d-3315-44c1-a0ae-39bb7e60722c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "ardabil" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8024) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("ad8c177c-61c3-4243-aadc-092c897dc72f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "semnan" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8463) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("b595d16b-7be5-48b4-b8b2-cc4d10c6946c"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "gachsaran" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8722) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("b713db78-eac0-48e5-a576-7a14057a5542"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "makou" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("c40478c3-8165-41f6-bc5c-73e82a9c7305"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "pars-abad" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8186) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d1de7180-20c8-4cf9-a90c-04720d91c50a"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabriz" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(7957) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d5e3997e-6cf9-4080-90ab-86a5d6b45953"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "jask" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8201) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d5e46c30-604f-41f7-8188-84fca3b06b24"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mahshahr" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8866) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("d6489a65-5488-4967-9ee5-77067554f936"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "sari" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8432) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("dabec0ed-ba17-4807-9041-d6706aa0aa49"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "tabas" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8556) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("dda8a974-f10d-4b38-9c5a-bf085d85f5e4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qom", "ghom" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("e1d368d9-45ab-4daf-a4bf-b4f09b575f4f"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "bandar abbas" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("e3eec5c4-1fbb-4ff0-b54c-bfc6c5fbf7fa"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "kermanshah" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8690) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("f91c4eb3-621a-4db0-900c-fc24198f8718"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "qeshm" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8604) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("fe6295c8-50d1-4ce7-99c0-d681edecbbab"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "mashhad" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("fe9a4b32-844e-49ec-ad99-21e49f771552"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "hamedan" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8898) });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: new Guid("ff002bb6-d9e4-431a-83d5-bff8b3679de4"),
                columns: new[] { "Alternatives", "CreatedOn" },
                values: new object[] { new List<string> { "orumiyeh" }, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(8040) });

            migrationBuilder.InsertData(
                table: "TransferFee",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("be415760-dfc5-435b-ae4c-d1ddc08acce4"), new DateTime(2024, 8, 15, 19, 24, 54, 383, DateTimeKind.Local).AddTicks(8321), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("1afb4190-f6a9-4453-9d37-f6275247dd83"), null, new DateTime(2024, 8, 15, 19, 24, 54, 382, DateTimeKind.Local).AddTicks(4068), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_City_CityId",
                table: "Businesses",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_City_CityId",
                table: "Users",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }
    }
}
