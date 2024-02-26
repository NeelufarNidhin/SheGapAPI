using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SheGapAPI.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenFieldAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "217c134d-73e6-4de6-96b2-6d40891e2d4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7757212e-b644-4c86-a9c5-d82ea5504653");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b713fcfc-e2c3-4164-b362-12910320850c");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bd581ca-fcd1-4c34-8602-ca287852b0fd", null, "Employer", "EMPLOYER" },
                    { "b2f56c5d-e6a2-4604-8f8d-792502be30ca", null, "Employee", "Employee" },
                    { "c76190b4-babf-4c22-b473-eeb8ca105dfd", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd581ca-fcd1-4c34-8602-ca287852b0fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2f56c5d-e6a2-4604-8f8d-792502be30ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76190b4-babf-4c22-b473-eeb8ca105dfd");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "217c134d-73e6-4de6-96b2-6d40891e2d4c", null, "Administrator", "ADMINISTRATOR" },
                    { "7757212e-b644-4c86-a9c5-d82ea5504653", null, "Employer", "EMPLOYER" },
                    { "b713fcfc-e2c3-4164-b362-12910320850c", null, "Employee", "Employee" }
                });
        }
    }
}
