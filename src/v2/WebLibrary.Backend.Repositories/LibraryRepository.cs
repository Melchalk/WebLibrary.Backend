using Microsoft.EntityFrameworkCore;
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

    public async Task AddAsync(DbLibrary library, CancellationToken token)
    {
        await _provider.Libraries.AddAsync(library, token);

        await _provider.SaveAsync(token);
    }

    public async Task<DbLibrary?> GetAsync(int number, CancellationToken token)
    {
        return await _provider.Libraries
            .Include(l => l.Librarians)
            .Include(l => l.Halls)
            .Include(l => l.Books)
            .FirstOrDefaultAsync(l => l.Number == number, token);
    }

    public async Task DeleteAsync(DbLibrary library, CancellationToken token)
    {
        _provider.Libraries.Remove(library);

        await _provider.SaveAsync(token);
    }

    public DbSet<DbLibrary> Get() => _provider.Libraries;

    public async Task SaveAsync(CancellationToken token) => await _provider.SaveAsync(token);
}