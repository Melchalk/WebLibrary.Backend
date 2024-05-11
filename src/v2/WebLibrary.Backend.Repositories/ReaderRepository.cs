using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

    public async Task AddAsync(DbReader reader)
    {
        _provider.Readers.Add(reader);

        await _provider.SaveAsync();
    }
    public async Task<DbReader?> GetAsync(Guid readerId)
    {
        return await _provider.Readers
            .Include(u => u.Issue)
                .ThenInclude(o => o.Books)
            .FirstOrDefaultAsync(u => u.Id == readerId);
    }

    public DbSet<DbReader> Get()
    {
        return _provider.Readers;
    }

    public async Task UpdateAsync(DbReader reader)
    {
        DbReader? oldReader = await GetAsync(reader.Id);

        foreach (PropertyInfo property in typeof(DbReader).GetProperties())
        {
            property?.SetValue(oldReader, property.GetValue(reader));
        }

        await _provider.SaveAsync();
    }

    public async Task DeleteAsync(DbReader reader)
    {
        _provider.Readers.Remove(reader);

        await _provider.SaveAsync();
    }
}