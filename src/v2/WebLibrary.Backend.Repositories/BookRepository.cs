using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Provider.Interfaces;
using WebLibrary.Backend.Repositories.Interfaces;

namespace WebLibrary.Backend.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IDataProvider _provider;

    public BookRepository(IDataProvider provider)
    {
        _provider = provider;
    }

    public async Task AddAsync(DbBook book, CancellationToken token)
    {
        await _provider.Books.AddAsync(book, token);

        await _provider.SaveAsync(token);
    }

    public async Task<DbBook?> GetAsync(Guid bookId, CancellationToken token)
    {
        return await _provider.Books
            .FirstOrDefaultAsync(u => u.Id == bookId, token);
    }

    public async Task DeleteAsync(DbBook book, CancellationToken token)
    {
        _provider.Books.Remove(book);

        await _provider.SaveAsync(token);
    }

    public DbSet<DbBook> Get() => _provider.Books;

    public async Task SaveAsync(CancellationToken token) => await _provider.SaveAsync(token);
}