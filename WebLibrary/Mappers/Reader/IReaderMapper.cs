using DbModels;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;

namespace WebLibrary.Mappers.Reader;

public interface IReaderMapper
{
    DbReader Map(ReaderRequest readerRequest);

    ReaderResponse Map(DbReader dbReader);
}
