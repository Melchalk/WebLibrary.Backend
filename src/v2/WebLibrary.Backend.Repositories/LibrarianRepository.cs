using DbModels;
using Microsoft.EntityFrameworkCore;
using Provider;
using System.Reflection;
using WebLibrary.Backend.Provider.Repositories.Interfaces;

namespace WebLibrary.Backend.Provider.Repositories;

public class LibrarianRepository : ILibrarianRepository
{
    private readonly WebLibraryDbContext _context = new();

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
        DbLibrarian? oldLibrarian = await GetAsync(librarian.Id);

        if (oldLibrarian is null)
        {
            return null;
        }

        foreach (PropertyInfo property in typeof(DbLibrarian).GetProperties())
        {
            property?.SetValue(oldLibrarian, property.GetValue(librarian));
        }

        await _context.SaveChangesAsync();

        return await GetAsync(librarian.Id);
    }

    public async Task DeleteAsync(DbLibrarian librarian)
    {
        _context.Librarians.Remove(librarian);

        await _context.SaveChangesAsync();
    }
}