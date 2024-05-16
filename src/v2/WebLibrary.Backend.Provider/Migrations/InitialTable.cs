using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Provider.Migrations;

[DbContext(typeof(WebLibraryDbContext))]
[Migration("20240511202617_InitialTables")]
class InitialTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        #region Sequence

        var sequenceLibrary = "generate_library_number_seq";
        migrationBuilder.Sql($"CREATE SEQUENCE {sequenceLibrary} START WITH 1 INCREMENT BY 1;");

        #endregion

        #region Reader

        migrationBuilder.CreateTable(
            name: DbReader.TableName,
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                FullName = table.Column<string>(nullable: false, maxLength: 50),
                Phone = table.Column<string>(nullable: false, maxLength: 50),
                RegistrationAddress = table.Column<string>(nullable: true, maxLength: 50),
                Age = table.Column<uint>(nullable: false),
                CanTakeBooks = table.Column<bool>(nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Readers", x => x.Id);
            }
        );

        #endregion

        #region Issue

        migrationBuilder.CreateTable(
            name: DbIssue.TableName,
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                ReaderId = table.Column<Guid>(nullable: false),
                ReturnDate = table.Column<DateTime>(nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Issue", x => x.Id);

                table.ForeignKey(
                    "FK_Issue_Reader",
                    x => x.ReaderId,
                    DbReader.TableName);
            }
        );

        #endregion

        #region Library

        migrationBuilder.CreateTable(
            name: DbLibrary.TableName,
            columns: table => new
            {
                Number = table.Column<int>(nullable: false, defaultValueSql: $"nextval('{sequenceLibrary}')"),
                Title = table.Column<string>(nullable: false, maxLength: 50),
                Address = table.Column<string>(nullable: false, maxLength: 50),
                Phone = table.Column<string>(nullable: false, maxLength: 50),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Library", x => x.Number);
            }
        );

        #endregion

        #region Book

        migrationBuilder.CreateTable(
            name: DbBook.TableName,
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                LibraryNumber = table.Column<int>(nullable: true),
                Title = table.Column<string>(nullable: false, maxLength: 50),
                Author = table.Column<string>(nullable: true, maxLength: 50),
                NumberPages = table.Column<uint>(nullable: false),
                YearPublishing = table.Column<uint>(nullable: false),
                CityPublishing = table.Column<string>(nullable: true, maxLength: 50),
                HallNo = table.Column<uint>(nullable: true),
                IssueId = table.Column<Guid>(nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Books", x => x.Id);

                table.ForeignKey(
                    "FK_Book_Issue",
                    x => x.IssueId,
                    DbIssue.TableName);

                table.ForeignKey(
                    "FK_Book_Library",
                    x => x.LibraryNumber,
                    DbLibrary.TableName);
            }
        );

        #endregion

        #region Hall

        migrationBuilder.CreateTable(
            name: DbHall.TableName,
            columns: table => new
            {
                LibraryNumber = table.Column<int>(nullable: false),
                Number = table.Column<uint>(nullable: false),
                Title = table.Column<string>(nullable: true, maxLength: 50),
                Thematic = table.Column<string>(nullable: false, maxLength: 50),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Hall", x => new { x.LibraryNumber, x.Number });

                table.ForeignKey(
                    "FK_Hall_Library",
                    x => x.LibraryNumber,
                    DbLibrary.TableName);
            }
        );

        #endregion

        #region Librarian

        migrationBuilder.CreateTable(
            name: DbLibrarian.TableName,
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                LibraryNumber = table.Column<int>(nullable: true),
                FullName = table.Column<string>(nullable: true, maxLength: 50),
                Phone = table.Column<string>(nullable: false, maxLength: 50),
                Password = table.Column<string>(nullable: false),
                Salt = table.Column<string>(nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Librarian", x => x.Id);

                table.ForeignKey(
                    "FK_Librarian_Library",
                    x => x.LibraryNumber,
                    DbLibrary.TableName);
            }
        );

        #endregion
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(DbLibrarian.TableName);
        migrationBuilder.DropTable(DbHall.TableName);
        migrationBuilder.DropTable(DbBook.TableName);
        migrationBuilder.DropTable(DbLibrary.TableName);
        migrationBuilder.DropTable(DbIssue.TableName);
        migrationBuilder.DropTable(DbReader.TableName);
    }
}
