using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GP_DigitalPropertyManegmentApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClassModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Amenities_AmenityId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_Properties_PropertyId",
                table: "PropertyImage");

            migrationBuilder.DropTable(
                name: "PropertyAmenities");

            migrationBuilder.DropIndex(
                name: "IX_Properties_AmenityId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyImage",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "AmenityId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "PropertyImage",
                newName: "PropertiesImages");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertiesImages",
                newName: "IX_PropertiesImages_PropertyId");

            migrationBuilder.AddColumn<int>(
                name: "NotificationId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertiesImages",
                table: "PropertiesImages",
                column: "ImageId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_NotificationId",
                table: "Users",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_AmenityProperty_PropertiesPropertyId",
                table: "AmenityProperty",
                column: "PropertiesPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesImages_Properties_PropertyId",
                table: "PropertiesImages",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Notifications_NotificationId",
                table: "Users",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "NotificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesImages_Properties_PropertyId",
                table: "PropertiesImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Notifications_NotificationId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AmenityProperty");

            migrationBuilder.DropIndex(
                name: "IX_Users_NotificationId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertiesImages",
                table: "PropertiesImages");

            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "PropertiesImages",
                newName: "PropertyImage");

            migrationBuilder.RenameIndex(
                name: "IX_PropertiesImages_PropertyId",
                table: "PropertyImage",
                newName: "IX_PropertyImage_PropertyId");

            migrationBuilder.AddColumn<int>(
                name: "AmenityId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyImage",
                table: "PropertyImage",
                column: "ImageId");

            migrationBuilder.CreateTable(
                name: "PropertyAmenities",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAmenities", x => new { x.PropertyId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_PropertyAmenities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAmenities_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AmenityId",
                table: "Properties",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAmenities_AmenityId",
                table: "PropertyAmenities",
                column: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Amenities_AmenityId",
                table: "Properties",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_Properties_PropertyId",
                table: "PropertyImage",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId");
        }
    }
}
