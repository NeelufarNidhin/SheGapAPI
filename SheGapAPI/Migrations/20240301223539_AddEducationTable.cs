using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SheGapAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddEducationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28479c4e-39fe-45ff-a472-1dd39fbd0284");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "378ab8b8-3ded-4d1c-9f7f-1cfe086ad9f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fd7e045-fba1-47f4-976e-d60095fb1748");

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    College = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationYear = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobSeekerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d63e6c3-3594-49ba-92d4-8172e6622707", null, "Administrator", "ADMINISTRATOR" },
                    { "b9f78707-98fa-46cc-96f8-f1a7c0a12c1c", null, "JobSeeker", "JOBSEEKER" },
                    { "cc9a2901-8a0d-4d0d-aec0-7cebd40d2112", null, "Employer", "EMPLOYER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_JobSeekerId",
                table: "Education",
                column: "JobSeekerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d63e6c3-3594-49ba-92d4-8172e6622707");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9f78707-98fa-46cc-96f8-f1a7c0a12c1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc9a2901-8a0d-4d0d-aec0-7cebd40d2112");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28479c4e-39fe-45ff-a472-1dd39fbd0284", null, "Employer", "EMPLOYER" },
                    { "378ab8b8-3ded-4d1c-9f7f-1cfe086ad9f5", null, "JobSeeker", "JOBSEEKER" },
                    { "5fd7e045-fba1-47f4-976e-d60095fb1748", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
