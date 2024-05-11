using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface IHallRepository
{
    Task AddAsync(DbHall entity);

    Task<DbHall?> GetAsync(Guid libraryId, uint number);

    DbSet<DbHall> Get();

    Task UpdateAsync(DbHall entity);

    Task DeleteAsync(DbHall entity);
}
