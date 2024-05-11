using DbModels;

namespace WebLibrary.Backend.Provider.Repositories.Interfaces;

public interface IReaderRepository : IRepository<DbReader, Guid>
{
    Task AddAsync(DbReader reader);
}