using DbModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Provider.Repositories.Library;

public class LibraryRepository : ILibraryRepository
{
    private readonly OfficeDbContext _context = new();

    public async Task AddAsync(DbLibrary library)
    {
        _context.Libraries.Add(library);

        await _context.SaveChangesAsync();
    }

    public async Task<DbLibrary?> GetAsync(Guid libraryId)
    {
        return await _context.Libraries.FirstOrDefaultAsync(u => u.Id == libraryId);
    }

    public DbSet<DbLibrary> Get()
    {
        return _context.Libraries;
    }

    public async Task<DbLibrary?> UpdateAsync(DbLibrary? library)
    {
        DbLibrary? oldLibrary = await GetAsync(library.Id);

        if (oldLibrary is null)
        {
            return null;
        }

        foreach (PropertyInfo property in typeof(DbLibrary).GetProperties())
        {
            property?.SetValue(oldLibrary, property.GetValue(library));
        }

        await _context.SaveChangesAsync();

        return await GetAsync(library.Id);
    }

    public async Task DeleteAsync(DbLibrary library)
    {
        _context.Libraries.Remove(library);

        await _context.SaveChangesAsync();
    }
}