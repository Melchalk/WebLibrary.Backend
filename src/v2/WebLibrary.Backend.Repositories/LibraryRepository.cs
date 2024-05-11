using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Provider.Interfaces;
using WebLibrary.Backend.Repositories.Interfaces;

namespace WebLibrary.Backend.Repositories;

public class LibraryRepository : ILibraryRepository
{
    private readonly IDataProvider _provider;

    public LibraryRepository(IDataProvider provider)
    {
        _provider = provider;
    }

    public async Task AddAsync(DbLibrary library)
    {
        _provider.Libraries.Add(library);

        await _provider.SaveAsync();
    }

    public async Task<DbLibrary?> GetAsync(Guid libraryId)
    {
        return await _provider.Libraries
            .Include(u => u.Librarians)
            .Include(o => o.Halls)
            .FirstOrDefaultAsync(u => u.Id == libraryId);
    }

    public DbSet<DbLibrary> Get()
    {
        return _provider.Libraries;
    }

    public async Task UpdateAsync(DbLibrary library)
    {
        DbLibrary? oldLibrary = await GetAsync(library.Id);

        foreach (PropertyInfo property in typeof(DbLibrary).GetProperties())
        {
            property?.SetValue(oldLibrary, property.GetValue(library));
        }

        await _provider.SaveAsync();
    }

    public async Task DeleteAsync(DbLibrary library)
    {
        _provider.Libraries.Remove(library);

        await _provider.SaveAsync();
    }
}