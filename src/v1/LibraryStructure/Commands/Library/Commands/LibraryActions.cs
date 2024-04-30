using LibraryStructure.Validators.Library;
using Provider.Repositories.Library;
using WebLibrary.Mappers.Library;

namespace LibraryStructure.Commands.Library.Commands;

public abstract class LibraryActions
{
    protected const string NOT_FOUND = "ID is not found";

    protected readonly ILibraryRepository _libraryRepository;

    protected readonly ICreateLibraryRequestValidator _validator;
    protected readonly ILibraryMapper _mapper;

    public LibraryActions(
        ILibraryRepository libraryRepository,
        ICreateLibraryRequestValidator validator,
        ILibraryMapper mapper)
    {
        _libraryRepository = libraryRepository;
        _validator = validator;
        _mapper = mapper;
    }
}