using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CitySeedDataMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e4fd0d07-75b3-4d36-8117-614e88cf93fe"));

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Alternatives", "CreatedOn", "DeletedOn", "FaName", "IsDeleted", "Key", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("021a54be-4266-4780-ad0c-7680688d9f36"), new List<string> { "bojnourd" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5701), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بجنورد", false, "bojnourd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("044947b9-e2fa-48b1-b0f2-361da01e10d3"), new List<string> { "isfahan", "esfahan" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5049), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اصفهان", false, "isfahan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0a6e7713-475a-4192-bc75-18bdf3849077"), new List<string> { "kashan" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7686), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کاشان", false, "kashan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f10d758-0cba-46df-92a9-8fdb3858cca7"), new List<string> { "sabzevar" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7030), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سبزوار", false, "sabzevar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("12cba520-6cb8-48aa-a464-8dbfc45b4acc"), new List<string> { "kish" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5182), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کیش", false, "kish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("15e161a8-554e-4d84-a011-f17e1e4bbc3f"), new List<string> { "zahedan" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6837), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زاهدان", false, "zahedan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("160c7d8e-d839-4b4c-a8c9-39cbe5a38d37"), new List<string> { "noshahr" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8452), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "نوشهر", false, "noshahr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("172c2c8f-1800-4e0f-acd4-ef5a1e2f9213"), new List<string> { "jahrom" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6081), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جهرم", false, "jahrom", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19349721-8952-4623-9863-f17b856e4201"), new List<string> { "khorramabad" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6391), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خرم آباد", false, "khorramabad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19705072-6766-478e-b1f1-099603369129"), new List<string> { "ilam" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5637), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ایلام", false, "ilam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b6c2033-9ec8-4167-8273-058f83dc403a"), new List<string> { "arak" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5314), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اراک", false, "arak", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1cb92aa7-68a3-4e7c-a308-49d0dfed5841"), new List<string> { "omidieh" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7501), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "امیدیه", false, "omidieh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("223eba20-a0ed-4f63-ac3e-b4cc50c4923f"), new List<string> { "maragheh" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7196), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مراغه", false, "maragheh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2459068b-6b0c-47a1-a299-18900fbd4ed4"), new List<string> { "shiraz" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(4862), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شیراز", false, "shiraz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2ac079e7-d52d-46c3-8ef2-2f951e9a360d"), new List<string> { "shahroud" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7293), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شاهرود", false, "shahroud", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b0f4a8c-ae50-483e-ab43-c377d5542c57"), new List<string> { "omIdieh" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5505), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "امیدیه", false, "omIdieh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d22b9f7-ec8f-446c-9eed-af22d21ff194"), new List<string> { "gorgan" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8132), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "گرگان", false, "gorgan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2ffbaf0b-9621-4f8d-9156-6a18238f9b53"), new List<string> { "bandar lengeh" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5816), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بندر لنگه", false, "bandar-lengeh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36aedc91-6b85-4201-baee-394102453b86"), new List<string> { "khoy" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6446), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خوی", false, "khoy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("38d0d97a-dc59-4067-b255-81b0d237ed7c"), new List<string> { "asalouyeh" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7450), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "عسلویه", false, "asalouyeh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("392876fd-f90d-4825-a32b-46feafa7ef4d"), new List<string> { "zabol" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6770), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زابل", false, "zabol", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f092d22-a361-4380-8201-1deac30c7eb8"), new List<string> { "rafsanjan" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6705), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رفسنجان", false, "rafsanjan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f7f9b70-088e-4c51-ab5c-910f38623793"), new List<string> { "iranshahr" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5569), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ایران شهر", false, "iranshahr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4166380e-133a-4428-ba44-6298406dca2c"), new List<string> { "lamard" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8259), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لامراد", false, "lamard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44e5f7fb-a9e6-4f1e-bb25-03924a06c124"), new List<string> { "lar" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8196), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لار", false, "lar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a46d1f1-8bb0-4cb8-85c7-1929cb06e3b7"), new List<string> { "zanjan" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6903), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زنجان", false, "zanjan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4df58cb6-68cf-459a-a09c-9b233a1db4ab"), new List<string> { "kolaleh" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8006), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کولاله", false, "kolaleh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("511680d1-3191-4d44-aad6-5f46f4eee182"), new List<string> { "ahwaz", "ahvaz" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(4784), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اهواز", false, "ahwaz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5319fd9d-5d6f-4c8f-9cef-5385dfcbc545"), new List<string> { "bushehr", "booshehr" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5869), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بوشهر", false, "bushehr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("56245a47-a6dd-408e-8f55-7886db01be2c"), new List<string> { "abadan" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5248), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "آبادان", false, "abadan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57f276e4-b2ce-4fc8-a346-180b1c412de1"), new List<string> { "chabahar" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6267), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "چابهار", false, "chabahar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("634826cc-9f97-48f9-a8c7-55155dcf0073"), new List<string> { "yasouj" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8553), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "یاسوج", false, "yasouj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6979e8ce-5f2a-468e-b579-4ce2c27100c9"), new List<string> { "tehran" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(4520), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تهران", false, "tehran", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("718e45e8-a398-4725-bfe6-ad184b0e9541"), new List<string> { "sanandaj" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7145), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سنندج", false, "sanandaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("73c81768-44a1-4a94-be4e-f79eaf577167"), new List<string> { "rasht" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6640), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رشت", false, "rasht", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("75c76800-2a81-4b4e-a6d6-ad18827ece45"), new List<string> { "dezful" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6513), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "دزفول", false, "dezful", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76482101-3aaa-4ba9-a95e-a1d300e7c92e"), new List<string> { "ramsar" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6577), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رامسر", false, "ramsar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("882113bb-a3d9-44a9-a0a3-7774c98c3b0e"), new List<string> { "birjand" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بیرجند", false, "birjand", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a48d0ae-4297-46a6-926e-19e936a08428"), new List<string> { "jiroft" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6133), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جیرفت", false, "jiroft", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c49b9f4-90c8-4fab-be77-6403bfeeb487"), new List<string> { "shahrekord" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7344), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شهرکرد", false, "shahrekord", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("921c90cc-0170-4b2c-9ceb-702c78e3b775"), new List<string> { "karaj" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7735), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرج", false, "karaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("974203f2-f7d6-410f-91bc-89a7a706f964"), new List<string> { "yazd" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8603), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "یزد", false, "yazd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("99e93656-edd9-4d2d-bd43-8b81437dba0f"), new List<string> { "syrjan" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7243), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سیرجان", false, "syrjan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c592f92-6aab-4d8c-8526-4d99631b5d95"), new List<string> { "kerman" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7791), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرمان", false, "kerman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1786c97-9eaf-4c78-96ca-f31b935bc667"), new List<string> { "bam" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5763), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بم", false, "bam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3231945-d2ca-4ff0-85c9-21ae34da5f42"), new List<string> { "khark" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6341), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خارک", false, "khark", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad6c225d-3315-44c1-a0ae-39bb7e60722c"), new List<string> { "ardabil" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5378), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اردبیل", false, "ardabil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad8c177c-61c3-4243-aadc-092c897dc72f"), new List<string> { "semnan" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7091), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سمنان", false, "semnan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b595d16b-7be5-48b4-b8b2-cc4d10c6946c"), new List<string> { "gachsaran" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8070), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "گچساران", false, "gachsaran", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b713db78-eac0-48e5-a576-7a14057a5542"), new List<string> { "makou" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8325), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماکو", false, "makou", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c40478c3-8165-41f6-bc5c-73e82a9c7305"), new List<string> { "pars-abad" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5973), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "پارس آباد", false, "pars-abad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1de7180-20c8-4cf9-a90c-04720d91c50a"), new List<string> { "tabriz" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5115), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تبریز", false, "tabriz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5e3997e-6cf9-4080-90ab-86a5d6b45953"), new List<string> { "jask" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6026), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جاسک", false, "jask", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5e46c30-604f-41f7-8188-84fca3b06b24"), new List<string> { "mahshahr" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8390), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماهشار", false, "mahshahr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d6489a65-5488-4967-9ee5-77067554f936"), new List<string> { "sari" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(6966), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ساری", false, "sari", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dabec0ed-ba17-4807-9041-d6706aa0aa49"), new List<string> { "tabas" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7397), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "طبس", false, "tabas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dda8a974-f10d-4b38-9c5a-bf085d85f5e4"), new List<string> { "qom", "ghom" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7619), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "قم", false, "qom", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1d368d9-45ab-4daf-a4bf-b4f09b575f4f"), new List<string> { "bandar abbas" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(4990), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بندر عباس", false, "bandar-abbas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3eec5c4-1fbb-4ff0-b54c-bfc6c5fbf7fa"), new List<string> { "kermanshah" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7937), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرمانشاه", false, "kermanshah", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f91c4eb3-621a-4db0-900c-fc24198f8718"), new List<string> { "qeshm" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(7560), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "قشم", false, "qeshm", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe6295c8-50d1-4ce7-99c0-d681edecbbab"), new List<string> { "mashhad" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(4924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مشهد", false, "mashhad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe9a4b32-844e-49ec-ad99-21e49f771552"), new List<string> { "hamedan" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(8503), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "همدان", false, "hamedan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff002bb6-d9e4-431a-83d5-bff8b3679de4"), new List<string> { "orumiyeh" }, new DateTime(2024, 8, 21, 10, 35, 47, 331, DateTimeKind.Local).AddTicks(5440), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ارومیه", false, "orumiyeh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "TransferFees",
                keyColumn: "Id",
                keyValue: new Guid("e2635bc0-c7f5-47cf-88c6-dc9cf3c125a0"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 21, 10, 35, 47, 332, DateTimeKind.Local).AddTicks(2923));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("67e1f31d-5d56-4a55-a4ac-99cef7be7f4e"), null, new DateTime(2024, 8, 21, 10, 35, 47, 330, DateTimeKind.Local).AddTicks(6669), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("021a54be-4266-4780-ad0c-7680688d9f36"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("044947b9-e2fa-48b1-b0f2-361da01e10d3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0a6e7713-475a-4192-bc75-18bdf3849077"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0f10d758-0cba-46df-92a9-8fdb3858cca7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("12cba520-6cb8-48aa-a464-8dbfc45b4acc"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("15e161a8-554e-4d84-a011-f17e1e4bbc3f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("160c7d8e-d839-4b4c-a8c9-39cbe5a38d37"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("172c2c8f-1800-4e0f-acd4-ef5a1e2f9213"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("19349721-8952-4623-9863-f17b856e4201"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("19705072-6766-478e-b1f1-099603369129"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1b6c2033-9ec8-4167-8273-058f83dc403a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1cb92aa7-68a3-4e7c-a308-49d0dfed5841"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("223eba20-a0ed-4f63-ac3e-b4cc50c4923f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2459068b-6b0c-47a1-a299-18900fbd4ed4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2ac079e7-d52d-46c3-8ef2-2f951e9a360d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2b0f4a8c-ae50-483e-ab43-c377d5542c57"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2d22b9f7-ec8f-446c-9eed-af22d21ff194"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2ffbaf0b-9621-4f8d-9156-6a18238f9b53"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("36aedc91-6b85-4201-baee-394102453b86"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("38d0d97a-dc59-4067-b255-81b0d237ed7c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("392876fd-f90d-4825-a32b-46feafa7ef4d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3f092d22-a361-4380-8201-1deac30c7eb8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3f7f9b70-088e-4c51-ab5c-910f38623793"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4166380e-133a-4428-ba44-6298406dca2c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("44e5f7fb-a9e6-4f1e-bb25-03924a06c124"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4a46d1f1-8bb0-4cb8-85c7-1929cb06e3b7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4df58cb6-68cf-459a-a09c-9b233a1db4ab"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("511680d1-3191-4d44-aad6-5f46f4eee182"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5319fd9d-5d6f-4c8f-9cef-5385dfcbc545"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("56245a47-a6dd-408e-8f55-7886db01be2c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("57f276e4-b2ce-4fc8-a346-180b1c412de1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("634826cc-9f97-48f9-a8c7-55155dcf0073"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6979e8ce-5f2a-468e-b579-4ce2c27100c9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("718e45e8-a398-4725-bfe6-ad184b0e9541"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("73c81768-44a1-4a94-be4e-f79eaf577167"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("75c76800-2a81-4b4e-a6d6-ad18827ece45"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("76482101-3aaa-4ba9-a95e-a1d300e7c92e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("882113bb-a3d9-44a9-a0a3-7774c98c3b0e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8a48d0ae-4297-46a6-926e-19e936a08428"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8c49b9f4-90c8-4fab-be77-6403bfeeb487"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("921c90cc-0170-4b2c-9ceb-702c78e3b775"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("974203f2-f7d6-410f-91bc-89a7a706f964"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("99e93656-edd9-4d2d-bd43-8b81437dba0f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c592f92-6aab-4d8c-8526-4d99631b5d95"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a1786c97-9eaf-4c78-96ca-f31b935bc667"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a3231945-d2ca-4ff0-85c9-21ae34da5f42"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ad6c225d-3315-44c1-a0ae-39bb7e60722c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ad8c177c-61c3-4243-aadc-092c897dc72f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b595d16b-7be5-48b4-b8b2-cc4d10c6946c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b713db78-eac0-48e5-a576-7a14057a5542"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c40478c3-8165-41f6-bc5c-73e82a9c7305"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d1de7180-20c8-4cf9-a90c-04720d91c50a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d5e3997e-6cf9-4080-90ab-86a5d6b45953"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d5e46c30-604f-41f7-8188-84fca3b06b24"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d6489a65-5488-4967-9ee5-77067554f936"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dabec0ed-ba17-4807-9041-d6706aa0aa49"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dda8a974-f10d-4b38-9c5a-bf085d85f5e4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e1d368d9-45ab-4daf-a4bf-b4f09b575f4f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e3eec5c4-1fbb-4ff0-b54c-bfc6c5fbf7fa"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f91c4eb3-621a-4db0-900c-fc24198f8718"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fe6295c8-50d1-4ce7-99c0-d681edecbbab"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fe9a4b32-844e-49ec-ad99-21e49f771552"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ff002bb6-d9e4-431a-83d5-bff8b3679de4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67e1f31d-5d56-4a55-a4ac-99cef7be7f4e"));

            migrationBuilder.UpdateData(
                table: "TransferFees",
                keyColumn: "Id",
                keyValue: new Guid("e2635bc0-c7f5-47cf-88c6-dc9cf3c125a0"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 20, 21, 38, 2, 913, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("e4fd0d07-75b3-4d36-8117-614e88cf93fe"), null, new DateTime(2024, 8, 20, 21, 38, 2, 913, DateTimeKind.Local).AddTicks(2228), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });
        }
    }
}
