using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Library.Interfaces;
using LibraryStructure.Validators.Library;
using Provider.Repositories.Library;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;
using WebLibrary.Mappers.Library;

namespace LibraryStructure.Commands.Library.Commands;

public class CreaterLibrary : LibraryActions, ICreaterLibrary
{
    public CreaterLibrary(ILibraryRepository LibraryRepository, ICreateLibraryRequestValidator validator, ILibraryMapper mapper)
        : base(LibraryRepository, validator, mapper)
    {
    }

    public async Task<CreateLibraryResponse> CreateAsync(CreateLibraryRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        CreateLibraryResponse LibraryResponse = new();

        if (!result.IsValid)
        {
            LibraryResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return LibraryResponse;
        }

        DbLibrary Library = _mapper.Map(request);

        await _LibraryRepository.AddAsync(Library);

        LibraryResponse.Id = Library.Id;

        return LibraryResponse;
    }
}