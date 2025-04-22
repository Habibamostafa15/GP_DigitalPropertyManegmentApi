using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitslPropertyManangementDAL.Migrations
{
    /// <inheritdoc />
    public partial class updateSeededProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessibillityAmenityProperty");

            migrationBuilder.DropTable(
                name: "ExternalAmenityProperty");

            migrationBuilder.DropTable(
                name: "InternalAmenityProperty");

            migrationBuilder.CreateTable(
                name: "PropertyAccessibilityAmenities",
                columns: table => new
                {
                    PropertiesPropertyId = table.Column<int>(type: "int", nullable: false),
                    AccessibilityAmenitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAccessibilityAmenities", x => new { x.PropertiesPropertyId, x.AccessibilityAmenitiesId });
                    table.ForeignKey(
                        name: "FK_PropertyAccessibilityAmenities_AccessibillityAmenity_AccessibilityAmenitiesId",
                        column: x => x.AccessibilityAmenitiesId,
                        principalTable: "AccessibillityAmenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAccessibilityAmenities_Properties_PropertiesPropertyId",
                        column: x => x.PropertiesPropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyExternalAmenities",
                columns: table => new
                {
                    PropertiesPropertyId = table.Column<int>(type: "int", nullable: false),
                    ExternalAmenitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyExternalAmenities", x => new { x.PropertiesPropertyId, x.ExternalAmenitiesId });
                    table.ForeignKey(
                        name: "FK_PropertyExternalAmenities_ExternalAmenity_ExternalAmenitiesId",
                        column: x => x.ExternalAmenitiesId,
                        principalTable: "ExternalAmenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyExternalAmenities_Properties_PropertiesPropertyId",
                        column: x => x.PropertiesPropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyInternalAmenities",
                columns: table => new
                {
                    PropertiesPropertyId = table.Column<int>(type: "int", nullable: false),
                    InternalAmenitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyInternalAmenities", x => new { x.PropertiesPropertyId, x.InternalAmenitiesId });
                    table.ForeignKey(
                        name: "FK_PropertyInternalAmenities_InternalAmenity_InternalAmenitiesId",
                        column: x => x.InternalAmenitiesId,
                        principalTable: "InternalAmenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyInternalAmenities_Properties_PropertiesPropertyId",
                        column: x => x.PropertiesPropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 20, 11, 6, 651, DateTimeKind.Utc).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 20, 11, 6, 651, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 20, 11, 6, 651, DateTimeKind.Utc).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 20, 11, 6, 651, DateTimeKind.Utc).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 20, 11, 6, 651, DateTimeKind.Utc).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 20, 11, 6, 651, DateTimeKind.Utc).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 20, 11, 6, 651, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 20, 11, 6, 651, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 20, 11, 6, 651, DateTimeKind.Utc).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 20, 11, 6, 651, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.InsertData(
                table: "PropertyAccessibilityAmenities",
                columns: new[] { "AccessibilityAmenitiesId", "PropertiesPropertyId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 5, 2 },
                    { 8, 2 },
                    { 9, 3 },
                    { 10, 3 },
                    { 3, 4 },
                    { 6, 4 },
                    { 2, 5 },
                    { 7, 5 },
                    { 8, 5 },
                    { 4, 6 },
                    { 5, 6 },
                    { 2, 7 },
                    { 9, 7 },
                    { 3, 8 },
                    { 7, 8 },
                    { 5, 9 },
                    { 6, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 8, 10 }
                });

            migrationBuilder.InsertData(
                table: "PropertyExternalAmenities",
                columns: new[] { "ExternalAmenitiesId", "PropertiesPropertyId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 6, 1 },
                    { 8, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 5, 3 },
                    { 7, 3 },
                    { 1, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 6, 5 },
                    { 8, 5 },
                    { 9, 5 },
                    { 3, 6 },
                    { 5, 6 },
                    { 6, 7 },
                    { 7, 7 },
                    { 1, 8 },
                    { 3, 8 },
                    { 8, 8 },
                    { 1, 9 },
                    { 3, 9 },
                    { 4, 9 },
                    { 2, 10 },
                    { 3, 10 },
                    { 9, 10 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "PropertyInternalAmenities",
                columns: new[] { "InternalAmenitiesId", "PropertiesPropertyId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 1 },
                    { 8, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 7, 2 },
                    { 1, 3 },
                    { 9, 3 },
                    { 3, 4 },
                    { 5, 4 },
                    { 10, 4 },
                    { 1, 5 },
                    { 7, 5 },
                    { 8, 5 },
                    { 9, 5 },
                    { 1, 6 },
                    { 6, 6 },
                    { 8, 7 },
                    { 9, 7 },
                    { 1, 8 },
                    { 6, 8 },
                    { 7, 8 },
                    { 2, 9 },
                    { 5, 9 },
                    { 10, 9 },
                    { 1, 10 },
                    { 7, 10 },
                    { 8, 10 },
                    { 9, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAccessibilityAmenities_AccessibilityAmenitiesId",
                table: "PropertyAccessibilityAmenities",
                column: "AccessibilityAmenitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExternalAmenities_ExternalAmenitiesId",
                table: "PropertyExternalAmenities",
                column: "ExternalAmenitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInternalAmenities_InternalAmenitiesId",
                table: "PropertyInternalAmenities",
                column: "InternalAmenitiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyAccessibilityAmenities");

            migrationBuilder.DropTable(
                name: "PropertyExternalAmenities");

            migrationBuilder.DropTable(
                name: "PropertyInternalAmenities");

            migrationBuilder.CreateTable(
                name: "AccessibillityAmenityProperty",
                columns: table => new
                {
                    AccessibillityAmenitiesId = table.Column<int>(type: "int", nullable: false),
                    PropertiesPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessibillityAmenityProperty", x => new { x.AccessibillityAmenitiesId, x.PropertiesPropertyId });
                    table.ForeignKey(
                        name: "FK_AccessibillityAmenityProperty_AccessibillityAmenity_AccessibillityAmenitiesId",
                        column: x => x.AccessibillityAmenitiesId,
                        principalTable: "AccessibillityAmenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessibillityAmenityProperty_Properties_PropertiesPropertyId",
                        column: x => x.PropertiesPropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalAmenityProperty",
                columns: table => new
                {
                    ExternalAmenitiesId = table.Column<int>(type: "int", nullable: false),
                    PropertiesPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalAmenityProperty", x => new { x.ExternalAmenitiesId, x.PropertiesPropertyId });
                    table.ForeignKey(
                        name: "FK_ExternalAmenityProperty_ExternalAmenity_ExternalAmenitiesId",
                        column: x => x.ExternalAmenitiesId,
                        principalTable: "ExternalAmenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalAmenityProperty_Properties_PropertiesPropertyId",
                        column: x => x.PropertiesPropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalAmenityProperty",
                columns: table => new
                {
                    InternalAmenitiesId = table.Column<int>(type: "int", nullable: false),
                    PropertiesPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalAmenityProperty", x => new { x.InternalAmenitiesId, x.PropertiesPropertyId });
                    table.ForeignKey(
                        name: "FK_InternalAmenityProperty_InternalAmenity_InternalAmenitiesId",
                        column: x => x.InternalAmenitiesId,
                        principalTable: "InternalAmenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalAmenityProperty_Properties_PropertiesPropertyId",
                        column: x => x.PropertiesPropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.CreateIndex(
                name: "IX_AccessibillityAmenityProperty_PropertiesPropertyId",
                table: "AccessibillityAmenityProperty",
                column: "PropertiesPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAmenityProperty_PropertiesPropertyId",
                table: "ExternalAmenityProperty",
                column: "PropertiesPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalAmenityProperty_PropertiesPropertyId",
                table: "InternalAmenityProperty",
                column: "PropertiesPropertyId");
        }
    }
}
