using Microsoft.EntityFrameworkCore;
using DbModels;
using System.Reflection;

namespace Provider;

public class WebLibraryDbContext : DbContext
{
    public DbSet<DbBook> Books { get; set; }
    public DbSet<DbReader> Readers { get; set; }
    public DbSet<DbIssue> Issues { get; set; }
    public DbSet<DbHall> Halls { get; set; }
    public DbSet<DbLibrary> Libraries { get; set; }
    public DbSet<DbLibrarian> Librarians { get; set; }

    public WebLibraryDbContext(DbContextOptions<WebLibraryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("WebLibrary.Backend.Models.Db"));
    }

    public async Task SaveAsync()
    {
        await SaveChangesAsync();
    }

    public void Save()
    {
        SaveChanges();
    }
}