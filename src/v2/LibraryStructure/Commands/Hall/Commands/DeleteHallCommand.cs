using DbModels;
using LibraryStructure.Commands.Hall.Interfaces;
using LibraryStructure.Validators.Hall;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Mappers.Hall;

namespace LibraryStructure.Commands.Hall.Commands;

public class DeleteHallCommand : HallActions, IDeleteHallCommand
{
    public DeleteHallCommand(IHallRepository hallRepository, ICreateHallRequestValidator validator, IHallMapper mapper)
        : base(hallRepository, validator, mapper)
    {
    }

    public async Task<DeleteHallResponse> DeleteAsync(DeleteHallRequest request)
    {
        DeleteHallResponse hallResponse = new();

        DbHall? hall = await _hallRepository.GetAsync((request.LibraryId, request.No));

        if (hall is null)
        {
            hallResponse.Error = NOT_FOUND;

            return hallResponse;
        }

        await _hallRepository.DeleteAsync(hall);

        hallResponse.Result = true;

        return hallResponse;
    }
}