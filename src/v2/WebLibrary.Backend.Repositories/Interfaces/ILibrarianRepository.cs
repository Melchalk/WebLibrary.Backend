using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface ILibrarianRepository
{
    Task AddAsync(DbLibrarian entity, CancellationToken token);

    Task<DbLibrarian?> GetAsync(Guid id, CancellationToken token);

    DbSet<DbLibrarian> Get();

    Task DeleteAsync(DbLibrarian entity, CancellationToken token);

    Task SaveAsync(CancellationToken token);
}
