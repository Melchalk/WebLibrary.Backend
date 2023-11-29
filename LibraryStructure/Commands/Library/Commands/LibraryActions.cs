using LibraryStructure.Validators.Library;
using Provider.Repositories.Library;

namespace LibraryStructure.Commands.Library.Commands;

public abstract class LibraryActions
{
    protected const string NOT_FOUND = "ID is not found";

    protected readonly ILibraryRepository _LibraryRepository;

    protected readonly ICreateLibraryRequestValidator _validator;
    protected readonly ILibraryMapper _mapper;

    public LibraryActions(
        ILibraryRepository LibraryRepository,
        ICreateLibraryRequestValidator validator,
        ILibraryMapper mapper)
    {
        _LibraryRepository = LibraryRepository;
        _validator = validator;
        _mapper = mapper;
    }
}