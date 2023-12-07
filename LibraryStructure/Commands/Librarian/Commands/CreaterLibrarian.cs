using DbModels;
using FluentValidation.Results;
using LibraryStructure.Commands.Librarian.Interfaces;
using LibraryStructure.Validators.Librarian;
using Provider.Repositories.Librarian;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Mappers.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public class CreaterLibrarian : LibrarianActions, ICreaterLibrarian
{
    public CreaterLibrarian(ILibrarianRepository LibrarianRepository, ICreateLibrarianRequestValidator validator, ILibrarianMapper mapper)
        : base(LibrarianRepository, validator, mapper)
    {
    }

    public async Task<CreateLibrarianResponse> CreateAsync(CreateLibrarianRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        CreateLibrarianResponse LibrarianResponse = new();

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            LibrarianResponse.Errors = errors;

            return LibrarianResponse;
        }

        DbLibrarian Librarian = _mapper.Map(request);

        await _LibrarianRepository.AddAsync(Librarian);

        LibrarianResponse.Id = Librarian.Id;

        return LibrarianResponse;
    }
}