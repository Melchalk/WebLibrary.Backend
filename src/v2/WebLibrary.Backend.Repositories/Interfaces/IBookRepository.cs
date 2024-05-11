using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface IBookRepository
{
    Task AddAsync(DbBook entity);

    Task<DbBook?> GetAsync(Guid id);

    Task UpdateAsync(DbBook entity);

    Task DeleteAsync(DbBook entity);
}
