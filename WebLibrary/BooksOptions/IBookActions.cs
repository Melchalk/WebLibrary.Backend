using WebLibrary.ModelRequest;
using WebLibrary.ModelsResponses.BookResponses;

namespace WebLibrary.BooksOptions;

public interface IBookActions
{
    CreateBookResponse Create(BookRequest request);

    GetBookResponse Get(Guid id);

    UpdateBookResponse Update(Guid id, BookRequest request);

    DeleteBookResponse Delete(Guid id);
}