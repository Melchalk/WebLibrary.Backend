using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Provider.Migrations
{
    /// <inheritdoc />
    public partial class AddCanTakeBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanTakeBooks",
                table: "Readers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanTakeBooks",
                table: "Readers");
        }
    }
}
