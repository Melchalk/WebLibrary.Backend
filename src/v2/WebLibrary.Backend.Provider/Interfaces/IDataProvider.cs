using DbModels;
using Microsoft.EntityFrameworkCore;

namespace StructureOfUniversity.PostgreSql.Ef.Interfaces;

public interface IDataProvider : IBaseDataProvider
{
    DbSet<DbBook> Books { get; set; }
    DbSet<DbReader> Readers { get; set; }
    DbSet<DbIssue> Issues { get; set; }
    DbSet<DbHall> Halls { get; set; }
    DbSet<DbLibrary> Libraries { get; set; }
    DbSet<DbLibrarian> Librarians { get; set; }
}
