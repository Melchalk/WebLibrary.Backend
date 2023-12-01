using DbModels;
using LibraryStructure.Commands.Hall.Interfaces;
using LibraryStructure.Validators.Hall;
using Provider.Repositories.Hall;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;
using WebLibrary.Mappers.Hall;

namespace LibraryStructure.Commands.Hall.Commands;

public class DeleterHall : HallActions, IDeleterHall
{
    public DeleterHall(IHallRepository HallRepository, ICreateHallRequestValidator validator, IHallMapper mapper)
        : base(HallRepository, validator, mapper)
    {
    }

    public async Task<DeleteHallResponse> DeleteAsync(DeleteHallRequest request)
    {
        DeleteHallResponse HallResponse = new();

        DbHall? Hall = await _HallRepository.GetAsync((request.LibraryId, request.No));

        if (Hall is null)
        {
            HallResponse.Error = NOT_FOUND;

            return HallResponse;
        }

        await _HallRepository.DeleteAsync(Hall);

        HallResponse.Result = true;

        return HallResponse;
    }
}
