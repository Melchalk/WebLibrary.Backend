using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Provider.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbReader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Readers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Readers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
