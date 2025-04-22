using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitslPropertyManangementDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                column: "ListedAt",
                value: new DateTime(2025, 4, 21, 19, 15, 15, 516, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                column: "ListedAt",
                value: new DateTime(2025, 4, 21, 19, 15, 15, 516, DateTimeKind.Utc).AddTicks(1943));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                column: "ListedAt",
                value: new DateTime(2025, 4, 21, 19, 15, 15, 516, DateTimeKind.Utc).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                column: "ListedAt",
                value: new DateTime(2025, 4, 21, 19, 15, 15, 516, DateTimeKind.Utc).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                column: "ListedAt",
                value: new DateTime(2025, 4, 21, 19, 15, 15, 516, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                column: "ListedAt",
                value: new DateTime(2025, 4, 21, 19, 15, 15, 516, DateTimeKind.Utc).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                column: "ListedAt",
                value: new DateTime(2025, 4, 21, 19, 15, 15, 516, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                column: "ListedAt",
                value: new DateTime(2025, 4, 21, 19, 15, 15, 516, DateTimeKind.Utc).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                column: "ListedAt",
                value: new DateTime(2025, 4, 21, 19, 15, 15, 516, DateTimeKind.Utc).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                column: "ListedAt",
                value: new DateTime(2025, 4, 21, 19, 15, 15, 516, DateTimeKind.Utc).AddTicks(1968));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                column: "ListedAt",
                value: new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                column: "ListedAt",
                value: new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                column: "ListedAt",
                value: new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                column: "ListedAt",
                value: new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                column: "ListedAt",
                value: new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8309));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                column: "ListedAt",
                value: new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                column: "ListedAt",
                value: new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                column: "ListedAt",
                value: new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                column: "ListedAt",
                value: new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                column: "ListedAt",
                value: new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8326));
        }
    }
}
