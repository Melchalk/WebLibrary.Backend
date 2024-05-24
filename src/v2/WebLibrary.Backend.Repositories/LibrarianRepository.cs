using Microsoft.EntityFrameworkCore;
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

    public async Task AddAsync(DbLibrarian librarian, CancellationToken token)
    {
        await _provider.Librarians.AddAsync(librarian, token);

        await _provider.SaveAsync(token);
    }

    public async Task<DbLibrarian?> GetAsync(Guid librarianId, CancellationToken token)
    {
        return await _provider.Librarians
            .FirstOrDefaultAsync(u => u.Id == librarianId, token);
    }

    public async Task DeleteAsync(DbLibrarian librarian, CancellationToken token)
    {
        _provider.Librarians.Remove(librarian);

        await _provider.SaveAsync(token);
    }

    public DbSet<DbLibrarian> Get() => _provider.Librarians;

    public async Task SaveAsync(CancellationToken token) => await _provider.SaveAsync(token);
}