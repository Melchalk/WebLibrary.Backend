using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Librarian.Interfaces;
using LibraryStructure.Validators.Librarian;
using Provider.Repositories.Librarian;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Mappers.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public class CreateLibrarianCommand : LibrarianActions, ICreaterLibrarian
{
    public CreateLibrarianCommand(ILibrarianRepository librarianRepository, ICreateLibrarianRequestValidator validator, ILibrarianMapper mapper)
        : base(librarianRepository, validator, mapper)
    {
    }

    public async Task<CreateLibrarianResponse> CreateAsync(CreateLibrarianRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        CreateLibrarianResponse librarianResponse = new();

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            librarianResponse.Errors = errors;

            return librarianResponse;
        }

        DbLibrarian librarian = _mapper.Map(request);

        await _librarianRepository.AddAsync(librarian);

        librarianResponse.Id = librarian.Id;

        return librarianResponse;
    }
}