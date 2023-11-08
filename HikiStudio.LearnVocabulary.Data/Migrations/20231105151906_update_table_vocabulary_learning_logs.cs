using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiStudio.LearnVocabulary.Data.Migrations
{
    public partial class update_table_vocabulary_learning_logs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2cc6a853-6563-4892-8a46-3781969f544a"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7467685b-0f44-4352-a9f9-3cae8b60e0b9"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a6debbc6-bb53-4f57-be91-9eee05499c94"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ca714a3b-6500-43b7-a1f6-14de2c84f0e9"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("68488130-0ebc-4e51-a602-e010777fbf29"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d1de9d9-8903-4783-97cc-7ba128615945"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a7dc5930-0067-4742-96ba-6467e29b39db"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b81a9917-77c0-48c1-8945-86a3db37d3dd"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a3dd1145-7815-4dbd-8e96-8d8c56a2d2f9"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.CreateTable(
                name: "VocabularyLearningLogs",
                columns: table => new
                {
                    VocabularyLearningLogID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DeviceInfo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyLearningLogs", x => x.VocabularyLearningLogID);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "12093c67-b28a-4ee5-b2c4-08c9fc96bfa6", new DateTime(2023, 11, 5, 22, 19, 6, 139, DateTimeKind.Local).AddTicks(6654) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "c7f7ee79-14f9-4b65-80b7-39b7c50375fe", new DateTime(2023, 11, 5, 22, 19, 6, 139, DateTimeKind.Local).AddTicks(6651) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "facd7050-f660-41b6-827b-91296823392b", new DateTime(2023, 11, 5, 22, 19, 6, 139, DateTimeKind.Local).AddTicks(6647) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "37bbb609-b692-4ddd-8025-c3680e85bdea", new DateTime(2023, 11, 5, 22, 19, 6, 139, DateTimeKind.Local).AddTicks(6635) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("78f94b98-4650-424c-b2ec-c629f1ee3b75"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("c625ec8c-a8e8-47ea-8ca5-5ffd1c944112"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("da1361b2-f1a6-4737-a9e9-b9898181525f"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("9221b81b-74f6-443a-a7f5-af3f8a1e092e"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("093af2be-d8b7-4ebe-a853-984707edb90b"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("6799b723-f6dc-444f-b39f-9e772e9b43d5"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("6ce80c8d-9559-40b2-bba7-092b4bda354b"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("04dc252e-0c9c-4120-9f1e-2645366fc61f"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") },
                    { new Guid("c64cea27-9401-46be-aada-5b1794c064de"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "652641f9-3881-44f4-8c80-a80fa8e863eb", new DateTime(2023, 11, 5, 22, 19, 6, 153, DateTimeKind.Local).AddTicks(6533), "AQAAAAEAACcQAAAAEEPH95AYutj9Rj2Q/59h/z5eTyQCAHZgia2t98txyrg/pT0fe6qyVIvTZoTebKaOhA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ac2b72b9-6f7b-4d47-b833-8361795252cf", "AQAAAAEAACcQAAAAEIZWrQeWoMN/sBSxe9BQgD6mEjpwWn6ZqfIblxnWCt3/AsWUSzFa4I8Gd6HPOrqXWA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "51b89be6-ff0c-4e68-b7f1-45f3f5ce652e", new DateTime(2023, 11, 5, 22, 19, 6, 160, DateTimeKind.Local).AddTicks(6752), "AQAAAAEAACcQAAAAEILRbKNfbl8H1eC5KryFpsn59y36jMPzcdlslJ23fTG28NS83Lqg4SgESMhPaXjo8Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "f79ad694-c4a2-4664-88b2-fc6765a1e13c", new DateTime(2023, 11, 5, 22, 19, 6, 174, DateTimeKind.Local).AddTicks(7412), "AQAAAAEAACcQAAAAEIT/cBVX9g5lAq0ZTyFpV4o5bAVNYrlMzRai+C1bFMxdLh+Zln/3Mipaoo0tYj+1bQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "b35f00bd-4017-4ab5-abbc-295c94530443", new DateTime(2023, 11, 5, 22, 19, 6, 167, DateTimeKind.Local).AddTicks(8809), "AQAAAAEAACcQAAAAEEnvOWAhV/0hSuVTdAfkxgIG11D3CMqyD6nYedmuPn5rg3bSOJNUDa24Q14laWp29w==" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "LanguageID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 5, 22, 19, 6, 174, DateTimeKind.Local).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "PronunciationTypes",
                keyColumn: "PronunciationTypeID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 5, 22, 19, 6, 174, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "PronunciationTypes",
                keyColumn: "PronunciationTypeID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 11, 5, 22, 19, 6, 174, DateTimeKind.Local).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 5, 22, 19, 6, 174, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 11, 5, 22, 19, 6, 174, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 11, 5, 22, 19, 6, 174, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 11, 5, 22, 19, 6, 174, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 11, 5, 22, 19, 6, 174, DateTimeKind.Local).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 11, 5, 22, 19, 6, 174, DateTimeKind.Local).AddTicks(7538));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VocabularyLearningLogs");

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("78f94b98-4650-424c-b2ec-c629f1ee3b75"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c625ec8c-a8e8-47ea-8ca5-5ffd1c944112"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("da1361b2-f1a6-4737-a9e9-b9898181525f"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9221b81b-74f6-443a-a7f5-af3f8a1e092e"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("093af2be-d8b7-4ebe-a853-984707edb90b"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6799b723-f6dc-444f-b39f-9e772e9b43d5"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6ce80c8d-9559-40b2-bba7-092b4bda354b"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("04dc252e-0c9c-4120-9f1e-2645366fc61f"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c64cea27-9401-46be-aada-5b1794c064de"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "dd618d51-ca12-4a5f-9dbe-5972b309707b", new DateTime(2023, 11, 2, 21, 37, 26, 303, DateTimeKind.Local).AddTicks(43) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "e95bbd76-293c-41a0-8fc4-37e9ccd3e07f", new DateTime(2023, 11, 2, 21, 37, 26, 303, DateTimeKind.Local).AddTicks(39) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "289b90f1-5da3-44f4-8cd0-bfcc021f0bd6", new DateTime(2023, 11, 2, 21, 37, 26, 303, DateTimeKind.Local).AddTicks(35) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "9831d75a-11cb-47f8-a0f3-2869fd2d4312", new DateTime(2023, 11, 2, 21, 37, 26, 303, DateTimeKind.Local).AddTicks(15) });

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

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "9aa2cf71-bf50-42ee-aae7-5eadebc0f9e1", new DateTime(2023, 11, 2, 21, 37, 26, 316, DateTimeKind.Local).AddTicks(7657), "AQAAAAEAACcQAAAAENBjDWxlx8ZtIK6jjPnmrk8zOoGv8P+u5abQZTdQUdf0kCxxIAxbSIO07gGfVJD/rw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9672b76e-3d48-4c42-9a0b-129744242bab", "AQAAAAEAACcQAAAAEC5wd4u3BZ2m5zJrYRwSoxxpe25jfl8VI9sCQVW1gXldw/jG6fijG3VT3y8yIgGLWA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "3dbeec78-0244-4e6d-94e4-ef4c4bad8ca4", new DateTime(2023, 11, 2, 21, 37, 26, 323, DateTimeKind.Local).AddTicks(6665), "AQAAAAEAACcQAAAAEDLqrGMzLekH6xzR+e5lfBv2UPgZMe9sZD3WzVmJQaYGh82rZF5EOdsZ98GBaiq5eA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "5f5f2f6a-a0c4-4e8a-b63d-515dfb90f71e", new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3629), "AQAAAAEAACcQAAAAEFHae+DnmjlchTjwLao4MMBER79VptmhSMxSfMxjhP+GTROVMub9xNIKcD2ZK+oP5w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "341a6481-dec7-4591-955b-8c91fe66dff1", new DateTime(2023, 11, 2, 21, 37, 26, 330, DateTimeKind.Local).AddTicks(5218), "AQAAAAEAACcQAAAAEFJgyS5aOSv+EMoxzm2wnMBuU+6n2HbwxRswGBIuDlzTKn+McRaA0IlQPUxnE0KgrQ==" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "LanguageID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "PronunciationTypes",
                keyColumn: "PronunciationTypeID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "PronunciationTypes",
                keyColumn: "PronunciationTypeID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3731));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3735));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 11, 2, 21, 37, 26, 337, DateTimeKind.Local).AddTicks(3737));
        }
    }
}
