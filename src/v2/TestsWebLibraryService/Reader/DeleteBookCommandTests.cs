using DbModels;
using Moq;
using ServiceModels.Requests.Reader;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Reader.Commands;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators.Reader;

namespace TestsWebLibraryService.Reader;

internal class DeleteReaderCommandTests
{
    private Mock<ICreateReaderRequestValidator> _createReaderValidatorMock;
    private Mock<IReaderRepository> _readerRepository;
    private Mock<IReaderMapper> _readerMapper;

    private DeleteReaderCommand _command;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _createReaderValidatorMock = new Mock<ICreateReaderRequestValidator>();
        _readerRepository = new Mock<IReaderRepository>();
        _readerMapper = new Mock<IReaderMapper>();

        DbReader _dbReader = new()
        {
            Id = Guid.NewGuid(),
            Fullname = "Test",
            Phone = "Phone",
            RegistrationAddress = "Test",
            Age = 2020,
        };

        _readerRepository
             .Setup(x => x.GetAsync(It.IsAny<Guid>()))
             .ReturnsAsync(_dbReader);

        _readerRepository
             .Setup(x => x.DeleteAsync(It.IsAny<DbReader>()));

        _readerMapper
            .Setup(x => x.Map(It.IsAny<CreateReaderRequest>()))
            .Returns(_dbReader);

        _command = new DeleteReaderCommand(_readerRepository.Object, _createReaderValidatorMock.Object, _readerMapper.Object);
    }

    [Test]
    public async Task ReadReaderCommandReturnErrorNullWhenRequestIsOk()
    {
        var request = new DeleteReaderRequest
        {
            Id = Guid.NewGuid()
        };

        var actualResult = await _command.DeleteAsync(request);

        Assert.That(actualResult.Error, Is.Null);
    }
}