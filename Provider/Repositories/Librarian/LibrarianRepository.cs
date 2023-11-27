using DbModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Provider.Repositories.Librarian;

public class LibrarianRepository : ILibrarianRepository
{
    private readonly OfficeDbContext _context = new();

    public async Task AddAsync(DbLibrarian librarian)
    {
        _context.Librarians.Add(librarian);

        await _context.SaveChangesAsync();
    }

    public async Task<DbLibrarian?> GetAsync(Guid librarianId)
    {
        return await _context.Librarians.FirstOrDefaultAsync(u => u.Id == librarianId);
    }

    public DbSet<DbLibrarian> Get()
    {
        return _context.Librarians;
    }

    public async Task<DbLibrarian?> UpdateAsync(DbLibrarian? librarian)
    {
        DbLibrarian? oldLibrarian = GetAsync(librarian.Id).Result;

        if (oldLibrarian is null)
        {
            return null;
        }

        foreach (PropertyInfo property in typeof(DbLibrarian).GetProperties())
        {
            property?.SetValue(oldLibrarian, property.GetValue(librarian));
        }

        await _context.SaveChangesAsync();

        return GetAsync(librarian.Id).Result;
    }

    public async Task DeleteAsync(DbLibrarian librarian)
    {
        _context.Librarians.Remove(librarian);

        await _context.SaveChangesAsync();
    }
}