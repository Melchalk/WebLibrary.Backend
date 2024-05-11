using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Library.Interfaces;
using LibraryStructure.Validators.Library;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Mappers.Library;

namespace LibraryStructure.Commands.Library.Commands;

public class UpdaterLibrary : LibraryActions, IUpdaterLibrary
{
    public UpdaterLibrary(ILibraryRepository libraryRepository, ICreateLibraryRequestValidator validator, ILibraryMapper mapper)
        : base(libraryRepository, validator, mapper)
    {
    }

    public async Task<UpdateLibraryResponse> UpdateAsync(UpdateLibraryRequest updateRequest)
    {
        CreateLibraryRequest request = updateRequest.CreateLibraryRequest;
        Guid id = updateRequest.Id;

        UpdateLibraryResponse libraryResponse = new();

        if (await _libraryRepository.GetAsync(id) is null)
        {
            libraryResponse.Errors = new()
            {
                NOT_FOUND
            };

            return libraryResponse;
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            libraryResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return libraryResponse;
        }

        DbLibrary library = _mapper.Map(request);
        library.Id = id;

        await _libraryRepository.UpdateAsync(library);

        libraryResponse.Result = true;

        return libraryResponse;
    }
}