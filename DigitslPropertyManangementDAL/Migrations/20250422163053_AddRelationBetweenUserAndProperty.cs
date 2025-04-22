using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitslPropertyManangementDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenUserAndProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Locationurl",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                columns: new[] { "ListedAt", "Locationurl", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(6984), null, null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                columns: new[] { "ListedAt", "Locationurl", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(6998), null, null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                columns: new[] { "ListedAt", "Locationurl", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7005), null, null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                columns: new[] { "ListedAt", "Locationurl", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7011), null, null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                columns: new[] { "ListedAt", "Locationurl", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7017), null, null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                columns: new[] { "ListedAt", "Locationurl", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7026), null, null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                columns: new[] { "ListedAt", "Locationurl", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7032), null, null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                columns: new[] { "ListedAt", "Locationurl", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7038), null, null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                columns: new[] { "ListedAt", "Locationurl", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7044), null, null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                columns: new[] { "ListedAt", "Locationurl", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7051), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UserId",
                table: "Properties",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_UserId",
                table: "Properties",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_UserId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_UserId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Locationurl",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Properties");

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
    }
}
