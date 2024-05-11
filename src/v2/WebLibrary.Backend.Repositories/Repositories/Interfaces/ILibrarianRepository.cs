using DbModels;

namespace WebLibrary.Backend.Provider.Repositories.Interfaces;

public interface ILibrarianRepository : IRepository<DbLibrarian, Guid>
{
    Task AddAsync(DbLibrarian librarian);
}
