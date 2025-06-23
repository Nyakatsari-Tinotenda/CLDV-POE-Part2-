using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace poe.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAvailableToVenue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Venues",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Venues");
        }
    }
}
