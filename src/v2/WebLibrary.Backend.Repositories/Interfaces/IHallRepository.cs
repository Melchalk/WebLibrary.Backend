using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface IHallRepository
{
    Task AddAsync(DbHall entity);

    Task<DbHall?> GetAsync(Guid libraryId, uint number);

    Task UpdateAsync(DbHall entity);

    Task DeleteAsync(DbHall entity);
}
