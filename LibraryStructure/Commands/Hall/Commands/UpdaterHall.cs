using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Hall.Interfaces;
using LibraryStructure.Validators.Hall;
using Provider.Repositories.Hall;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;
using WebLibrary.Mappers.Hall;

namespace LibraryStructure.Commands.Hall.Commands;

public class UpdaterHall : HallActions, IUpdaterHall
{
    public UpdaterHall(IHallRepository HallRepository, ICreateHallRequestValidator validator, IHallMapper mapper)
    : base(HallRepository, validator, mapper)
    {
    }

    public async Task<UpdateHallResponse> UpdateAsync(UpdateHallRequest updateRequest)
    {
        CreateHallRequest request = updateRequest.CreateHallRequest;

        Guid libraryId = updateRequest.CreateHallRequest.LibraryId;
        int number = updateRequest.CreateHallRequest.No;

        UpdateHallResponse HallResponse = new();

        if (await _HallRepository.GetAsync((libraryId, number)) is null)
        {
            HallResponse.Errors = new()
            {
                NOT_FOUND
            };

            return HallResponse;
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            HallResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return HallResponse;
        }

        DbHall Hall = _mapper.Map(request);
        Hall.LibraryId = libraryId;
        Hall.No = number;

        await _HallRepository.UpdateAsync(Hall);

        HallResponse.Result = true;

        return HallResponse;
    }
}