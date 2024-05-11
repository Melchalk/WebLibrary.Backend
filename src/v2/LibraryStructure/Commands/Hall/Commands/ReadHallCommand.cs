using DbModels;
using LibraryStructure.Commands.Hall.Interfaces;
using LibraryStructure.Validators.Hall;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Mappers.Hall;

namespace LibraryStructure.Commands.Hall.Commands;

public class ReadHallCommand : HallActions, IReadHallCommand
{
    public ReadHallCommand(IHallRepository hallRepository, ICreateHallRequestValidator validator, IHallMapper mapper)
        : base(hallRepository, validator, mapper)
    {
    }

    public GetHallsResponse Get()
    {
        List<DbHall> dbhalls = _hallRepository.Get().ToList();

        GetHallsResponse hallResponse = new()
        {
            HallResponses = dbhalls.Select(u => _mapper.Map(u)).ToList()
        };

        return hallResponse;
    }

    public async Task<GetHallResponse> GetAsync(GetHallRequest request)
    {
        DbHall? hall = await _hallRepository.GetAsync((request.LibraryId, request.No));

        if (hall is null)
        {
            GetHallResponse hallResponse = new()
            {
                Error = NOT_FOUND
            };

            return hallResponse;
        }

        return _mapper.Map(hall);
    }
}