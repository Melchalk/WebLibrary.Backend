using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface IBookRepository
{
    Task AddAsync(DbBook entity, CancellationToken token);

    Task<DbBook?> GetAsync(Guid id, CancellationToken token);

    DbSet<DbBook> Get();

    Task DeleteAsync(DbBook entity, CancellationToken token);

    Task SaveAsync(CancellationToken token);
}
