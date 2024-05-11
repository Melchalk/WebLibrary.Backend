using Moq;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Reader;
using WebLibrary.Backend.Models.DTO.Responses.Reader;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Reader.Commands;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators.Reader;

namespace TestsWebLibraryService.Reader;

public class GetReaderCommandTests
{
    private Mock<ICreateReaderRequestValidator> _createReaderValidatorMock;
    private Mock<IReaderRepository> _readerRepository;
    private Mock<IReaderMapper> _readerMapper;

    private ReadReaderCommand _command;

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

        GetReaderResponse _getReaderResponse = new()
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

        _readerMapper
            .Setup(x => x.Map(It.IsAny<CreateReaderRequest>()))
            .Returns(_dbReader);

        _readerMapper
           .Setup(x => x.Map(It.IsAny<DbReader>()))
           .Returns(_getReaderResponse);

        _command = new ReadReaderCommand(_readerRepository.Object, _createReaderValidatorMock.Object, _readerMapper.Object);
    }

    [Test]
    public async Task ReadReaderCommandReturnErrorNullWhenRequestIsOk()
    {
        var request = new GetReaderRequest
        {
            Id = Guid.NewGuid()
        };

        var actualResult = await _command.GetAsync(request);

        Assert.That(actualResult.Error, Is.Null);
    }
}