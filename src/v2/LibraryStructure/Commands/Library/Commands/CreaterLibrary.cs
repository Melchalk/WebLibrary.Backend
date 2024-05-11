using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Library.Interfaces;
using LibraryStructure.Validators.Library;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Mappers.Library;

namespace LibraryStructure.Commands.Library.Commands;

public class CreaterLibrary : LibraryActions, ICreaterLibrary
{
    public CreaterLibrary(ILibraryRepository libraryRepository, ICreateLibraryRequestValidator validator, ILibraryMapper mapper)
        : base(libraryRepository, validator, mapper)
    {
    }

    public async Task<CreateLibraryResponse> CreateAsync(CreateLibraryRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        CreateLibraryResponse libraryResponse = new();

        if (!result.IsValid)
        {
            libraryResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return libraryResponse;
        }

        DbLibrary library = _mapper.Map(request);

        await _libraryRepository.AddAsync(library);

        libraryResponse.Id = library.Id;

        return libraryResponse;
    }
}