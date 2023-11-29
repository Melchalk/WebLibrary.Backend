using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Library.Interfaces;
using LibraryStructure.Validators.Library;
using Provider.Repositories.Library;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace LibraryStructure.Commands.Library.Commands;

public class UpdaterLibrary : LibraryActions, IUpdaterLibrary
{
    public UpdaterLibrary(ILibraryRepository LibraryRepository, ICreateLibraryRequestValidator validator, ILibraryMapper mapper)
    : base(LibraryRepository, validator, mapper)
    {
    }

    public async Task<UpdateLibraryResponse> UpdateAsync(UpdateLibraryRequest updateRequest)
    {
        CreateLibraryRequest request = updateRequest.CreateLibraryRequest;
        Guid id = updateRequest.Id;

        UpdateLibraryResponse LibraryResponse = new();

        if (await _LibraryRepository.GetAsync(id) is null)
        {
            LibraryResponse.Errors = new()
            {
                NOT_FOUND
            };

            return LibraryResponse;
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            LibraryResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return LibraryResponse;
        }

        DbLibrary Library = _mapper.Map(request);
        Library.Id = id;

        await _LibraryRepository.UpdateAsync(Library);

        LibraryResponse.Result = true;

        return LibraryResponse;
    }
}