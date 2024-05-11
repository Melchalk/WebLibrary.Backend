using DbModels;

namespace WebLibrary.Backend.Provider.Repositories.Interfaces;

public interface IReaderRepository
{
    Task AddAsync(DbReader entity);

    Task<DbReader?> GetAsync(Guid id);

    Task UpdateAsync(DbReader entity);

    Task DeleteAsync(DbReader entity);
}