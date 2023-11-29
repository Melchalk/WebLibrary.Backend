using Provider.Repositories.Book;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Book.Commands;

public abstract class BookActions
{
    protected const string NOT_FOUND = "ID is not found";

    protected readonly IBookRepository _bookRepository;

    protected readonly ICreateBookRequestValidator _validator;
    protected readonly IBookMapper _mapper;

    public BookActions(
        IBookRepository bookRepository,
        ICreateBookRequestValidator validator,
        IBookMapper mapper)
    {
        _bookRepository = bookRepository;
        _validator = validator;
        _mapper = mapper;
    }
}