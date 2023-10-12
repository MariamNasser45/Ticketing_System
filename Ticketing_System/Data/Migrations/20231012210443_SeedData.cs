using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ticketing_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Hardware" },
                    { 2, "Software" },
                    { 3, "Network" }
                });

            migrationBuilder.InsertData(
                table: "Severities",
                columns: new[] { "SeverityId", "SeverityName" },
                values: new object[,]
                {
                    { 1, "Low" },
                    { 2, "Medium" },
                    { 3, "High" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Assigned" },
                    { 3, "Resolved" },
                    { 4, "Escalated" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Severities",
                keyColumn: "SeverityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Severities",
                keyColumn: "SeverityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Severities",
                keyColumn: "SeverityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4);
        }
    }
}
