using DbModels;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Mappers.Issue;

namespace WebLibrary.Mappers.Reader;

public class ReaderMapper : IReaderMapper
{
    private readonly IIssueMapper _issueMapper;

    public ReaderMapper(IIssueMapper issueMapper)
    {
        _issueMapper = issueMapper;
    }

    public DbReader Map(CreateReaderRequest readerRequest)
    {
        DbReader reader = new()
        {
            Id = Guid.NewGuid(),
            Fullname = readerRequest.Fullname,
            Telephone = readerRequest.Telephone,
            RegistrationAddress = readerRequest.RegistrationAddress,
            Age = readerRequest.Age,
            CanTakeBooks = readerRequest.CanTakeBooks,
        };

        return reader;
    }

    public GetReaderResponse Map(DbReader reader)
    {
        GetReaderResponse readerResponse = new()
        {
            Fullname = reader.Fullname,
            Telephone = reader.Telephone,
            RegistrationAddress = reader.RegistrationAddress,
            Age = reader.Age,
            Issue = _issueMapper.Map(reader.Issue),
            CanTakeBooks = reader.CanTakeBooks
        };

        return readerResponse;
    }
}