using LibraryStructure.Validators.Librarian;
using Provider.Repositories.Librarian;
using WebLibrary.Mappers.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public abstract class LibrarianActions
{
    protected const string NOT_FOUND = "ID is not found";

    protected readonly ILibrarianRepository _LibrarianRepository;

    protected readonly ICreateLibrarianRequestValidator _validator;
    protected readonly ILibrarianMapper _mapper;

    public LibrarianActions(
        ILibrarianRepository LibrarianRepository,
        ICreateLibrarianRequestValidator validator,
        ILibrarianMapper mapper)
    {
        _LibrarianRepository = LibrarianRepository;
        _validator = validator;
        _mapper = mapper;
    }
}