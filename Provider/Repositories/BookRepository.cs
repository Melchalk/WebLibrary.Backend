using DbModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Provider.Repositories;

public class BookRepository : IBookRepository
{
    private readonly OfficeDbContext _context = new();

    public void Add(DbBook book)
    {
        _context.Books.Add(book);

        _context.SaveChanges();
    }

    public DbBook? Get(Guid bookId)
    {
        return _context.Books.Where(u => u.Id == bookId).FirstOrDefault();
    }

    public DbSet<DbBook> Get()
    {
        return _context.Books;
    }

    public void Update(DbBook book, PropertyInfo property, string newValue)
    {
        if (int.TryParse(newValue, out var value))
        {
            property?.SetValue(book, value);
        }
        else
        {
            property?.SetValue(book, newValue);
        }

        _context.SaveChanges();
    }

    public DbBook Update(DbBook? book)
    {
        DbBook oldBook = Get(book.Id);

        foreach (PropertyInfo property in typeof(DbBook).GetProperties())
        {
            property?.SetValue(oldBook, property.GetValue(book));
        }

        _context.SaveChanges();

        return Get(book.Id);
    }

    public void Delete(DbBook book)
    {
        _context.Books.Remove(book);

        _context.SaveChanges();
    }
}