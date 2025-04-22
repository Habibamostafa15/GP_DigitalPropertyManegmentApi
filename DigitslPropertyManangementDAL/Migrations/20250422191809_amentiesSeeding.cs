using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitslPropertyManangementDAL.Migrations
{
    /// <inheritdoc />
    public partial class amentiesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Locationurl",
                table: "Properties",
                newName: "LocationUrl");

            migrationBuilder.AddColumn<string>(
                name: "ListingType",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AccessibillityAmenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessibillityAmenity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalAmenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalAmenity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalAmenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalAmenity", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "AccessibillityAmenity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Wheelchair Ramp" },
                    { 2, "Elevator Access" },
                    { 3, "Wide Hallways" },
                    { 4, "Grab Bars" },
                    { 5, "Accessible Parking" },
                    { 6, "Lowered Counters" },
                    { 7, "Voice Control System" },
                    { 8, "Automatic Doors" },
                    { 9, "Visual Alerts" },
                    { 10, "Braille Signage" }
                });

            migrationBuilder.InsertData(
                table: "ExternalAmenity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Garden" },
                    { 2, "Swimming Pool" },
                    { 3, "Parking" },
                    { 4, "Playground" },
                    { 5, "Security" },
                    { 6, "Elevator" },
                    { 7, "Balcony" },
                    { 8, "Roof Access" },
                    { 9, "BBQ Area" },
                    { 10, "Sports Court" }
                });

            migrationBuilder.InsertData(
                table: "InternalAmenity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Air Conditioning" },
                    { 2, "Central Heating" },
                    { 3, "Fireplace" },
                    { 4, "Laundry Room" },
                    { 5, "Walk-in Closet" },
                    { 6, "High-Speed Internet" },
                    { 7, "Smart Home System" },
                    { 8, "Modern Kitchen" },
                    { 9, "Hardwood Floors" },
                    { 10, "Soundproof Walls" }
                });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                columns: new[] { "ListedAt", "ListingType" },
                values: new object[] { new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6019), "sale" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                columns: new[] { "ListedAt", "ListingType" },
                values: new object[] { new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6030), "rent" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                columns: new[] { "ListedAt", "ListingType" },
                values: new object[] { new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6034), "sale" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                columns: new[] { "ListedAt", "ListingType" },
                values: new object[] { new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6037), "sale" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                columns: new[] { "ListedAt", "ListingType" },
                values: new object[] { new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6041), "rent" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                columns: new[] { "ListedAt", "ListingType" },
                values: new object[] { new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6047), "rent" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                columns: new[] { "ListedAt", "ListingType" },
                values: new object[] { new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6088), "sale" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                columns: new[] { "ListedAt", "ListingType" },
                values: new object[] { new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6092), "rent" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                columns: new[] { "ListedAt", "ListingType" },
                values: new object[] { new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6097), "sale" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                columns: new[] { "ListedAt", "ListingType" },
                values: new object[] { new DateTime(2025, 4, 22, 19, 18, 9, 0, DateTimeKind.Utc).AddTicks(6102), "rent" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessibillityAmenityProperty");

            migrationBuilder.DropTable(
                name: "ExternalAmenityProperty");

            migrationBuilder.DropTable(
                name: "InternalAmenityProperty");

            migrationBuilder.DropTable(
                name: "AccessibillityAmenity");

            migrationBuilder.DropTable(
                name: "ExternalAmenity");

            migrationBuilder.DropTable(
                name: "InternalAmenity");

            migrationBuilder.DropColumn(
                name: "ListingType",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "LocationUrl",
                table: "Properties",
                newName: "Locationurl");

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10,
                column: "ListedAt",
                value: new DateTime(2025, 4, 22, 17, 53, 25, 681, DateTimeKind.Utc).AddTicks(2740));
        }
    }
}
