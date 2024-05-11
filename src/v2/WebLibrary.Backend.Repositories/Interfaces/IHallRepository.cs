using DbModels;

namespace WebLibrary.Backend.Provider.Repositories.Interfaces;

public interface IHallRepository : IRepository<DbHall, (Guid, int)>
{
    Task AddAsync(DbHall hall);
}
