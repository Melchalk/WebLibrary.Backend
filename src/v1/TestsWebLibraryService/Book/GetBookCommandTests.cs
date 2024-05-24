using DbModels;
using Moq;
using Provider.Repositories.Book;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Commands;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators.Book;

namespace TestsWebLibraryService.Book;

public class GetBookCommandTests
{
    private Mock<ICreateBookRequestValidator> _createBookValidatorMock;
    private Mock<IBookRepository> _bookRepository;
    private Mock<IBookMapper> _bookMapper;

    private ReadBookCommand _command;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _createBookValidatorMock = new Mock<ICreateBookRequestValidator>();
        _bookRepository = new Mock<IBookRepository>();
        _bookMapper = new Mock<IBookMapper>();

        DbBook _dbBook = new()
        {
            Id = Guid.NewGuid(),
            Title = "Test",
            NumberPages = 1,
            YearPublishing = 1,
        };

        GetBookResponse _getBookResponse = new()
        {
            Id = Guid.NewGuid(),
            Title = "Test",
            NumberPages = 1,
            YearPublishing = 1,
        };

        _bookRepository
             .Setup(x => x.GetAsync(It.IsAny<Guid>()))
             .ReturnsAsync(_dbBook);

        _bookMapper
            .Setup(x => x.Map(It.IsAny<CreateBookRequest>()))
            .Returns(_dbBook);

        _bookMapper
           .Setup(x => x.Map(It.IsAny<DbBook>()))
           .Returns(_getBookResponse);

        _command = new ReadBookCommand(_bookRepository.Object, _createBookValidatorMock.Object, _bookMapper.Object);
    }

    [Test]
    public async Task ReadBookCommandReturnErrorNullWhenRequestIsOk()
    {
        var request = new GetBookRequest
        {
            Id = Guid.NewGuid()
        };

        var actualResult = await _command.GetAsync(request);

        Assert.That(actualResult.Error, Is.Null);
    }
}