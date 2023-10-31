using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiStudio.LearnVocabulary.Data.Migrations
{
    public partial class createandseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("553a9b94-0e18-43cd-b6a8-e1142ae15dbc"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5c4c5850-7e50-48e9-ab16-a65c4c7dd2bf"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("39ae1190-1b0a-4fcd-9e3c-a101e1cc1fe0"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("706cec7c-8410-4070-8b8f-7f3176a2e344"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fcee965a-d828-43d3-85a8-61417b9a20a5"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d57e875-7e27-4114-a00b-eb3f9b821ae4"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4dae3bc2-0757-4061-a757-43a09f87fe30"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c25eb131-2b43-4477-b52d-98bbb198bf99"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dd725f3c-4ac0-4af4-a379-c164af4e8e30"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PronunciationTypes",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "70609af6-946a-493c-8463-4bd52b73b7cf", new DateTime(2023, 10, 31, 23, 32, 34, 136, DateTimeKind.Local).AddTicks(753) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "81595e06-1ad3-48a4-8a01-c25596886334", new DateTime(2023, 10, 31, 23, 32, 34, 136, DateTimeKind.Local).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "24469813-1862-456e-8a8b-f69108a2a432", new DateTime(2023, 10, 31, 23, 32, 34, 136, DateTimeKind.Local).AddTicks(737) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "8f6fb116-dad6-4ec2-a7ae-a58f357b40a8", new DateTime(2023, 10, 31, 23, 32, 34, 136, DateTimeKind.Local).AddTicks(725) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("31df2fd3-c12d-40b8-ac73-22564a0cec1b"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("263fc365-207d-4347-bb13-e49ed7fec927"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("22b1f019-7af2-4ac0-b810-298cefbbb4f8"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("9e2f3617-7a5a-4660-9ed6-dc1017381c41"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("2792f28b-4cb8-44eb-8755-b9b06ae125f1"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("5c55ea28-de08-4456-a03a-9b920b3dc2fc"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("bfa5439a-d707-4fdf-9e61-817a55bacb48"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("cdf77322-41a1-4cf5-b2d2-a72862fa4aee"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") },
                    { new Guid("a26b0661-3329-4e1c-b10a-cb00c182f85c"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "89962388-a649-4469-a424-0cc84df2ebdf", new DateTime(2023, 10, 31, 23, 32, 34, 150, DateTimeKind.Local).AddTicks(835), "AQAAAAEAACcQAAAAECoBCiI0Blyv4Dd8vKY8ACSdWsb2WqKtdOwpYAFUPyCb8NhFdG5PtD8o4e5K0bLhVw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb6c0c0a-04f9-474e-abf2-9e1a7d1377a8", "AQAAAAEAACcQAAAAEANfuwAh40QGl0Jl8VDGIjUpXTFOLebWPCfIfAHVqtsYW/M7h/zZXm8b+b3UFqFXEQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "837e1c91-cbb0-4170-9ae0-81e1082149eb", new DateTime(2023, 10, 31, 23, 32, 34, 157, DateTimeKind.Local).AddTicks(1745), "AQAAAAEAACcQAAAAEMMYuRvY7kAW/pD+0VeMSKg6adeadbeYQWSaJoSY7TB+MmS+7A4eNjUkiTHEbqKluQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "cd7699c5-82ef-489b-aebc-8f10d1c9dd02", new DateTime(2023, 10, 31, 23, 32, 34, 171, DateTimeKind.Local).AddTicks(913), "AQAAAAEAACcQAAAAELz7TajTq8i6BcrTcyWhU2+m4gc+x/f30wEqvaBaIcu6q7BBlb8eK21S1AVr7NB3Uw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "f8425a9b-6ea4-498c-bddd-db7d6fc4d898", new DateTime(2023, 10, 31, 23, 32, 34, 164, DateTimeKind.Local).AddTicks(770), "AQAAAAEAACcQAAAAEAM77gL+0mMdH1a6wIDKbe+JgmF8uJ92XmjyaWBcLhAZopCcXbvJzhihQuR847NnJw==" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageID", "CreatedBy", "DateCreated", "DateUpdated", "LanguageName", "UpdatedBy" },
                values: new object[] { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 32, 34, 171, DateTimeKind.Local).AddTicks(1064), null, "English", null });

            migrationBuilder.InsertData(
                table: "PronunciationTypes",
                columns: new[] { "PronunciationTypeID", "CreatedBy", "DateCreated", "DateUpdated", "Description", "PronunciationTypeName", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 32, 34, 171, DateTimeKind.Local).AddTicks(1114), null, "", "Vocal US", null },
                    { 2, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 32, 34, 171, DateTimeKind.Local).AddTicks(1116), null, "", "Vocal US", null }
                });

            migrationBuilder.InsertData(
                table: "VocabularyTypes",
                columns: new[] { "VocabularyTypeID", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VocabularyTypeName" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 32, 34, 171, DateTimeKind.Local).AddTicks(1087), null, null, "900 Vocabulary" },
                    { 2, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 32, 34, 171, DateTimeKind.Local).AddTicks(1089), null, null, "Adjective" },
                    { 3, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 32, 34, 171, DateTimeKind.Local).AddTicks(1090), null, null, "Adverb" },
                    { 4, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 32, 34, 171, DateTimeKind.Local).AddTicks(1092), null, null, "Verb" },
                    { 5, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 32, 34, 171, DateTimeKind.Local).AddTicks(1093), null, null, "Reading" },
                    { 6, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 10, 31, 23, 32, 34, 171, DateTimeKind.Local).AddTicks(1094), null, null, "Listening" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("31df2fd3-c12d-40b8-ac73-22564a0cec1b"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("263fc365-207d-4347-bb13-e49ed7fec927"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22b1f019-7af2-4ac0-b810-298cefbbb4f8"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9e2f3617-7a5a-4660-9ed6-dc1017381c41"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2792f28b-4cb8-44eb-8755-b9b06ae125f1"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5c55ea28-de08-4456-a03a-9b920b3dc2fc"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bfa5439a-d707-4fdf-9e61-817a55bacb48"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cdf77322-41a1-4cf5-b2d2-a72862fa4aee"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a26b0661-3329-4e1c-b10a-cb00c182f85c"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PronunciationTypes",
                keyColumn: "PronunciationTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PronunciationTypes",
                keyColumn: "PronunciationTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VocabularyTypes",
                keyColumn: "VocabularyTypeID",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PronunciationTypes");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "1dde045e-2f20-4209-922c-228917f1a04f", new DateTime(2023, 10, 31, 23, 5, 15, 933, DateTimeKind.Local).AddTicks(1869) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "b0eae8e2-4650-4bab-849f-938e09104d17", new DateTime(2023, 10, 31, 23, 5, 15, 933, DateTimeKind.Local).AddTicks(1851) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "5ab4d9fc-d60b-4d3b-af73-bb81bd9075cb", new DateTime(2023, 10, 31, 23, 5, 15, 933, DateTimeKind.Local).AddTicks(1848) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "4d3dd428-2b33-40f0-98fa-a0ca53c56b91", new DateTime(2023, 10, 31, 23, 5, 15, 933, DateTimeKind.Local).AddTicks(1837) });

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

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "02411099-33a4-49d9-b861-deff4ee3f5e5", new DateTime(2023, 10, 31, 23, 5, 15, 947, DateTimeKind.Local).AddTicks(1949), "AQAAAAEAACcQAAAAEPuf+XwjkEFoOEBNQby8QPoHhpD+ayH+8MD4OiWW6yyXyunrJmPMGkhr5BAkYzNp0w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b4e3857-d120-4ad9-9ae5-a26468466236", "AQAAAAEAACcQAAAAEAqhkmDy/vWD20rFdWiyuPUrJoB1ecesiHiKvSSnfPSQKgIvHrZvzCXwlm2can6QVQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "079ea7f7-04c4-4da1-a186-93f301712082", new DateTime(2023, 10, 31, 23, 5, 15, 954, DateTimeKind.Local).AddTicks(4486), "AQAAAAEAACcQAAAAEJ8kIPFx5dd/PAAj/WcbNuuHP5OiYGCa93JRNvGB2SL7K8xBJnML2QlLgQfLbR5IbA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "41f36d66-fffa-461a-9c4e-c5084b9b5940", new DateTime(2023, 10, 31, 23, 5, 15, 968, DateTimeKind.Local).AddTicks(3794), "AQAAAAEAACcQAAAAEIzcO8CNBxnEcQ6JeXDXLj2MQIiZhB7sIx7xItpz5RCiWHKsF/j4z9MYwc/CJ+udTg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "b9804ab0-27ca-43a9-a89d-edc9361e97e9", new DateTime(2023, 10, 31, 23, 5, 15, 961, DateTimeKind.Local).AddTicks(4905), "AQAAAAEAACcQAAAAELaEC0a/2fhqK+zhKKe8xglhL8CTuTQiKfZThuxOgl1ZEx//n3rmH2ycWzqsEOwg0Q==" });
        }
    }
}
