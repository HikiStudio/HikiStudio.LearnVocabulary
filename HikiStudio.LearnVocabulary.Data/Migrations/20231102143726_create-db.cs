using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiStudio.LearnVocabulary.Data.Migrations
{
    public partial class createdb : Migration
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
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
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
                    { new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), "dd618d51-ca12-4a5f-9dbe-5972b309707b", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 303, DateTimeKind.Local).AddTicks(43), null, "Reader Role", "reader", "READER", null },
                    { new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), "e95bbd76-293c-41a0-8fc4-37e9ccd3e07f", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 303, DateTimeKind.Local).AddTicks(39), null, "Creator Role", "creator", "CREATOR", null },
                    { new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), "289b90f1-5da3-44f4-8cd0-bfcc021f0bd6", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 303, DateTimeKind.Local).AddTicks(35), null, "Team Members Role", "teamMembers", "TEAMMEMBERS", null },
                    { new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), "9831d75a-11cb-47f8-a0f3-2869fd2d4312", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 303, DateTimeKind.Local).AddTicks(15), null, "Administrator Role", "admin", "ADMIN", null }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "AppUserTypeId", "ConcurrencyStamp", "CreatedBy", "DOB", "DateCreated", "DatePasswordChanged", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsCreateAppUserWithThirdParty", "IsOTPVerified", "IsPasswordChanged", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "OTPExpires", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserImageURL", "UserName" },
                values: new object[] { new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"), 0, 0, "9aa2cf71-bf50-42ee-aae7-5eadebc0f9e1", null, new DateTime(2000, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 2, 21, 37, 26, 316, DateTimeKind.Local).AddTicks(7657), "hikistudio@hiki.space", true, "Admin", 2, false, null, true, "HikiStudio", false, null, "HIKISTUDIO@HIKI.SPACE", "HIKISTUDIO", null, null, "AQAAAAEAACcQAAAAENBjDWxlx8ZtIK6jjPnmrk8zOoGv8P+u5abQZTdQUdf0kCxxIAxbSIO07gGfVJD/rw==", null, false, null, "", null, null, false, "", "hikistudio" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "AppUserTypeId", "ConcurrencyStamp", "CreatedBy", "DOB", "DateCreated", "DatePasswordChanged", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsCreateAppUserWithThirdParty", "IsOTPVerified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "OTPExpires", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserImageURL", "UserName" },
                values: new object[] { new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), 0, 0, "9672b76e-3d48-4c42-9a0b-129744242bab", null, new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "tranquangbdhz@gmail.com", true, "Tran", 1, false, null, "Quang", false, null, "TRANQUANGBDHZ@GMAIL.COM", "ADMIN", null, null, "AQAAAAEAACcQAAAAEC5wd4u3BZ2m5zJrYRwSoxxpe25jfl8VI9sCQVW1gXldw/jG6fijG3VT3y8yIgGLWA==", null, false, null, "", null, null, false, "", "quangbdhz" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "AppUserTypeId", "ConcurrencyStamp", "CreatedBy", "DOB", "DateCreated", "DatePasswordChanged", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsCreateAppUserWithThirdParty", "IsOTPVerified", "IsPasswordChanged", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "OTPExpires", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserImageURL", "UserName" },
                values: new object[,]
                {
                    { new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"), 0, 0, "3dbeec78-0244-4e6d-94e4-ef4c4bad8ca4", null, new DateTime(1990, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 2, 21, 37, 26, 323, DateTimeKind.Local).AddTicks(6665), "lionelmessi@hiki.space", true, "Lionel", 1, false, null, true, "Messi", false, null, "LIONELMESSI@HIKI.SPACE", "YUKINO", null, null, "AQAAAAEAACcQAAAAEDLqrGMzLekH6xzR+e5lfBv2UPgZMe9sZD3WzVmJQaYGh82rZF5EOdsZ98GBaiq5eA==", null, false, null, "", null, null, false, "", "lionelmessi" },
                    { new Guid("4354acbc-a32a-4a28-b865-deb49695171f"), 0, 0, "5f5f2f6a-a0c4-4e8a-b63d-515dfb90f71e", null, new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3629), "reader@hiki.space", true, "Reader", 3, false, null, true, "HikiStudio", false, null, "READER@HIKI.SPACE", "READER", null, null, "AQAAAAEAACcQAAAAEFHae+DnmjlchTjwLao4MMBER79VptmhSMxSfMxjhP+GTROVMub9xNIKcD2ZK+oP5w==", null, false, null, "", null, null, false, "", "reader" },
                    { new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"), 0, 0, "341a6481-dec7-4591-955b-8c91fe66dff1", null, new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 2, 21, 37, 26, 330, DateTimeKind.Local).AddTicks(5218), "creator@hiki.space", true, "Creator", 2, false, null, true, "HikiStudio", false, null, "CREATOR@HIKI.SPACE", "CREATOR", null, null, "AQAAAAEAACcQAAAAEFJgyS5aOSv+EMoxzm2wnMBuU+6n2HbwxRswGBIuDlzTKn+McRaA0IlQPUxnE0KgrQ==", null, false, null, "", null, null, false, "", "creator" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageID", "CreatedBy", "DateCreated", "DateUpdated", "LanguageName", "UpdatedBy" },
                values: new object[] { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3706), null, "English", null });

            migrationBuilder.InsertData(
                table: "PronunciationTypes",
                columns: new[] { "PronunciationTypeID", "CreatedBy", "DateCreated", "DateUpdated", "Description", "PronunciationTypeName", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3757), null, "", "Vocal US", null },
                    { 2, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3759), null, "", "Vocal UK", null }
                });

            migrationBuilder.InsertData(
                table: "VocabularyTypes",
                columns: new[] { "VocabularyTypeID", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VocabularyTypeName" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3729), null, null, "900 Vocabulary" },
                    { 2, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3731), null, null, "Adjective" },
                    { 3, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3732), null, null, "Adverb" },
                    { 4, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3734), null, null, "Verb" },
                    { 5, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3735), null, null, "Reading" },
                    { 6, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3737), null, null, "Listening" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2cc6a853-6563-4892-8a46-3781969f544a"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("7467685b-0f44-4352-a9f9-3cae8b60e0b9"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("a6debbc6-bb53-4f57-be91-9eee05499c94"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("ca714a3b-6500-43b7-a1f6-14de2c84f0e9"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("68488130-0ebc-4e51-a602-e010777fbf29"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("8d1de9d9-8903-4783-97cc-7ba128615945"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("a7dc5930-0067-4742-96ba-6467e29b39db"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("b81a9917-77c0-48c1-8945-86a3db37d3dd"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") },
                    { new Guid("a3dd1145-7815-4dbd-8e96-8d8c56a2d2f9"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
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
