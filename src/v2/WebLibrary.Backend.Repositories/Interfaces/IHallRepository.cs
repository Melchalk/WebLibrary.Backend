using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface IHallRepository
{
    Task AddAsync(DbHall entity, CancellationToken token);

    Task<DbHall?> GetAsync(int libraryNumber, uint number, CancellationToken token);

    DbSet<DbHall> Get();

    Task DeleteAsync(DbHall entity, CancellationToken token);

    Task SaveAsync(CancellationToken token);
}
