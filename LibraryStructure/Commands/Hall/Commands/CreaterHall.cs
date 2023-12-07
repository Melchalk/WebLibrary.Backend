using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Hall.Interfaces;
using LibraryStructure.Validators.Hall;
using Provider.Repositories.Hall;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;
using WebLibrary.Mappers.Hall;

namespace LibraryStructure.Commands.Hall.Commands;

public class CreaterHall : HallActions, ICreaterHall
{
    public CreaterHall(IHallRepository HallRepository, ICreateHallRequestValidator validator, IHallMapper mapper)
        : base(HallRepository, validator, mapper)
    {
    }

    public async Task<CreateHallResponse> CreateAsync(CreateHallRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        CreateHallResponse HallResponse = new();

        if (!result.IsValid)
        {
            HallResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return HallResponse;
        }

        DbHall Hall = _mapper.Map(request);

        await _HallRepository.AddAsync(Hall);

        HallResponse.LibraryId = Hall.LibraryId;
        HallResponse.No = Hall.No;

        return HallResponse;
    }
}