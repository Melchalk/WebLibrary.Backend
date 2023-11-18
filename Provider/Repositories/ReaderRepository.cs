using DbModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Provider.Repositories;

public class ReaderRepository : IReaderRepository
{
    private readonly OfficeDbContext _context = new();

    public void Add(DbReader reader)
    {
        _context.Readers.Add(reader);

        _context.SaveChanges();
    }
    public DbReader? Get(Guid readerId)
    {
        return _context.Readers.Where(u => u.Id == readerId).FirstOrDefault();
    }

    public DbSet<DbReader> Get()
    {
        return _context.Readers;
    }

    public DbReader Update(DbReader reader)
    {
        DbReader oldReader = Get(reader.Id);

        foreach (PropertyInfo property in typeof(DbReader).GetProperties())
        {
            property?.SetValue(oldReader, property.GetValue(reader));
        }

        _context.SaveChanges();

        return Get(reader.Id);
    }

    public void Delete(DbReader reader)
    {
        _context.Readers.Remove(reader);

        _context.SaveChanges();
    }
}