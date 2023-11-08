using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiStudio.LearnVocabulary.Data.Migrations
{
    public partial class addfieldtotablevocabulrywords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ExampleSentenceMeaning",
                table: "VocabularyWords",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "198ea972-faf5-46e3-97b9-e8548ee0e4b8", new DateTime(2023, 11, 7, 22, 6, 34, 406, DateTimeKind.Local).AddTicks(7996) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "c5e5cc3a-5399-44a4-b4b7-c6f5347ec931", new DateTime(2023, 11, 7, 22, 6, 34, 406, DateTimeKind.Local).AddTicks(7993) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "389d2d32-02ad-4d63-8642-623c7825cc24", new DateTime(2023, 11, 7, 22, 6, 34, 406, DateTimeKind.Local).AddTicks(7990) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "6bc0a538-9c3f-4d6e-92a2-9bab95b380e5", new DateTime(2023, 11, 7, 22, 6, 34, 406, DateTimeKind.Local).AddTicks(7972) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("17253770-7823-412d-a084-7f25dd7b4049"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("3a674752-7b54-4bde-8614-ce54d5c8fc40"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("2be07006-0586-4ac4-8105-d400d8c5ffe8"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("60747fcb-bf41-4eb8-9245-4ad6b14d92b7"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("e08566fb-eb28-4a71-ab23-8abe2f159e2d"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("ca32ae74-2324-4c0c-a86b-2f52d00a6561"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("27f4aee8-733a-48dd-8c89-23d9e2ef9d24"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("d3bad556-78de-4a2a-ae1a-f2041b4d8bba"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") },
                    { new Guid("2059281a-465e-4c33-8755-cbd30b8e4dc2"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "11dd175a-9813-4e99-93a0-4fe0184bb0d8", new DateTime(2023, 11, 7, 22, 6, 34, 425, DateTimeKind.Local).AddTicks(788), "AQAAAAEAACcQAAAAEKApKxD72peNAGSPUlxrXpUR603fuv7dy5v3rzJPYHXPSUxjo5gX0ogcR7fbd4jNUQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f739194d-2596-49b9-aa28-d0ead756f9e2", "AQAAAAEAACcQAAAAEGp5szjmRxm/rRC+Hw3FI2ey04s+ZZv21VvZqh70Txwmq7Q5ZsFON39Io5qB+hIlMw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "312d703f-bc0a-4e2c-b56f-c8b33e46d2ae", new DateTime(2023, 11, 7, 22, 6, 34, 433, DateTimeKind.Local).AddTicks(129), "AQAAAAEAACcQAAAAEMrltqlD9J3UKXyU+wURtmDiqYEOjuVTJlWBeWwLpo4qzj/iYyImeTE40pjvQUryAQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "712e9083-21fc-4599-9d48-3bff2b37edda", new DateTime(2023, 11, 7, 22, 6, 34, 448, DateTimeKind.Local).AddTicks(5040), "AQAAAAEAACcQAAAAEIzObfQsbn8TvlrA6uVj5pdLU5RbnJBIylbEHDOmwUnedu3p8SgMPmuc8lIgkmRa1A==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "269720db-e5d5-48c4-93c0-e3c01bdbf346", new DateTime(2023, 11, 7, 22, 6, 34, 440, DateTimeKind.Local).AddTicks(9234), "AQAAAAEAACcQAAAAEAJaHpXRuyqiYfWoAOA7hVfPMBkLyS4m23QltCkVFSGJFz+NtFmtge6ktZvmy8yejQ==" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "LanguageID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 7, 22, 6, 34, 448, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "PronunciationTypes",
                keyColumn: "PronunciationTypeID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 7, 22, 6, 34, 448, DateTimeKind.Local).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "PronunciationTypes",
                keyColumn: "PronunciationTypeID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 11, 7, 22, 6, 34, 448, DateTimeKind.Local).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 11, 7, 22, 6, 34, 448, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 11, 7, 22, 6, 34, 448, DateTimeKind.Local).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 11, 7, 22, 6, 34, 448, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 11, 7, 22, 6, 34, 448, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 11, 7, 22, 6, 34, 448, DateTimeKind.Local).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 11, 7, 22, 6, 34, 448, DateTimeKind.Local).AddTicks(5377));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("17253770-7823-412d-a084-7f25dd7b4049"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a674752-7b54-4bde-8614-ce54d5c8fc40"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2be07006-0586-4ac4-8105-d400d8c5ffe8"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("60747fcb-bf41-4eb8-9245-4ad6b14d92b7"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e08566fb-eb28-4a71-ab23-8abe2f159e2d"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ca32ae74-2324-4c0c-a86b-2f52d00a6561"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("27f4aee8-733a-48dd-8c89-23d9e2ef9d24"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d3bad556-78de-4a2a-ae1a-f2041b4d8bba"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2059281a-465e-4c33-8755-cbd30b8e4dc2"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DropColumn(
                name: "ExampleSentenceMeaning",
                table: "VocabularyWords");

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
    }
}
