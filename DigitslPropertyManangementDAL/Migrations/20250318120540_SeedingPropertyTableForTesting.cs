using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GP_DigitalPropertyManegmentApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedingPropertyTableForTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyId", "Bathrooms", "Bedrooms", "City", "Description", "Furnished", "Governate", "IsAvailable", "Latitude", "ListedAt", "Longitude", "Price", "PropertyType", "Size", "Status", "Street", "Title" },
                values: new object[,]
                {
                    { 1, 2, 3, "Cairo", "A spacious apartment in the heart of Cairo.", true, "Cairo", true, 30.0444, new DateTime(2025, 3, 18, 12, 5, 40, 132, DateTimeKind.Utc).AddTicks(920), 31.235700000000001, 5000.0, "Apartment", 120.0, "Available", "Downtown Street", "Luxury Apartment in Cairo" },
                    { 2, 4, 5, "Giza", "A luxurious villa with a private pool.", false, "Giza", true, 29.976500000000001, new DateTime(2025, 3, 18, 12, 5, 40, 132, DateTimeKind.Utc).AddTicks(934), 31.1313, 15000.0, "Villa", 300.0, "Available", "6th October Road", "Modern Villa with Pool" },
                    { 3, 1, 1, "Alexandria", "A modern studio apartment with a sea view.", true, "Alexandria", true, 31.200099999999999, new DateTime(2025, 3, 18, 12, 5, 40, 132, DateTimeKind.Utc).AddTicks(937), 29.918700000000001, 3000.0, "Studio", 50.0, "Available", "Corniche Street", "Beachfront Studio" },
                    { 4, 3, 4, "Mansoura", "A comfortable house located in a quiet area.", false, "Dakahlia", false, 31.0364, new DateTime(2025, 3, 18, 12, 5, 40, 132, DateTimeKind.Utc).AddTicks(940), 31.380700000000001, 6000.0, "House", 180.0, "Pending", "Shobra Street", "Cozy House in Mansoura" },
                    { 5, 4, 4, "Cairo", "A high-end penthouse with a rooftop terrace.", true, "Cairo", true, 30.0489, new DateTime(2025, 3, 18, 12, 5, 40, 132, DateTimeKind.Utc).AddTicks(943), 31.3462, 20000.0, "Penthouse", 250.0, "Available", "Nasr City Main Road", "Luxury Penthouse in Nasr City" },
                    { 6, 1, 2, "Giza", "A budget-friendly apartment near public transportation.", false, "Giza", true, 29.9876, new DateTime(2025, 3, 18, 12, 5, 40, 132, DateTimeKind.Utc).AddTicks(947), 31.2134, 2500.0, "Apartment", 90.0, "Available", "Faisal Street", "Affordable Apartment in Giza" },
                    { 7, 1, 1, "Alexandria", "A small, fully furnished studio in Alexandria.", true, "Alexandria", true, 31.215599999999998, new DateTime(2025, 3, 18, 12, 5, 40, 132, DateTimeKind.Utc).AddTicks(950), 29.955300000000001, 3500.0, "Studio", 40.0, "Available", "Stanley Bridge", "Furnished Studio in Alexandria" },
                    { 8, 3, 3, "Cairo", "A stylish duplex in Maadi with garden access.", true, "Cairo", true, 30.008099999999999, new DateTime(2025, 3, 18, 12, 5, 40, 132, DateTimeKind.Utc).AddTicks(953), 31.230599999999999, 10000.0, "Duplex", 200.0, "Available", "Maadi Corniche", "Elegant Duplex in Maadi" },
                    { 9, 2, 3, "Tanta", "A simple house at an affordable price.", false, "Gharbia", true, 30.788499999999999, new DateTime(2025, 3, 18, 12, 5, 40, 132, DateTimeKind.Utc).AddTicks(956), 31.001899999999999, 4000.0, "House", 160.0, "Available", "Tanta Main Road", "Budget-Friendly House in Tanta" },
                    { 10, 5, 6, "Hurghada", "A premium villa with private beach access.", true, "Red Sea", true, 27.257899999999999, new DateTime(2025, 3, 18, 12, 5, 40, 132, DateTimeKind.Utc).AddTicks(960), 33.811599999999999, 25000.0, "Villa", 400.0, "Available", "Sahl Hasheesh", "Luxury Beachfront Villa in Hurghada" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: 10);
        }
    }
}
