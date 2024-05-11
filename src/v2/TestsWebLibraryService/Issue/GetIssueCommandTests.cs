using Moq;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Issue;
using WebLibrary.Backend.Models.DTO.Responses.Issue;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Issue.Commands;
using WebLibrary.Mappers.Issue;
using WebLibrary.Validators.Issue;

namespace TestsWebLibraryService.Issue;

public class GetIssueCommandTests
{
    private Mock<ICreateIssueRequestValidator> _createIssueValidatorMock;
    private Mock<IIssueRepository> _issueRepository;
    private Mock<IIssueMapper> _issueMapper;

    private ReadIssueCommand _command;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _createIssueValidatorMock = new Mock<ICreateIssueRequestValidator>();
        _issueRepository = new Mock<IIssueRepository>();
        _issueMapper = new Mock<IIssueMapper>();

        DbIssue _dbIssue = new()
        {
            Id = Guid.NewGuid(),
            ReaderId = Guid.NewGuid(),
            DateIssue = DateTime.Today,
            Period = 1,
        };

        GetIssueResponse _getIssueResponse = new()
        {
            Id = Guid.NewGuid(),
            ReaderId = Guid.NewGuid(),
            DateIssue = DateTime.Today,
            Period = 1,
        };

        _issueRepository
             .Setup(x => x.GetAsync(It.IsAny<Guid>()))
             .ReturnsAsync(_dbIssue);

        _issueMapper
            .Setup(x => x.Map(It.IsAny<CreateIssueRequest>()))
            .Returns(_dbIssue);

        _issueMapper
           .Setup(x => x.Map(It.IsAny<DbIssue>()))
           .Returns(_getIssueResponse);

        _command = new ReadIssueCommand(_issueRepository.Object, _createIssueValidatorMock.Object, _issueMapper.Object);
    }

    [Test]
    public async Task ReadIssueCommandReturnErrorNullWhenRequestIsOk()
    {
        var request = new GetIssueRequest
        {
            Id = Guid.NewGuid()
        };

        var actualResult = await _command.GetAsync(request);

        Assert.That(actualResult.Error, Is.Null);
    }
}