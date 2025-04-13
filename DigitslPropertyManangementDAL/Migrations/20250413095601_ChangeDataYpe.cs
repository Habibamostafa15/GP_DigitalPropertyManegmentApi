using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitslPropertyManangementDAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataYpe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BirthOfDate",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 56, 0, 294, DateTimeKind.Utc).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 56, 0, 294, DateTimeKind.Utc).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 56, 0, 294, DateTimeKind.Utc).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 56, 0, 294, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 56, 0, 294, DateTimeKind.Utc).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 56, 0, 294, DateTimeKind.Utc).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 56, 0, 294, DateTimeKind.Utc).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 56, 0, 294, DateTimeKind.Utc).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 56, 0, 294, DateTimeKind.Utc).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 56, 0, 294, DateTimeKind.Utc).AddTicks(4039));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthOfDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 43, 33, 10, DateTimeKind.Utc).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 43, 33, 10, DateTimeKind.Utc).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 43, 33, 10, DateTimeKind.Utc).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 43, 33, 10, DateTimeKind.Utc).AddTicks(4648));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 43, 33, 10, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 43, 33, 10, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 43, 33, 10, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 43, 33, 10, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 43, 33, 10, DateTimeKind.Utc).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                column: "ListedAt",
                value: new DateTime(2025, 4, 13, 9, 43, 33, 10, DateTimeKind.Utc).AddTicks(4679));
        }
    }
}
