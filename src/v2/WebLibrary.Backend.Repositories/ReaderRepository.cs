using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Provider.Interfaces;
using WebLibrary.Backend.Repositories.Interfaces;

namespace WebLibrary.Backend.Repositories;

public class ReaderRepository : IReaderRepository
{
    private readonly IDataProvider _provider;

    public ReaderRepository(IDataProvider provider)
    {
        _provider = provider;
    }

    public async Task AddAsync(DbReader reader, CancellationToken token)
    {
        await _provider.Readers.AddAsync(reader, token);

        await _provider.SaveAsync(token);
    }
    public async Task<DbReader?> GetAsync(Guid readerId, CancellationToken token)
    {
        return await _provider.Readers
            .Include(u => u.Issue)
                .ThenInclude(o => o!.Books)
            .FirstOrDefaultAsync(u => u.Id == readerId, token);
    }

    public async Task DeleteAsync(DbReader reader, CancellationToken token)
    {
        _provider.Readers.Remove(reader);

        await _provider.SaveAsync(token);
    }

    public DbSet<DbReader> Get() => _provider.Readers;

    public async Task SaveAsync(CancellationToken token) => await _provider.SaveAsync(token);
}