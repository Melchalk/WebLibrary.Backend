using LibraryStructure.Validators.Librarian;
using Provider.Repositories.Librarian;
using WebLibrary.Mappers.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public abstract class LibrarianActions
{
    protected const string NOT_FOUND = "ID is not found";

    protected readonly ILibrarianRepository _librarianRepository;

    protected readonly ICreateLibrarianRequestValidator _validator;
    protected readonly ILibrarianMapper _mapper;

    public LibrarianActions(
        ILibrarianRepository librarianRepository,
        ICreateLibrarianRequestValidator validator,
        ILibrarianMapper mapper)
    {
        _librarianRepository = librarianRepository;
        _validator = validator;
        _mapper = mapper;
    }
}