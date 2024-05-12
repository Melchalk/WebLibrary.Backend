using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface ILibraryRepository
{
    Task AddAsync(DbLibrary entity, CancellationToken token);

    Task<DbLibrary?> GetAsync(Guid id, CancellationToken token);

    DbSet<DbLibrary> Get();

    Task DeleteAsync(DbLibrary entity, CancellationToken token);

    Task SaveAsync(CancellationToken token);
}
