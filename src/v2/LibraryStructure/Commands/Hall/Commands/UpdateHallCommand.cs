using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Hall.Interfaces;
using LibraryStructure.Validators.Hall;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Mappers.Hall;

namespace LibraryStructure.Commands.Hall.Commands;

public class UpdateHallCommand : HallActions, IUpdateHallCommand
{
    public UpdateHallCommand(IHallRepository hallRepository, ICreateHallRequestValidator validator, IHallMapper mapper)
        : base(hallRepository, validator, mapper)
    {
    }

    public async Task<UpdateHallResponse> UpdateAsync(UpdateHallRequest updateRequest)
    {
        CreateHallRequest request = updateRequest.CreateHallRequest;

        Guid libraryId = updateRequest.CreateHallRequest.LibraryId;
        int number = updateRequest.CreateHallRequest.No;

        UpdateHallResponse hallResponse = new();

        if (await _hallRepository.GetAsync((libraryId, number)) is null)
        {
            hallResponse.Errors = new()
            {
                NOT_FOUND
            };

            return hallResponse;
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            hallResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return hallResponse;
        }

        DbHall hall = _mapper.Map(request);
        hall.LibraryId = libraryId;
        hall.No = number;

        await _hallRepository.UpdateAsync(hall);

        hallResponse.Result = true;

        return hallResponse;
    }
}