using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Provider.Migrations
{
    /// <inheritdoc />
    public partial class DeleteIssueBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueBooks");

            migrationBuilder.DropColumn(
                name: "CanTakeBooks",
                table: "Readers");

            migrationBuilder.AddColumn<Guid>(
                name: "IssueId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_IssueId",
                table: "Books",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Issues_IssueId",
                table: "Books",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Issues_IssueId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_IssueId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "CanTakeBooks",
                table: "Readers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "IssueBooks",
                columns: table => new
                {
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBooks", x => new { x.IssueId, x.BookId });
                    table.ForeignKey(
                        name: "FK_IssueBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueBooks_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueBooks_BookId",
                table: "IssueBooks",
                column: "BookId");
        }
    }
}
