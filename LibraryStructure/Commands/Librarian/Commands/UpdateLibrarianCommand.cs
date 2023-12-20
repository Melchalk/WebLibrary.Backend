using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Librarian.Interfaces;
using LibraryStructure.Validators.Librarian;
using Provider.Repositories.Librarian;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Mappers.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public class UpdateLibrarianCommand : LibrarianActions, IUpdaterLibrarian
{
    public UpdateLibrarianCommand(ILibrarianRepository LibrarianRepository, ICreateLibrarianRequestValidator validator, ILibrarianMapper mapper)
        : base(LibrarianRepository, validator, mapper)
    {
    }

    public async Task<UpdateLibrarianResponse> UpdateAsync(UpdateLibrarianRequest updateRequest)
    {
        CreateLibrarianRequest request = updateRequest.CreateLibrarianRequest;
        Guid id = updateRequest.Id;

        UpdateLibrarianResponse librarianResponse = new();

        if (await _librarianRepository.GetAsync(id) is null)
        {
            librarianResponse.Errors = new()
            {
                NOT_FOUND
            };

            return librarianResponse;
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            librarianResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return librarianResponse;
        }

        DbLibrarian Librarian = _mapper.Map(request);
        Librarian.Id = id;

        await _librarianRepository.UpdateAsync(Librarian);

        librarianResponse.Result = true;

        return librarianResponse;
    }
}