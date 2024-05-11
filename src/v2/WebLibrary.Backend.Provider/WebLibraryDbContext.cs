using Microsoft.EntityFrameworkCore;
using DbModels;

namespace Provider;

public class WebLibraryDbContext : DbContext
{
    public DbSet<DbBook> Books { get; set; }
    public DbSet<DbReader> Readers { get; set; }
    public DbSet<DbIssue> Issues { get; set; }

    public DbSet<DbHall> Halls { get; set; }
    public DbSet<DbLibrary> Libraries { get; set; }
    public DbSet<DbLibrarian> Librarians { get; set; }

    private const string ConnectionString = @"Server=MEL\SQLEXPRESS;Database=Library;Trusted_Connection=True;Encrypt=False;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DbBookConfiguration());
        modelBuilder.ApplyConfiguration(new DbReaderConfiguration());
        modelBuilder.ApplyConfiguration(new DbIssueConfiguration());

        modelBuilder.ApplyConfiguration(new DbHallConfiguration());
        modelBuilder.ApplyConfiguration(new DbLibraryConfiguration());
        modelBuilder.ApplyConfiguration(new DbLibrarianConfiguration());
    }
}