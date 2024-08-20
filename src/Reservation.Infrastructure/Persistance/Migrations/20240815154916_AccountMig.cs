#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AccountMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    ParentCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FaName = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Alternatives = table.Column<List<string>>(type: "text[]", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SmsCount = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferFee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Percent = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferFee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Credit = table.Column<decimal>(type: "numeric", nullable: false),
                    BlockCredit = table.Column<decimal>(type: "numeric", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    ParvaneKasbImagePath = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsCancelReserveTime = table.Column<bool>(type: "boolean", nullable: false),
                    StartHoursOfWor = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndHoursOfWor = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Holidays = table.Column<int[]>(type: "integer[]", nullable: true),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: true),
                    SmsCreditId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Business_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: true),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artist_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCategory",
                columns: table => new
                {
                    BusinessesId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategory", x => new { x.BusinessesId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BusinessCategory_Business_BusinessesId",
                        column: x => x.BusinessesId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessCategory_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessRequestPay",
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
                    table.PrimaryKey("PK_BusinessRequestPay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessRequestPay_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReserveTimeSender",
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
                    table.PrimaryKey("PK_ReserveTimeSender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveTimeSender_Business_BusinessReceiptId",
                        column: x => x.BusinessReceiptId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimeSender_Business_BusinessSenderId",
                        column: x => x.BusinessSenderId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmsCredit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SmsCount = table.Column<int>(type: "integer", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsCredit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsCredit_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmsTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsTemplate_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUser",
                columns: table => new
                {
                    BusinessesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersNormalId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUser", x => new { x.BusinessesId, x.UsersNormalId });
                    table.ForeignKey(
                        name: "FK_BusinessUser_Business_BusinessesId",
                        column: x => x.BusinessesId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessUser_Users_UsersNormalId",
                        column: x => x.UsersNormalId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReserveTimeReceipt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    IsPay = table.Column<bool>(type: "boolean", nullable: false),
                    BusinessReceiptId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessSenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionSenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionReceiptId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveTimeReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveTimeReceipt_Business_BusinessReceiptId",
                        column: x => x.BusinessReceiptId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimeReceipt_Business_BusinessSenderId",
                        column: x => x.BusinessSenderId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimeReceipt_Transaction_TransactionReceiptId",
                        column: x => x.TransactionReceiptId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimeReceipt_Transaction_TransactionSenderId",
                        column: x => x.TransactionSenderId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimeReceipt_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRequestPay",
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
                    table.PrimaryKey("PK_UserRequestPay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRequestPay_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVIP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVIP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVIP_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserVIP_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessService_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessService_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rate = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: true),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Point_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Point_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Point_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Expire = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupon_BusinessService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "BusinessService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReserveItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReserveTimeReceiptId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReserveTimeSenderId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveItem_BusinessService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "BusinessService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveItem_ReserveTimeReceipt_ReserveTimeReceiptId",
                        column: x => x.ReserveTimeReceiptId,
                        principalTable: "ReserveTimeReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReserveItem_ReserveTimeSender_ReserveTimeSenderId",
                        column: x => x.ReserveTimeSenderId,
                        principalTable: "ReserveTimeSender",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Alternatives", "CreatedOn", "DeletedOn", "FaName", "IsDeleted", "Key", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("021a54be-4266-4780-ad0c-7680688d9f36"), new List<string> { "bojnourd" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4463), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بجنورد", false, "bojnourd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("044947b9-e2fa-48b1-b0f2-361da01e10d3"), new List<string> { "isfahan", "esfahan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4299), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اصفهان", false, "isfahan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0a6e7713-475a-4192-bc75-18bdf3849077"), new List<string> { "kashan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4991), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کاشان", false, "kashan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f10d758-0cba-46df-92a9-8fdb3858cca7"), new List<string> { "sabzevar" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4803), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سبزوار", false, "sabzevar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("12cba520-6cb8-48aa-a464-8dbfc45b4acc"), new List<string> { "kish" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4334), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کیش", false, "kish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("15e161a8-554e-4d84-a011-f17e1e4bbc3f"), new List<string> { "zahedan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4757), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زاهدان", false, "zahedan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("160c7d8e-d839-4b4c-a8c9-39cbe5a38d37"), new List<string> { "noshahr" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5168), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "نوشهر", false, "noshahr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("172c2c8f-1800-4e0f-acd4-ef5a1e2f9213"), new List<string> { "jahrom" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4576), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جهرم", false, "jahrom", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19349721-8952-4623-9863-f17b856e4201"), new List<string> { "khorramabad" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4646), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خرم آباد", false, "khorramabad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19705072-6766-478e-b1f1-099603369129"), new List<string> { "ilam" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ایلام", false, "ilam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b6c2033-9ec8-4167-8273-058f83dc403a"), new List<string> { "arak" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4367), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اراک", false, "arak", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1cb92aa7-68a3-4e7c-a308-49d0dfed5841"), new List<string> { "omidieh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4942), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "امیدیه", false, "omidieh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("223eba20-a0ed-4f63-ac3e-b4cc50c4923f"), new List<string> { "maragheh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4849), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مراغه", false, "maragheh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2459068b-6b0c-47a1-a299-18900fbd4ed4"), new List<string> { "shiraz" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4244), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شیراز", false, "shiraz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2ac079e7-d52d-46c3-8ef2-2f951e9a360d"), new List<string> { "shahroud" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4880), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شاهرود", false, "shahroud", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b0f4a8c-ae50-483e-ab43-c377d5542c57"), new List<string> { "omIdieh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4415), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "امیدیه", false, "omIdieh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d22b9f7-ec8f-446c-9eed-af22d21ff194"), new List<string> { "gorgan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5091), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "گرگان", false, "gorgan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2ffbaf0b-9621-4f8d-9156-6a18238f9b53"), new List<string> { "bandar lengeh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4496), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بندر لنگه", false, "bandar-lengeh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36aedc91-6b85-4201-baee-394102453b86"), new List<string> { "khoy" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4662), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خوی", false, "khoy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("38d0d97a-dc59-4067-b255-81b0d237ed7c"), new List<string> { "asalouyeh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4926), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "عسلویه", false, "asalouyeh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("392876fd-f90d-4825-a32b-46feafa7ef4d"), new List<string> { "zabol" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4740), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زابل", false, "zabol", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f092d22-a361-4380-8201-1deac30c7eb8"), new List<string> { "rafsanjan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4724), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رفسنجان", false, "rafsanjan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f7f9b70-088e-4c51-ab5c-910f38623793"), new List<string> { "iranshahr" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4430), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ایران شهر", false, "iranshahr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4166380e-133a-4428-ba44-6298406dca2c"), new List<string> { "lamard" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5122), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لامراد", false, "lamard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44e5f7fb-a9e6-4f1e-bb25-03924a06c124"), new List<string> { "lar" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5107), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لار", false, "lar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a46d1f1-8bb0-4cb8-85c7-1929cb06e3b7"), new List<string> { "zanjan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4772), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زنجان", false, "zanjan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4df58cb6-68cf-459a-a09c-9b233a1db4ab"), new List<string> { "kolaleh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5060), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کولاله", false, "kolaleh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("511680d1-3191-4d44-aad6-5f46f4eee182"), new List<string> { "ahwaz", "ahvaz" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4087), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اهواز", false, "ahwaz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5319fd9d-5d6f-4c8f-9cef-5385dfcbc545"), new List<string> { "bushehr", "booshehr" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4512), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بوشهر", false, "bushehr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("56245a47-a6dd-408e-8f55-7886db01be2c"), new List<string> { "abadan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4351), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "آبادان", false, "abadan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57f276e4-b2ce-4fc8-a346-180b1c412de1"), new List<string> { "chabahar" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4607), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "چابهار", false, "chabahar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("634826cc-9f97-48f9-a8c7-55155dcf0073"), new List<string> { "yasouj" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5199), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "یاسوج", false, "yasouj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6979e8ce-5f2a-468e-b579-4ce2c27100c9"), new List<string> { "tehran" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(3753), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تهران", false, "tehran", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("718e45e8-a398-4725-bfe6-ad184b0e9541"), new List<string> { "sanandaj" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4834), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سنندج", false, "sanandaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("73c81768-44a1-4a94-be4e-f79eaf577167"), new List<string> { "rasht" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4708), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رشت", false, "rasht", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("75c76800-2a81-4b4e-a6d6-ad18827ece45"), new List<string> { "dezful" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4677), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "دزفول", false, "dezful", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76482101-3aaa-4ba9-a95e-a1d300e7c92e"), new List<string> { "ramsar" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4693), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رامسر", false, "ramsar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("882113bb-a3d9-44a9-a0a3-7774c98c3b0e"), new List<string> { "birjand" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4529), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بیرجند", false, "birjand", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a48d0ae-4297-46a6-926e-19e936a08428"), new List<string> { "jiroft" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4591), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جیرفت", false, "jiroft", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c49b9f4-90c8-4fab-be77-6403bfeeb487"), new List<string> { "shahrekord" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4895), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شهرکرد", false, "shahrekord", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("921c90cc-0170-4b2c-9ceb-702c78e3b775"), new List<string> { "karaj" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5006), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرج", false, "karaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("974203f2-f7d6-410f-91bc-89a7a706f964"), new List<string> { "yazd" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5215), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "یزد", false, "yazd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("99e93656-edd9-4d2d-bd43-8b81437dba0f"), new List<string> { "syrjan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4865), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سیرجان", false, "syrjan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c592f92-6aab-4d8c-8526-4d99631b5d95"), new List<string> { "kerman" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5022), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرمان", false, "kerman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1786c97-9eaf-4c78-96ca-f31b935bc667"), new List<string> { "bam" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4479), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بم", false, "bam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3231945-d2ca-4ff0-85c9-21ae34da5f42"), new List<string> { "khark" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4631), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خارک", false, "khark", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad6c225d-3315-44c1-a0ae-39bb7e60722c"), new List<string> { "ardabil" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4383), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اردبیل", false, "ardabil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad8c177c-61c3-4243-aadc-092c897dc72f"), new List<string> { "semnan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4818), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سمنان", false, "semnan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b595d16b-7be5-48b4-b8b2-cc4d10c6946c"), new List<string> { "gachsaran" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5075), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "گچساران", false, "gachsaran", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b713db78-eac0-48e5-a576-7a14057a5542"), new List<string> { "makou" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5138), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماکو", false, "makou", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c40478c3-8165-41f6-bc5c-73e82a9c7305"), new List<string> { "pars-abad" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4545), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "پارس آباد", false, "pars-abad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1de7180-20c8-4cf9-a90c-04720d91c50a"), new List<string> { "tabriz" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4318), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تبریز", false, "tabriz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5e3997e-6cf9-4080-90ab-86a5d6b45953"), new List<string> { "jask" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4560), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جاسک", false, "jask", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5e46c30-604f-41f7-8188-84fca3b06b24"), new List<string> { "mahshahr" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5153), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماهشار", false, "mahshahr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d6489a65-5488-4967-9ee5-77067554f936"), new List<string> { "sari" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4787), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ساری", false, "sari", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dabec0ed-ba17-4807-9041-d6706aa0aa49"), new List<string> { "tabas" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4911), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "طبس", false, "tabas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dda8a974-f10d-4b38-9c5a-bf085d85f5e4"), new List<string> { "qom", "ghom" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4973), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "قم", false, "qom", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1d368d9-45ab-4daf-a4bf-b4f09b575f4f"), new List<string> { "bandar abbas" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4277), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بندر عباس", false, "bandar-abbas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3eec5c4-1fbb-4ff0-b54c-bfc6c5fbf7fa"), new List<string> { "kermanshah" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5044), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرمانشاه", false, "kermanshah", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f91c4eb3-621a-4db0-900c-fc24198f8718"), new List<string> { "qeshm" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4958), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "قشم", false, "qeshm", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe6295c8-50d1-4ce7-99c0-d681edecbbab"), new List<string> { "mashhad" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4261), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مشهد", false, "mashhad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe9a4b32-844e-49ec-ad99-21e49f771552"), new List<string> { "hamedan" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(5184), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "همدان", false, "hamedan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff002bb6-d9e4-431a-83d5-bff8b3679de4"), new List<string> { "orumiyeh" }, new DateTime(2024, 8, 15, 19, 19, 15, 147, DateTimeKind.Local).AddTicks(4399), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ارومیه", false, "orumiyeh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TransferFee",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("77226619-ee74-493c-aea0-28d9638988fc"), new DateTime(2024, 8, 15, 19, 19, 15, 148, DateTimeKind.Local).AddTicks(5503), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("e78a53e7-027f-4b43-8890-496a6883db8f"), null, new DateTime(2024, 8, 15, 19, 19, 15, 146, DateTimeKind.Local).AddTicks(9772), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_BusinessId",
                table: "Artist",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_CityId",
                table: "Business",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_WalletId",
                table: "Business",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCategory_CategoriesId",
                table: "BusinessCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRequestPay_BusinessId",
                table: "BusinessRequestPay",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessService_ArtistId",
                table: "BusinessService",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessService_BusinessId",
                table: "BusinessService",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUser_UsersNormalId",
                table: "BusinessUser",
                column: "UsersNormalId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_ServiceId",
                table: "Coupon",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Point_ArtistId",
                table: "Point",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Point_BusinessId",
                table: "Point",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Point_UserId",
                table: "Point",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_BusinessId",
                table: "Post",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItem_ReserveTimeReceiptId",
                table: "ReserveItem",
                column: "ReserveTimeReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItem_ReserveTimeSenderId",
                table: "ReserveItem",
                column: "ReserveTimeSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItem_ServiceId",
                table: "ReserveItem",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimeReceipt_BusinessReceiptId",
                table: "ReserveTimeReceipt",
                column: "BusinessReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimeReceipt_BusinessSenderId",
                table: "ReserveTimeReceipt",
                column: "BusinessSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimeReceipt_TransactionReceiptId",
                table: "ReserveTimeReceipt",
                column: "TransactionReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimeReceipt_TransactionSenderId",
                table: "ReserveTimeReceipt",
                column: "TransactionSenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimeReceipt_UserId",
                table: "ReserveTimeReceipt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimeSender_BusinessReceiptId",
                table: "ReserveTimeSender",
                column: "BusinessReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimeSender_BusinessSenderId",
                table: "ReserveTimeSender",
                column: "BusinessSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsCredit_BusinessId",
                table: "SmsCredit",
                column: "BusinessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmsTemplate_BusinessId",
                table: "SmsTemplate",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_WalletId",
                table: "Transaction",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequestPay_UserId",
                table: "UserRequestPay",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_WalletId",
                table: "Users",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVIP_BusinessId",
                table: "UserVIP",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVIP_UserId",
                table: "UserVIP",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessCategory");

            migrationBuilder.DropTable(
                name: "BusinessRequestPay");

            migrationBuilder.DropTable(
                name: "BusinessUser");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "ReserveItem");

            migrationBuilder.DropTable(
                name: "SmsCredit");

            migrationBuilder.DropTable(
                name: "SmsPlan");

            migrationBuilder.DropTable(
                name: "SmsTemplate");

            migrationBuilder.DropTable(
                name: "TransferFee");

            migrationBuilder.DropTable(
                name: "UserRequestPay");

            migrationBuilder.DropTable(
                name: "UserVIP");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "BusinessService");

            migrationBuilder.DropTable(
                name: "ReserveTimeReceipt");

            migrationBuilder.DropTable(
                name: "ReserveTimeSender");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Wallet");
        }
    }
}
