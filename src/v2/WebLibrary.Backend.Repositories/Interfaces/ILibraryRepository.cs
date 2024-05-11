using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface ILibraryRepository
{
    Task AddAsync(DbLibrary entity);

    Task<DbLibrary?> GetAsync(Guid id);

    Task UpdateAsync(DbLibrary entity);

    Task DeleteAsync(DbLibrary entity);
}
