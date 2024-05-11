using DbModels;

namespace WebLibrary.Backend.Provider.Repositories.Interfaces;

public interface ILibrarianRepository
{
    Task AddAsync(DbLibrarian entity);

    Task<DbLibrarian?> GetAsync(Guid id);

    Task UpdateAsync(DbLibrarian entity);

    Task DeleteAsync(DbLibrarian entity);
}
