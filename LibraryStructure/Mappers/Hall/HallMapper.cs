using DbModels;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace WebLibrary.Mappers.Hall;

public class HallMapper : IHallMapper
{
    public DbHall Map(CreateHallRequest hallRequest)
    {
        DbHall hall = new()
        {
            LibraryId = hallRequest.LibraryId,
            No = hallRequest.No,
            Title = hallRequest.Title,
            Thematics = hallRequest.Thematics,
        };

        return hall;
    }

    public GetHallResponse Map(DbHall hall)
    {
        GetHallResponse hallResponse = new()
        {
            LibraryId = hall.LibraryId,
            No = hall.No,
            Title = hall.Title,
            Thematics = hall.Thematics,
        };

        return hallResponse;
    }
}