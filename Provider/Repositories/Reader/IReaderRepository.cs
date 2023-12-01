using DbModels;

namespace Provider.Repositories.Reader;

public interface IReaderRepository : IRepository<DbReader, Guid>
{
    Task AddAsync(DbReader reader);
}