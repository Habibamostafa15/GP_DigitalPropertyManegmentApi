using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitslPropertyManangementDAL.Migrations
{
    /// <inheritdoc />
    public partial class assignUsersToTheSeededProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2659), 1 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2667), 2 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2670), 3 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2673), 4 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2676), 5 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2680), 6 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2682), 7 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2686), 8 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2689), 9 });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2740), 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(6984), null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(6998), null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7005), null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7011), null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7017), null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7026), null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7032), null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7038), null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7044), null });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                columns: new[] { "ListedAt", "UserId" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(7051), null });
        }
    }
}
