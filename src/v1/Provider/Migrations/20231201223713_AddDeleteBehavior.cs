using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Provider.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Issues_IssueId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Libraries_LibraryId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Readers_ReaderId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Librarians_Libraries_LibraryId",
                table: "Librarians");

            migrationBuilder.AlterColumn<Guid>(
                name: "LibraryId",
                table: "Librarians",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Issues_IssueId",
                table: "Books",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Libraries_LibraryId",
                table: "Halls",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Readers_ReaderId",
                table: "Issues",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Librarians_Libraries_LibraryId",
                table: "Librarians",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Issues_IssueId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Libraries_LibraryId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Readers_ReaderId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Librarians_Libraries_LibraryId",
                table: "Librarians");

            migrationBuilder.AlterColumn<Guid>(
                name: "LibraryId",
                table: "Librarians",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Issues_IssueId",
                table: "Books",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Libraries_LibraryId",
                table: "Halls",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Readers_ReaderId",
                table: "Issues",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Librarians_Libraries_LibraryId",
                table: "Librarians",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
