using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitslPropertyManangementDAL.Migrations
{
    /// <inheritdoc />
    public partial class inialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.AmenityId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteId);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Furnished = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ListedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Governate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthOfDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTermsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId");
                });

            migrationBuilder.CreateTable(
                name: "AmenityProperty",
                columns: table => new
                {
                    AmenitiesAmenityId = table.Column<int>(type: "int", nullable: false),
                    PropertiesPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityProperty", x => new { x.AmenitiesAmenityId, x.PropertiesPropertyId });
                    table.ForeignKey(
                        name: "FK_AmenityProperty_Amenities_AmenitiesAmenityId",
                        column: x => x.AmenitiesAmenityId,
                        principalTable: "Amenities",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenityProperty_Properties_PropertiesPropertyId",
                        column: x => x.PropertiesPropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_PropertiesImages_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId");
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BotResponse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferenceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.PreferenceId);
                    table.ForeignKey(
                        name: "FK_Preferences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SearchHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchQuery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserPropertyDocuments",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPropertyDocuments", x => new { x.UserId, x.PropertyId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_UserPropertyDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPropertyDocuments_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPropertyDocuments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPropertyFavorites",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FavoriteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPropertyFavorites", x => new { x.UserId, x.PropertyId });
                    table.ForeignKey(
                        name: "FK_UserPropertyFavorites_Favorites_FavoriteId",
                        column: x => x.FavoriteId,
                        principalTable: "Favorites",
                        principalColumn: "FavoriteId");
                    table.ForeignKey(
                        name: "FK_UserPropertyFavorites_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPropertyFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPropertyPayments",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPropertyPayments", x => new { x.UserId, x.PropertyId, x.PaymentId });
                    table.ForeignKey(
                        name: "FK_UserPropertyPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPropertyPayments_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPropertyPayments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPropertyReviews",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPropertyReviews", x => new { x.UserId, x.PropertyId });
                    table.ForeignKey(
                        name: "FK_UserPropertyReviews_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPropertyReviews_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId");
                    table.ForeignKey(
                        name: "FK_UserPropertyReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyId", "Bathrooms", "Bedrooms", "City", "Description", "Furnished", "Governate", "IsAvailable", "Latitude", "ListedAt", "Longitude", "Price", "PropertyType", "Size", "Status", "Street", "Title" },
                values: new object[,]
                {
                    { 1, 2, 3, "Cairo", "A spacious apartment in the heart of Cairo.", true, "Cairo", true, 30.0444, new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8294), 31.235700000000001, 5000.0, "Apartment", 120.0, "Available", "Downtown Street", "Luxury Apartment in Cairo" },
                    { 2, 4, 5, "Giza", "A luxurious villa with a private pool.", false, "Giza", true, 29.976500000000001, new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8300), 31.1313, 15000.0, "Villa", 300.0, "Available", "6th October Road", "Modern Villa with Pool" },
                    { 3, 1, 1, "Alexandria", "A modern studio apartment with a sea view.", true, "Alexandria", true, 31.200099999999999, new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8303), 29.918700000000001, 3000.0, "Studio", 50.0, "Available", "Corniche Street", "Beachfront Studio" },
                    { 4, 3, 4, "Mansoura", "A comfortable house located in a quiet area.", false, "Dakahlia", false, 31.0364, new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8306), 31.380700000000001, 6000.0, "House", 180.0, "Pending", "Shobra Street", "Cozy House in Mansoura" },
                    { 5, 4, 4, "Cairo", "A high-end penthouse with a rooftop terrace.", true, "Cairo", true, 30.0489, new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8309), 31.3462, 20000.0, "Penthouse", 250.0, "Available", "Nasr City Main Road", "Luxury Penthouse in Nasr City" },
                    { 6, 1, 2, "Giza", "A budget-friendly apartment near public transportation.", false, "Giza", true, 29.9876, new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8314), 31.2134, 2500.0, "Apartment", 90.0, "Available", "Faisal Street", "Affordable Apartment in Giza" },
                    { 7, 1, 1, "Alexandria", "A small, fully furnished studio in Alexandria.", true, "Alexandria", true, 31.215599999999998, new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8316), 29.955300000000001, 3500.0, "Studio", 40.0, "Available", "Stanley Bridge", "Furnished Studio in Alexandria" },
                    { 8, 3, 3, "Cairo", "A stylish duplex in Maadi with garden access.", true, "Cairo", true, 30.008099999999999, new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8319), 31.230599999999999, 10000.0, "Duplex", 200.0, "Available", "Maadi Corniche", "Elegant Duplex in Maadi" },
                    { 9, 2, 3, "Tanta", "A simple house at an affordable price.", false, "Gharbia", true, 30.788499999999999, new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8322), 31.001899999999999, 4000.0, "House", 160.0, "Available", "Tanta Main Road", "Budget-Friendly House in Tanta" },
                    { 10, 5, 6, "Hurghada", "A premium villa with private beach access.", true, "Red Sea", true, 27.257899999999999, new DateTime(2025, 4, 18, 22, 34, 45, 502, DateTimeKind.Utc).AddTicks(8326), 33.811599999999999, 25000.0, "Villa", 400.0, "Available", "Sahl Hasheesh", "Luxury Beachfront Villa in Hurghada" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenityProperty_PropertiesPropertyId",
                table: "AmenityProperty",
                column: "PropertiesPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_UserId",
                table: "ChatMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_UserId",
                table: "Preferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesImages_PropertyId",
                table: "PropertiesImages",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistories_UserId",
                table: "SearchHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPropertyDocuments_DocumentId",
                table: "UserPropertyDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPropertyDocuments_PropertyId",
                table: "UserPropertyDocuments",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPropertyFavorites_FavoriteId",
                table: "UserPropertyFavorites",
                column: "FavoriteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPropertyFavorites_PropertyId",
                table: "UserPropertyFavorites",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPropertyPayments_PaymentId",
                table: "UserPropertyPayments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPropertyPayments_PropertyId",
                table: "UserPropertyPayments",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPropertyReviews_PropertyId",
                table: "UserPropertyReviews",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPropertyReviews_ReviewId",
                table: "UserPropertyReviews",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NotificationId",
                table: "Users",
                column: "NotificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenityProperty");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "PropertiesImages");

            migrationBuilder.DropTable(
                name: "SearchHistories");

            migrationBuilder.DropTable(
                name: "UserPropertyDocuments");

            migrationBuilder.DropTable(
                name: "UserPropertyFavorites");

            migrationBuilder.DropTable(
                name: "UserPropertyPayments");

            migrationBuilder.DropTable(
                name: "UserPropertyReviews");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
