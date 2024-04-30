using DbModels;

namespace Provider.Repositories.Book;

public interface IBookRepository : IRepository<DbBook, Guid>
{
    Task AddAsync(DbBook book);
}
