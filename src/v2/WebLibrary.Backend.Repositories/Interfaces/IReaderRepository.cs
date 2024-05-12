using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface IReaderRepository
{
    Task AddAsync(DbReader entity, CancellationToken token);

    Task<DbReader?> GetAsync(Guid id, CancellationToken token);

    DbSet<DbReader> Get();

    Task DeleteAsync(DbReader entity, CancellationToken token);

    Task SaveAsync(CancellationToken token);
}