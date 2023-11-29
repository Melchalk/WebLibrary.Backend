using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Librarian.Interfaces;
using LibraryStructure.Validators.Librarian;
using Provider.Repositories.Librarian;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Mappers.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public class UpdaterLibrarian : LibrarianActions, IUpdaterLibrarian
{
    public UpdaterLibrarian(ILibrarianRepository LibrarianRepository, ICreateLibrarianRequestValidator validator, ILibrarianMapper mapper)
    : base(LibrarianRepository, validator, mapper)
    {
    }

    public async Task<UpdateLibrarianResponse> UpdateAsync(UpdateLibrarianRequest updateRequest)
    {
        CreateLibrarianRequest request = updateRequest.CreateLibrarianRequest;
        Guid id = updateRequest.Id;

        UpdateLibrarianResponse LibrarianResponse = new();

        if (await _LibrarianRepository.GetAsync(id) is null)
        {
            LibrarianResponse.Errors = new()
            {
                NOT_FOUND
            };

            return LibrarianResponse;
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            LibrarianResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return LibrarianResponse;
        }

        DbLibrarian Librarian = _mapper.Map(request);
        Librarian.Id = id;

        await _LibrarianRepository.UpdateAsync(Librarian);

        LibrarianResponse.Result = true;

        return LibrarianResponse;
    }
}