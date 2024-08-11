using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SeedCityMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransferFees",
                keyColumn: "Id",
                keyValue: new Guid("bf81c581-bd8d-482c-9838-e1bb76f8ab0a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa24f2c7-6275-448f-bf59-0a657846aa73"));

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("0855c105-cdd5-4619-8217-ff1a497aa179"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(607), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اصفهان" },
                    { new Guid("097b65db-4bba-48e3-9131-bb80066fa02c"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(887), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شاهرود" },
                    { new Guid("0c8f675e-1235-440d-9555-5c42cd7a6cd2"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(818), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زابل" },
                    { new Guid("12fa5562-2711-4ba7-bd6c-a36e3f11814f"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(872), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مراغه" },
                    { new Guid("12ffbd47-ee3a-4036-a746-c45a4ccd4a20"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(741), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جهرم" },
                    { new Guid("15170d9c-e850-46b5-bfb7-a04664e76b3d"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(567), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اهواز" },
                    { new Guid("151bb9db-ca79-488c-977d-71d7886dd70d"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1030), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کولاله" },
                    { new Guid("19073e0d-14cf-4833-b4f2-1aa8cd43a529"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(641), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اراک" },
                    { new Guid("1a1827e7-9530-4cc9-bd71-a2c153911958"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1099), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "یاسوج" },
                    { new Guid("295bef88-2787-4f08-a095-152033a13437"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(842), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ساری" },
                    { new Guid("2a5d5d53-f90d-4e19-9eef-5731261f4d82"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(719), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بیرجند" },
                    { new Guid("2e3c1c2c-716e-4bbd-94d5-5899231b5e7c"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1069), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماکو" },
                    { new Guid("2e784626-7df6-44d0-804a-1d3ac8673f7b"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(579), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شیراز" },
                    { new Guid("3bd82e88-e4c0-4d0c-acc7-69fdc7f3d0d4"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1046), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "گرگان" },
                    { new Guid("450218a2-bc26-4e2a-ad21-16bcf1ab996f"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(595), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بندر عباس" },
                    { new Guid("47340e32-d499-400f-a7de-8177af670ba4"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(857), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سمنان" },
                    { new Guid("494e1988-f6df-4d9c-839f-f99ebec6d6e4"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1061), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لامراد" },
                    { new Guid("4be4fb83-3b11-4086-a187-19eee3f64ab7"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(703), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بندر لنگه" },
                    { new Guid("4ea5fd9b-f610-44cb-ba5e-c5d2453c6bc9"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(834), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زنجان" },
                    { new Guid("508a77f4-d926-4d65-bf1b-4a096773255b"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(787), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "دزفول" },
                    { new Guid("5cb1472b-9a86-4d2a-aff0-b30b71af23a9"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1054), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لار" },
                    { new Guid("5d5fba78-4b9c-4112-b76d-01ef49a77ad6"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(679), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ایلام" },
                    { new Guid("61aca7cf-2ab5-410d-aa3b-712e4ee44352"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(992), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "قم" },
                    { new Guid("64e405a9-8fcb-46ae-841d-b0f9f93b6662"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(895), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شهرکرد" },
                    { new Guid("666e7b29-8999-48e7-8431-a396d66eed90"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(687), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بجنورد" },
                    { new Guid("67591f60-6ad5-405a-b4ab-ad05e1772347"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1076), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماهشار" },
                    { new Guid("6816512f-5dbf-4745-b672-254f8e7dd89a"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(771), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خرم آباد" },
                    { new Guid("6d31d1ea-bad1-43c5-89be-c36d57fe5e0e"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(694), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بم" },
                    { new Guid("70922a9c-6ebd-43a1-9424-47141ab44996"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(663), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "امیدیه" },
                    { new Guid("71fb41bd-44b4-46a7-a204-2c296d4e3261"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(764), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خارک" },
                    { new Guid("73b5adec-1244-404d-aaa9-76245a54bed7"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(779), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خوی" },
                    { new Guid("7b03a727-f521-4d7d-81c0-f6696b9764f1"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(711), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بوشهر" },
                    { new Guid("7c09666c-88b6-40f3-a13c-c5397dbe0496"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(756), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "چابهار" },
                    { new Guid("82beca37-8015-4c34-8ff0-25c205f0f077"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(671), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ایران شهر" },
                    { new Guid("8a9b71d5-31a4-4c64-81c3-5f2cf6adc68d"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(656), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ارومیه" },
                    { new Guid("982635e0-4f2b-4824-a35e-b197ff2c4342"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(802), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رشت" },
                    { new Guid("98cf31e9-b59d-4f83-9651-cb4d21d283e9"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1091), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "همدان" },
                    { new Guid("9c84908f-251b-4912-a0fc-0336165d2071"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(827), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زاهدان" },
                    { new Guid("a0e78fc5-cdff-44e9-83c9-949288e9627e"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(794), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رامسر" },
                    { new Guid("a8543d00-0172-484c-a76d-59d9dc5a4687"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1023), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرمانشاه" },
                    { new Guid("a9c30179-e8a9-4b20-b391-1e591dd25466"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1106), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "یزد" },
                    { new Guid("aed264f1-b292-41bb-b876-4a8bc2d6c964"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1015), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرمان" },
                    { new Guid("b4edfc09-2945-4b97-a17d-e6773f658d2a"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1000), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کاشان" },
                    { new Guid("b50c4bef-e7f6-448b-b2db-e22c84535b92"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(864), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سنندج" },
                    { new Guid("bb34eb52-d14e-4fc1-a8fa-76644a0684cd"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(910), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "عسلویه" },
                    { new Guid("bb84534f-45a6-4e23-b640-bba637db0f1b"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(587), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مشهد" },
                    { new Guid("c2b367df-b432-4c51-a8da-ac9c87a23239"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(649), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اردبیل" },
                    { new Guid("c5734116-545b-4daf-b5a7-6da949853af5"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(749), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جیرفت" },
                    { new Guid("cb081377-f652-4adc-b153-60ac10380a6b"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(436), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تهران" },
                    { new Guid("cc7d3fd0-28db-4068-b532-b90d645cd37a"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1008), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرج" },
                    { new Guid("d0bad1df-fc60-4aad-b566-ac46c1ba8d66"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(880), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سیرجان" },
                    { new Guid("d2d786d6-0200-4f3a-815e-042a7fb00353"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(810), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رفسنجان" },
                    { new Guid("d5a91502-9371-4852-8f2a-0f906c09f8a8"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(624), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کیش" },
                    { new Guid("d8bc5526-5a3d-4b56-8463-435ffacbf51b"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1038), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "گچساران" },
                    { new Guid("dc8137ac-457c-4502-aebb-46b3a842e389"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(902), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "طبس" },
                    { new Guid("e3703711-7aad-483a-9eb1-ec4b7347301c"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(849), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سبزوار" },
                    { new Guid("f180c9be-ac7f-4787-b5c2-3c5cab4cb711"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(632), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "آبادان" },
                    { new Guid("f6fa4bbd-79cc-402c-8f26-1c5674e879a1"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(616), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تبریز" },
                    { new Guid("f75791de-4aa7-4b67-8e6c-c63c97080dad"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(726), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "پارس آباد" },
                    { new Guid("fa9ec8fb-96e3-46d4-a98f-d585cf9e4d96"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(734), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جاسک" },
                    { new Guid("fdb090f2-6316-4ebc-8178-dbecb276516c"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(917), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "قشم" },
                    { new Guid("feec8d4e-d64c-428c-8392-4daae7ab10ef"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(1084), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "نوشهر" }
                });

            migrationBuilder.InsertData(
                table: "TransferFees",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("c5a31585-724d-45c7-89fe-2a76952af65d"), new DateTime(2024, 8, 10, 16, 39, 6, 454, DateTimeKind.Local).AddTicks(2599), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("cb17551f-1b01-4b76-b938-739bc9c973d6"), null, new DateTime(2024, 8, 10, 16, 39, 6, 453, DateTimeKind.Local).AddTicks(7612), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0855c105-cdd5-4619-8217-ff1a497aa179"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("097b65db-4bba-48e3-9131-bb80066fa02c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0c8f675e-1235-440d-9555-5c42cd7a6cd2"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("12fa5562-2711-4ba7-bd6c-a36e3f11814f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("12ffbd47-ee3a-4036-a746-c45a4ccd4a20"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("15170d9c-e850-46b5-bfb7-a04664e76b3d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("151bb9db-ca79-488c-977d-71d7886dd70d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("19073e0d-14cf-4833-b4f2-1aa8cd43a529"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1a1827e7-9530-4cc9-bd71-a2c153911958"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("295bef88-2787-4f08-a095-152033a13437"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2a5d5d53-f90d-4e19-9eef-5731261f4d82"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2e3c1c2c-716e-4bbd-94d5-5899231b5e7c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2e784626-7df6-44d0-804a-1d3ac8673f7b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3bd82e88-e4c0-4d0c-acc7-69fdc7f3d0d4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("450218a2-bc26-4e2a-ad21-16bcf1ab996f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("47340e32-d499-400f-a7de-8177af670ba4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("494e1988-f6df-4d9c-839f-f99ebec6d6e4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4be4fb83-3b11-4086-a187-19eee3f64ab7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4ea5fd9b-f610-44cb-ba5e-c5d2453c6bc9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("508a77f4-d926-4d65-bf1b-4a096773255b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5cb1472b-9a86-4d2a-aff0-b30b71af23a9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5d5fba78-4b9c-4112-b76d-01ef49a77ad6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("61aca7cf-2ab5-410d-aa3b-712e4ee44352"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("64e405a9-8fcb-46ae-841d-b0f9f93b6662"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("666e7b29-8999-48e7-8431-a396d66eed90"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("67591f60-6ad5-405a-b4ab-ad05e1772347"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6816512f-5dbf-4745-b672-254f8e7dd89a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6d31d1ea-bad1-43c5-89be-c36d57fe5e0e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("70922a9c-6ebd-43a1-9424-47141ab44996"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("71fb41bd-44b4-46a7-a204-2c296d4e3261"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("73b5adec-1244-404d-aaa9-76245a54bed7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7b03a727-f521-4d7d-81c0-f6696b9764f1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7c09666c-88b6-40f3-a13c-c5397dbe0496"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("82beca37-8015-4c34-8ff0-25c205f0f077"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8a9b71d5-31a4-4c64-81c3-5f2cf6adc68d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("982635e0-4f2b-4824-a35e-b197ff2c4342"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("98cf31e9-b59d-4f83-9651-cb4d21d283e9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c84908f-251b-4912-a0fc-0336165d2071"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a0e78fc5-cdff-44e9-83c9-949288e9627e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a8543d00-0172-484c-a76d-59d9dc5a4687"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a9c30179-e8a9-4b20-b391-1e591dd25466"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("aed264f1-b292-41bb-b876-4a8bc2d6c964"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b4edfc09-2945-4b97-a17d-e6773f658d2a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b50c4bef-e7f6-448b-b2db-e22c84535b92"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bb34eb52-d14e-4fc1-a8fa-76644a0684cd"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bb84534f-45a6-4e23-b640-bba637db0f1b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c2b367df-b432-4c51-a8da-ac9c87a23239"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c5734116-545b-4daf-b5a7-6da949853af5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cb081377-f652-4adc-b153-60ac10380a6b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cc7d3fd0-28db-4068-b532-b90d645cd37a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d0bad1df-fc60-4aad-b566-ac46c1ba8d66"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d2d786d6-0200-4f3a-815e-042a7fb00353"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d5a91502-9371-4852-8f2a-0f906c09f8a8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d8bc5526-5a3d-4b56-8463-435ffacbf51b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dc8137ac-457c-4502-aebb-46b3a842e389"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e3703711-7aad-483a-9eb1-ec4b7347301c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f180c9be-ac7f-4787-b5c2-3c5cab4cb711"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f6fa4bbd-79cc-402c-8f26-1c5674e879a1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f75791de-4aa7-4b67-8e6c-c63c97080dad"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fa9ec8fb-96e3-46d4-a98f-d585cf9e4d96"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fdb090f2-6316-4ebc-8178-dbecb276516c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("feec8d4e-d64c-428c-8392-4daae7ab10ef"));

            migrationBuilder.DeleteData(
                table: "TransferFees",
                keyColumn: "Id",
                keyValue: new Guid("c5a31585-724d-45c7-89fe-2a76952af65d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cb17551f-1b01-4b76-b938-739bc9c973d6"));

            migrationBuilder.InsertData(
                table: "TransferFees",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("bf81c581-bd8d-482c-9838-e1bb76f8ab0a"), new DateTime(2024, 8, 10, 16, 1, 25, 575, DateTimeKind.Local).AddTicks(6272), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("aa24f2c7-6275-448f-bf59-0a657846aa73"), null, new DateTime(2024, 8, 10, 16, 1, 25, 575, DateTimeKind.Local).AddTicks(4558), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });
        }
    }
}
