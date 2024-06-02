using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportMVC.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_CreatedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_LastModifiedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_AspNetUsers_CreatedById",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_AspNetUsers_CreatedById",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_LastModifiedById",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_CreatedById",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Coordinators_CoordinatorId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_LastModifiedById",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_CreatedById",
                table: "Bookings",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_LastModifiedById",
                table: "Bookings",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_AspNetUsers_CreatedById",
                table: "Coupons",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_AspNetUsers_CreatedById",
                table: "Destinations",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_LastModifiedById",
                table: "Notifications",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_CreatedById",
                table: "Packages",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Coordinators_CoordinatorId",
                table: "Packages",
                column: "CoordinatorId",
                principalTable: "Coordinators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_LastModifiedById",
                table: "Reviews",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_CreatedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_LastModifiedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_AspNetUsers_CreatedById",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_AspNetUsers_CreatedById",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_LastModifiedById",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_CreatedById",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Coordinators_CoordinatorId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_LastModifiedById",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_CreatedById",
                table: "Bookings",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_LastModifiedById",
                table: "Bookings",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_AspNetUsers_CreatedById",
                table: "Coupons",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_AspNetUsers_CreatedById",
                table: "Destinations",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_LastModifiedById",
                table: "Notifications",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_CreatedById",
                table: "Packages",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Coordinators_CoordinatorId",
                table: "Packages",
                column: "CoordinatorId",
                principalTable: "Coordinators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_LastModifiedById",
                table: "Reviews",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
