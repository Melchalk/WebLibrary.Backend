using DbModels;

namespace WebLibrary.Backend.Provider.Repositories.Interfaces;

public interface IBookRepository : IRepository<DbBook, Guid>
{
    Task AddAsync(DbBook book);
}
