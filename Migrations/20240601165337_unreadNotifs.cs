using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportMVC.Migrations
{
    /// <inheritdoc />
    public partial class unreadNotifs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NbUnreadNotifications",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbUnreadNotifications",
                table: "AspNetUsers");
        }
    }
}
