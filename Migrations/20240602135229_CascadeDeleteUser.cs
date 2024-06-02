using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportMVC.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteUser : Migration
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
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_LastModifiedById",
                table: "Bookings",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_LastModifiedById",
                table: "Reviews",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
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
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications");

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
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications",
                column: "CreatedById",
                principalTable: "AspNetUsers",
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
    }
}
