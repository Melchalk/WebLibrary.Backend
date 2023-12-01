using DbModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Provider.Repositories.Reader;

public class ReaderRepository : IReaderRepository
{
    private readonly OfficeDbContext _context = new();

    public async Task AddAsync(DbReader reader)
    {
        _context.Readers.Add(reader);

        await _context.SaveChangesAsync();
    }
    public async Task<DbReader?> GetAsync(Guid readerId)
    {
        return await _context.Readers
            .Include(u => u.Issue)
            .FirstOrDefaultAsync(u => u.Id == readerId);
    }

    public DbSet<DbReader> Get()
    {
        return _context.Readers;
    }

    public async Task<DbReader?> UpdateAsync(DbReader reader)
    {
        DbReader? oldReader = await GetAsync(reader.Id);

        if (oldReader is null)
        {
            return null;
        }

        foreach (PropertyInfo property in typeof(DbReader).GetProperties())
        {
            property?.SetValue(oldReader, property.GetValue(reader));
        }

        await _context.SaveChangesAsync();

        return await GetAsync(reader.Id);
    }

    public async Task DeleteAsync(DbReader reader)
    {
        _context.Readers.Remove(reader);

        await _context.SaveChangesAsync();
    }
}