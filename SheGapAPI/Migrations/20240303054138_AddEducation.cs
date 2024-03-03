using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SheGapAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddEducation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66d872de-9534-47a0-b446-f270b7c566d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70c49395-623f-42ef-afba-562fc797813d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5ccdab8-18fe-44cd-865c-59ecc6fbe46f");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Education",
                newName: "FieldOfStudy");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "553529bc-9544-4878-885c-f9fb04c4d484", null, "Employer", "EMPLOYER" },
                    { "afb88c0b-5bec-4d0c-a4b5-9d3dd5ddf429", null, "JobSeeker", "JOBSEEKER" },
                    { "ea9ae356-3978-42a3-acc7-4026464528e7", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "553529bc-9544-4878-885c-f9fb04c4d484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afb88c0b-5bec-4d0c-a4b5-9d3dd5ddf429");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea9ae356-3978-42a3-acc7-4026464528e7");

            migrationBuilder.RenameColumn(
                name: "FieldOfStudy",
                table: "Education",
                newName: "Subject");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66d872de-9534-47a0-b446-f270b7c566d6", null, "Administrator", "ADMINISTRATOR" },
                    { "70c49395-623f-42ef-afba-562fc797813d", null, "JobSeeker", "JOBSEEKER" },
                    { "a5ccdab8-18fe-44cd-865c-59ecc6fbe46f", null, "Employer", "EMPLOYER" }
                });
        }
    }
}
