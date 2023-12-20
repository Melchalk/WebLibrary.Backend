using DbModels;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace WebLibrary.Mappers.Hall;

public interface IHallMapper
{
    DbHall Map(CreateHallRequest hallRequest);

    GetHallResponse Map(DbHall dbHall);
}