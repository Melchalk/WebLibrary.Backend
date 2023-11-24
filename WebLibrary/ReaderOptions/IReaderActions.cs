using WebLibrary.ModelRequest;
using WebLibrary.ModelsResponses.ReaderResponses;

namespace WebLibrary.ReaderOptions;

public interface IReaderActions
{
    CreateReaderResponse Create(CreateReaderRequest request);

    GetReaderResponse Get(Guid id);

    UpdateReaderResponse Update(Guid id, CreateReaderRequest request);

    DeleteReaderResponse Delete(Guid id);
}