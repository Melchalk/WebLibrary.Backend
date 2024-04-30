using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Hall.Interfaces;
using LibraryStructure.Validators.Hall;
using Provider.Repositories.Hall;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;
using WebLibrary.Mappers.Hall;

namespace LibraryStructure.Commands.Hall.Commands;

public class CreateHallCommand : HallActions, ICreateHallCommand
{
    public CreateHallCommand(IHallRepository hallRepository, ICreateHallRequestValidator validator, IHallMapper mapper)
        : base(hallRepository, validator, mapper)
    {
    }

    public async Task<CreateHallResponse> CreateAsync(CreateHallRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        CreateHallResponse hallResponse = new();

        if (!result.IsValid)
        {
            hallResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return hallResponse;
        }

        DbHall hall = _mapper.Map(request);

        await _hallRepository.AddAsync(hall);

        hallResponse.LibraryId = hall.LibraryId;
        hallResponse.No = hall.No;

        return hallResponse;
    }
}