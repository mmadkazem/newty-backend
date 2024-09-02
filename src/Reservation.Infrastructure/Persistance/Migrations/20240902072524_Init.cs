using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reservation.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsPlans",
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
                    table.PrimaryKey("PK_SmsPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferFees",
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
                    table.PrimaryKey("PK_TransferFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
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
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CardNumber = table.Column<string>(type: "text", nullable: true),
                    CoverImagePath = table.Column<string>(type: "text", nullable: true),
                    ParvaneKasbImagePath = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsCancelReserveTime = table.Column<bool>(type: "boolean", nullable: false),
                    IsClose = table.Column<bool>(type: "boolean", nullable: false),
                    StartHoursOfWor = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndHoursOfWor = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Holidays = table.Column<int[]>(type: "integer[]", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: true),
                    SmsCreditId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Businesses_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
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
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
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
                    CityId = table.Column<int>(type: "integer", nullable: true),
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
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Artists",
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
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCategory",
                columns: table => new
                {
                    BusinessesId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategory", x => new { x.BusinessesId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BusinessCategory_Businesses_BusinessesId",
                        column: x => x.BusinessesId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Posts",
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
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "SmsCredits",
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
                    table.PrimaryKey("PK_SmsCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsCredits_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmsTemplates",
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
                    table.PrimaryKey("PK_SmsTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsTemplates_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
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
                        name: "FK_BusinessUser_Businesses_BusinessesId",
                        column: x => x.BusinessesId,
                        principalTable: "Businesses",
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
                name: "ReserveTimesReceipt",
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
                    table.PrimaryKey("PK_ReserveTimesReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveTimesReceipt_Businesses_BusinessReceiptId",
                        column: x => x.BusinessReceiptId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimesReceipt_Businesses_BusinessSenderId",
                        column: x => x.BusinessSenderId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimesReceipt_Transactions_TransactionReceiptId",
                        column: x => x.TransactionReceiptId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimesReceipt_Transactions_TransactionSenderId",
                        column: x => x.TransactionSenderId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveTimesReceipt_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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

            migrationBuilder.CreateTable(
                name: "UsersVIP",
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
                    table.PrimaryKey("PK_UsersVIP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersVIP_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersVIP_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Points",
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
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Points_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Points_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
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
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Coupon_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReserveItems",
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
                    table.PrimaryKey("PK_ReserveItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveItems_ReserveTimesReceipt_ReserveTimeReceiptId",
                        column: x => x.ReserveTimeReceiptId,
                        principalTable: "ReserveTimesReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReserveItems_ReserveTimesSender_ReserveTimeSenderId",
                        column: x => x.ReserveTimeSenderId,
                        principalTable: "ReserveTimesSender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReserveItems_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Alternatives", "CreatedOn", "DeletedOn", "FaName", "IsDeleted", "Key", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, new List<string> { "tehran" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(3695), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تهران", false, "tehran", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new List<string> { "ahwaz", "ahvaz" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(3884), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اهواز", false, "ahwaz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new List<string> { "shiraz" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(3907), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شیراز", false, "shiraz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new List<string> { "mashhad" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(3924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مشهد", false, "mashhad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new List<string> { "bandar abbas" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(3941), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بندر عباس", false, "bandar-abbas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new List<string> { "isfahan", "esfahan" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(3962), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اصفهان", false, "isfahan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new List<string> { "tabriz" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(3980), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تبریز", false, "tabriz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new List<string> { "kish" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(3995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کیش", false, "kish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new List<string> { "abadan" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4011), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "آبادان", false, "abadan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new List<string> { "arak" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4092), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اراک", false, "arak", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new List<string> { "ardabil" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4109), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اردبیل", false, "ardabil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new List<string> { "orumiyeh" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4124), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ارومیه", false, "orumiyeh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new List<string> { "omIdieh" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4139), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "امیدیه", false, "omIdieh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new List<string> { "iranshahr" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4154), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ایران شهر", false, "iranshahr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new List<string> { "ilam" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4170), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ایلام", false, "ilam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new List<string> { "bojnourd" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4186), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بجنورد", false, "bojnourd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new List<string> { "bam" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4201), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بم", false, "bam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new List<string> { "bandar lengeh" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4217), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بندر لنگه", false, "bandar-lengeh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new List<string> { "bushehr", "booshehr" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4232), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بوشهر", false, "bushehr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new List<string> { "birjand" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4249), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بیرجند", false, "birjand", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new List<string> { "pars-abad" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4264), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "پارس آباد", false, "pars-abad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new List<string> { "jask" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4279), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جاسک", false, "jask", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new List<string> { "jahrom" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4293), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جهرم", false, "jahrom", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new List<string> { "jiroft" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4308), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جیرفت", false, "jiroft", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new List<string> { "chabahar" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4323), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "چابهار", false, "chabahar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new List<string> { "khark" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4337), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خارک", false, "khark", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new List<string> { "khorramabad" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خرم آباد", false, "khorramabad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new List<string> { "khoy" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4376), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خوی", false, "khoy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new List<string> { "dezful" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4391), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "دزفول", false, "dezful", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new List<string> { "ramsar" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4406), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رامسر", false, "ramsar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new List<string> { "rasht" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4421), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رشت", false, "rasht", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new List<string> { "rafsanjan" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4435), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رفسنجان", false, "rafsanjan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new List<string> { "zabol" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4451), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زابل", false, "zabol", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new List<string> { "zahedan" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4467), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زاهدان", false, "zahedan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, new List<string> { "zanjan" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4482), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زنجان", false, "zanjan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, new List<string> { "sari" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4497), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ساری", false, "sari", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, new List<string> { "sabzevar" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4511), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سبزوار", false, "sabzevar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, new List<string> { "semnan" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سمنان", false, "semnan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, new List<string> { "sanandaj" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4541), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سنندج", false, "sanandaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, new List<string> { "maragheh" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4556), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مراغه", false, "maragheh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, new List<string> { "syrjan" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4570), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "سیرجان", false, "syrjan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, new List<string> { "shahroud" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4585), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شاهرود", false, "shahroud", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, new List<string> { "shahrekord" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4599), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شهرکرد", false, "shahrekord", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, new List<string> { "tabas" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4614), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "طبس", false, "tabas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, new List<string> { "asalouyeh" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4629), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "عسلویه", false, "asalouyeh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, new List<string> { "omidieh" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4644), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "امیدیه", false, "omidieh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, new List<string> { "qeshm" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4660), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "قشم", false, "qeshm", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, new List<string> { "qom", "ghom" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4674), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "قم", false, "qom", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, new List<string> { "kashan" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4691), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کاشان", false, "kashan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, new List<string> { "karaj" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4706), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرج", false, "karaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, new List<string> { "kerman" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4720), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرمان", false, "kerman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, new List<string> { "kermanshah" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4735), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کرمانشاه", false, "kermanshah", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, new List<string> { "kolaleh" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4750), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کولاله", false, "kolaleh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, new List<string> { "gachsaran" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4764), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "گچساران", false, "gachsaran", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, new List<string> { "gorgan" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4787), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "گرگان", false, "gorgan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, new List<string> { "lar" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4802), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لار", false, "lar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, new List<string> { "lamard" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4816), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لامراد", false, "lamard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, new List<string> { "makou" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4831), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماکو", false, "makou", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, new List<string> { "mahshahr" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4845), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماهشار", false, "mahshahr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, new List<string> { "noshahr" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4860), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "نوشهر", false, "noshahr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, new List<string> { "hamedan" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4874), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "همدان", false, "hamedan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, new List<string> { "yasouj" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4889), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "یاسوج", false, "yasouj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, new List<string> { "yazd" }, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(4903), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "یزد", false, "yazd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TransferFees",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Percent" },
                values: new object[] { new Guid("e2635bc0-c7f5-47cf-88c6-dc9cf3c125a0"), new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(6443), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "FullName", "IsActive", "IsDeleted", "ModifiedOn", "PhoneNumber", "Role", "WalletId" },
                values: new object[] { new Guid("649ed7ab-c231-4d8a-ad76-6e36e3d487b7"), null, new DateTime(2024, 9, 2, 10, 55, 23, 5, DateTimeKind.Local).AddTicks(100), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09111111111", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_BusinessId",
                table: "Artists",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCategory_CategoriesId",
                table: "BusinessCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_CityId",
                table: "Businesses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_WalletId",
                table: "Businesses",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRequestPays_BusinessId",
                table: "BusinessRequestPays",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUser_UsersNormalId",
                table: "BusinessUser",
                column: "UsersNormalId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_ServiceId",
                table: "Coupon",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_ArtistId",
                table: "Points",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_BusinessId",
                table: "Points",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_UserId",
                table: "Points",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BusinessId",
                table: "Posts",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ReserveTimeReceiptId",
                table: "ReserveItems",
                column: "ReserveTimeReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ReserveTimeSenderId",
                table: "ReserveItems",
                column: "ReserveTimeSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ServiceId",
                table: "ReserveItems",
                column: "ServiceId");

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
                column: "TransactionReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesReceipt_TransactionSenderId",
                table: "ReserveTimesReceipt",
                column: "TransactionSenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesReceipt_UserId",
                table: "ReserveTimesReceipt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesSender_BusinessReceiptId",
                table: "ReserveTimesSender",
                column: "BusinessReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimesSender_BusinessSenderId",
                table: "ReserveTimesSender",
                column: "BusinessSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ArtistId",
                table: "Services",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BusinessId",
                table: "Services",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsCredits_BusinessId",
                table: "SmsCredits",
                column: "BusinessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmsTemplates_BusinessId",
                table: "SmsTemplates",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequestPays_UserId",
                table: "UserRequestPays",
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
                name: "IX_UsersVIP_BusinessId",
                table: "UsersVIP",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersVIP_UserId",
                table: "UsersVIP",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessCategory");

            migrationBuilder.DropTable(
                name: "BusinessRequestPays");

            migrationBuilder.DropTable(
                name: "BusinessUser");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "ReserveItems");

            migrationBuilder.DropTable(
                name: "SmsCredits");

            migrationBuilder.DropTable(
                name: "SmsPlans");

            migrationBuilder.DropTable(
                name: "SmsTemplates");

            migrationBuilder.DropTable(
                name: "TransferFees");

            migrationBuilder.DropTable(
                name: "UserRequestPays");

            migrationBuilder.DropTable(
                name: "UsersVIP");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ReserveTimesReceipt");

            migrationBuilder.DropTable(
                name: "ReserveTimesSender");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Wallets");
        }
    }
}
