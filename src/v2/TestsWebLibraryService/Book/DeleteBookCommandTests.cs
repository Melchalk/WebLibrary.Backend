using DbModels;
using Moq;
using ServiceModels.Requests.Book;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Book.Commands;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators.Book;

namespace TestsWebLibraryService.Book;

internal class DeleteBookCommandTests
{
    private Mock<ICreateBookRequestValidator> _createBookValidatorMock;
    private Mock<IBookRepository> _bookRepository;
    private Mock<IBookMapper> _bookMapper;

    private DeleteBookCommand _command;

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

        _bookRepository
             .Setup(x => x.GetAsync(It.IsAny<Guid>()))
             .ReturnsAsync(_dbBook);

        _bookRepository
             .Setup(x => x.DeleteAsync(It.IsAny<DbBook>()));

        _bookMapper
            .Setup(x => x.Map(It.IsAny<CreateBookRequest>()))
            .Returns(_dbBook);

        _command = new DeleteBookCommand(_bookRepository.Object, _createBookValidatorMock.Object, _bookMapper.Object);
    }

    [Test]
    public async Task ReadBookCommandReturnErrorNullWhenRequestIsOk()
    {
        var request = new DeleteBookRequest
        {
            Id = Guid.NewGuid()
        };

        var actualResult = await _command.DeleteAsync(request);

        Assert.That(actualResult.Error, Is.Null);
    }
}