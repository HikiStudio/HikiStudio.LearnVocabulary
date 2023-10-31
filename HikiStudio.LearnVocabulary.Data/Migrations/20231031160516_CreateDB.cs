using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiStudio.LearnVocabulary.Data.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    RefreshToken = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OTP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OTPExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsOTPVerified = table.Column<bool>(type: "bit", nullable: true),
                    AppUserTypeId = table.Column<int>(type: "int", nullable: false),
                    IsCreateAppUserWithThirdParty = table.Column<bool>(type: "bit", nullable: false),
                    IsPasswordChanged = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DatePasswordChanged = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageID);
                });

            migrationBuilder.CreateTable(
                name: "PronunciationTypes",
                columns: table => new
                {
                    PronunciationTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PronunciationTypeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PronunciationTypes", x => x.PronunciationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyTypes",
                columns: table => new
                {
                    VocabularyTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VocabularyTypeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyTypes", x => x.VocabularyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaims_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    AppUserLoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.AppUserLoginId);
                    table.ForeignKey(
                        name: "FK_AppUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId, x.AppUserRoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    AppUserTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.AppUserTokenId);
                    table.ForeignKey(
                        name: "FK_AppUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyWords",
                columns: table => new
                {
                    VocabularyWordID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VocabularyTypeID = table.Column<int>(type: "int", nullable: false),
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Pronunciation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ExampleSentence = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Synonyms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Antonyms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyWords", x => x.VocabularyWordID);
                    table.ForeignKey(
                        name: "FK_VocabularyWords_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyWords_VocabularyTypes_VocabularyTypeID",
                        column: x => x.VocabularyTypeID,
                        principalTable: "VocabularyTypes",
                        principalColumn: "VocabularyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudioClips",
                columns: table => new
                {
                    AudioClipID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VocabularyWordID = table.Column<long>(type: "bigint", nullable: false),
                    PronunciationTypeID = table.Column<int>(type: "int", nullable: false),
                    AudioURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioClips", x => x.AudioClipID);
                    table.ForeignKey(
                        name: "FK_AudioClips_PronunciationTypes_PronunciationTypeID",
                        column: x => x.PronunciationTypeID,
                        principalTable: "PronunciationTypes",
                        principalColumn: "PronunciationTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioClips_VocabularyWords_VocabularyWordID",
                        column: x => x.VocabularyWordID,
                        principalTable: "VocabularyWords",
                        principalColumn: "VocabularyWordID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "NormalizedName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), "1dde045e-2f20-4209-922c-228917f1a04f", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 5, 15, 933, DateTimeKind.Local).AddTicks(1869), null, "Reader Role", "reader", "READER", null },
                    { new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), "b0eae8e2-4650-4bab-849f-938e09104d17", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 5, 15, 933, DateTimeKind.Local).AddTicks(1851), null, "Creator Role", "creator", "CREATOR", null },
                    { new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), "5ab4d9fc-d60b-4d3b-af73-bb81bd9075cb", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 5, 15, 933, DateTimeKind.Local).AddTicks(1848), null, "Team Members Role", "teamMembers", "TEAMMEMBERS", null },
                    { new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), "4d3dd428-2b33-40f0-98fa-a0ca53c56b91", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 5, 15, 933, DateTimeKind.Local).AddTicks(1837), null, "Administrator Role", "admin", "ADMIN", null }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "AppUserTypeId", "ConcurrencyStamp", "CreatedBy", "DOB", "DateCreated", "DatePasswordChanged", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsCreateAppUserWithThirdParty", "IsOTPVerified", "IsPasswordChanged", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "OTPExpires", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserImageURL", "UserName" },
                values: new object[] { new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"), 0, 0, "02411099-33a4-49d9-b861-deff4ee3f5e5", null, new DateTime(2000, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 31, 23, 5, 15, 947, DateTimeKind.Local).AddTicks(1949), "hikistudio@hiki.space", true, "Admin", 2, false, null, true, "HikiStudio", false, null, "HIKISTUDIO@HIKI.SPACE", "HIKISTUDIO", null, null, "AQAAAAEAACcQAAAAEPuf+XwjkEFoOEBNQby8QPoHhpD+ayH+8MD4OiWW6yyXyunrJmPMGkhr5BAkYzNp0w==", null, false, null, "", null, null, false, "", "hikistudio" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "AppUserTypeId", "ConcurrencyStamp", "CreatedBy", "DOB", "DateCreated", "DatePasswordChanged", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsCreateAppUserWithThirdParty", "IsOTPVerified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "OTPExpires", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserImageURL", "UserName" },
                values: new object[] { new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), 0, 0, "1b4e3857-d120-4ad9-9ae5-a26468466236", null, new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "tranquangbdhz@gmail.com", true, "Tran", 1, false, null, "Quang", false, null, "TRANQUANGBDHZ@GMAIL.COM", "ADMIN", null, null, "AQAAAAEAACcQAAAAEAqhkmDy/vWD20rFdWiyuPUrJoB1ecesiHiKvSSnfPSQKgIvHrZvzCXwlm2can6QVQ==", null, false, null, "", null, null, false, "", "quangbdhz" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "AppUserTypeId", "ConcurrencyStamp", "CreatedBy", "DOB", "DateCreated", "DatePasswordChanged", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsCreateAppUserWithThirdParty", "IsOTPVerified", "IsPasswordChanged", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "OTPExpires", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserImageURL", "UserName" },
                values: new object[,]
                {
                    { new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"), 0, 0, "079ea7f7-04c4-4da1-a186-93f301712082", null, new DateTime(1990, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 31, 23, 5, 15, 954, DateTimeKind.Local).AddTicks(4486), "lionelmessi@hiki.space", true, "Lionel", 1, false, null, true, "Messi", false, null, "LIONELMESSI@HIKI.SPACE", "YUKINO", null, null, "AQAAAAEAACcQAAAAEJ8kIPFx5dd/PAAj/WcbNuuHP5OiYGCa93JRNvGB2SL7K8xBJnML2QlLgQfLbR5IbA==", null, false, null, "", null, null, false, "", "lionelmessi" },
                    { new Guid("4354acbc-a32a-4a28-b865-deb49695171f"), 0, 0, "41f36d66-fffa-461a-9c4e-c5084b9b5940", null, new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 31, 23, 5, 15, 968, DateTimeKind.Local).AddTicks(3794), "reader@hiki.space", true, "Reader", 3, false, null, true, "HikiStudio", false, null, "READER@HIKI.SPACE", "READER", null, null, "AQAAAAEAACcQAAAAEIzcO8CNBxnEcQ6JeXDXLj2MQIiZhB7sIx7xItpz5RCiWHKsF/j4z9MYwc/CJ+udTg==", null, false, null, "", null, null, false, "", "reader" },
                    { new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"), 0, 0, "b9804ab0-27ca-43a9-a89d-edc9361e97e9", null, new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 31, 23, 5, 15, 961, DateTimeKind.Local).AddTicks(4905), "creator@hiki.space", true, "Creator", 2, false, null, true, "HikiStudio", false, null, "CREATOR@HIKI.SPACE", "CREATOR", null, null, "AQAAAAEAACcQAAAAELaEC0a/2fhqK+zhKKe8xglhL8CTuTQiKfZThuxOgl1ZEx//n3rmH2ycWzqsEOwg0Q==", null, false, null, "", null, null, false, "", "creator" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("553a9b94-0e18-43cd-b6a8-e1142ae15dbc"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("5c4c5850-7e50-48e9-ab16-a65c4c7dd2bf"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("39ae1190-1b0a-4fcd-9e3c-a101e1cc1fe0"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("706cec7c-8410-4070-8b8f-7f3176a2e344"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("fcee965a-d828-43d3-85a8-61417b9a20a5"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("4d57e875-7e27-4114-a00b-eb3f9b821ae4"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("4dae3bc2-0757-4061-a757-43a09f87fe30"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("c25eb131-2b43-4477-b52d-98bbb198bf99"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") },
                    { new Guid("dd725f3c-4ac0-4af4-a379-c164af4e8e30"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AppRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLogins_UserId",
                table: "AppUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTokens_UserId",
                table: "AppUserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioClips_PronunciationTypeID",
                table: "AudioClips",
                column: "PronunciationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AudioClips_VocabularyWordID",
                table: "AudioClips",
                column: "VocabularyWordID");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyWords_LanguageID",
                table: "VocabularyWords",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyWords_VocabularyTypeID",
                table: "VocabularyWords",
                column: "VocabularyTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "AudioClips");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "PronunciationTypes");

            migrationBuilder.DropTable(
                name: "VocabularyWords");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "VocabularyTypes");
        }
    }
}
