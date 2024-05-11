using DbModels;

namespace WebLibrary.Backend.Provider.Repositories.Interfaces;

public interface ILibraryRepository : IRepository<DbLibrary, Guid>
{
    Task AddAsync(DbLibrary library);
}
