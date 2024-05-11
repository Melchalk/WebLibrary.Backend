using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Provider.Interfaces;
using WebLibrary.Backend.Repositories.Interfaces;

namespace WebLibrary.Backend.Repositories;

public class LibrarianRepository : ILibrarianRepository
{
    private readonly IDataProvider _provider;

    public LibrarianRepository(IDataProvider provider)
    {
        _provider = provider;
    }

    public async Task AddAsync(DbLibrarian librarian)
    {
        _provider.Librarians.Add(librarian);

        await _provider.SaveAsync();
    }

    public async Task<DbLibrarian?> GetAsync(Guid librarianId)
    {
        return await _provider.Librarians
            .FirstOrDefaultAsync(u => u.Id == librarianId);
    }

    public DbSet<DbLibrarian> Get()
    {
        return _provider.Librarians;
    }

    public async Task UpdateAsync(DbLibrarian librarian)
    {
        DbLibrarian? oldLibrarian = await GetAsync(librarian.Id);

        foreach (PropertyInfo property in typeof(DbLibrarian).GetProperties())
        {
            property?.SetValue(oldLibrarian, property.GetValue(librarian));
        }

        await _provider.SaveAsync();
    }

    public async Task DeleteAsync(DbLibrarian librarian)
    {
        _provider.Librarians.Remove(librarian);

        await _provider.SaveAsync();
    }
}