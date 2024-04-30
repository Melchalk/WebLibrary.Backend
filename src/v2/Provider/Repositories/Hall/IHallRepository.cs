using DbModels;

namespace Provider.Repositories.Hall;

public interface IHallRepository : IRepository<DbHall, (Guid, int)>
{
    Task AddAsync(DbHall hall);
}
