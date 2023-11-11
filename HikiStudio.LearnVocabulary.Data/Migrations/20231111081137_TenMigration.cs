using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiStudio.LearnVocabulary.Data.Migrations
{
    public partial class TenMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "CourseLearningLogs",
                columns: table => new
                {
                    CourseLearningLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    LearningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Log = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Score = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLearningLogs", x => x.CourseLearningLogID);
                    table.ForeignKey(
                        name: "FK_CourseLearningLogs_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseLearningLogs_CourseID",
                table: "CourseLearningLogs",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseLearningLogs");
        }
    }
}
