using DbModels;

namespace Provider.Repositories.Library;

public interface ILibraryRepository : IRepository<DbLibrary, Guid>
{
    Task AddAsync(DbLibrary library);
}
