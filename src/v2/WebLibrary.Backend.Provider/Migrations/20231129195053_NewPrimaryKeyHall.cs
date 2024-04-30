using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Provider.Migrations
{
    /// <inheritdoc />
    public partial class NewPrimaryKeyHall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Halls",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Halls_LibraryId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Halls");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Halls",
                table: "Halls",
                columns: new[] { "LibraryId", "No" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Halls",
                table: "Halls");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Halls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Halls",
                table: "Halls",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_LibraryId",
                table: "Halls",
                column: "LibraryId");
        }
    }
}
