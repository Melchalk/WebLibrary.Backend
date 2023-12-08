using DbModels;
using LibraryStructure.Commands.Hall.Interfaces;
using LibraryStructure.Validators.Hall;
using Provider.Repositories.Hall;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;
using WebLibrary.Mappers.Hall;

namespace LibraryStructure.Commands.Hall.Commands;

public class ReadHallCommand : HallActions, IReadHallCommand
{
    public ReadHallCommand(IHallRepository HallRepository, ICreateHallRequestValidator validator, IHallMapper mapper)
        : base(HallRepository, validator, mapper)
    {
    }

    public GetHallsResponse Get()
    {
        List<DbHall> dbHalls = _HallRepository.Get().ToList();

        GetHallsResponse HallResponse = new()
        {
            HallResponses = dbHalls.Select(u => _mapper.Map(u)).ToList()
        };

        return HallResponse;
    }

    public async Task<GetHallResponse> GetAsync(GetHallRequest request)
    {
        DbHall? Hall = await _HallRepository.GetAsync((request.LibraryId, request.No));

        if (Hall is null)
        {
            GetHallResponse HallResponse = new()
            {
                Error = NOT_FOUND
            };

            return HallResponse;
        }

        return _mapper.Map(Hall);
    }
}