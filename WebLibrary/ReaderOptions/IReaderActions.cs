using WebLibrary.ModelRequest;
using WebLibrary.ModelsResponses.ReaderResponses;

namespace WebLibrary.ReaderOptions;

public interface IReaderActions
{
    CreateReaderResponse Create(ReaderRequest request);

    GetReaderResponse Get(Guid id);

    UpdateReaderResponse Update(Guid id, ReaderRequest request);

    DeleteReaderResponse Delete(Guid id);
}