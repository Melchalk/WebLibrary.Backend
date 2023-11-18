using WebLibrary.ModelRequest;

namespace WebLibrary.ModelsResponses.BookResponses;

public class GetBookResponse
{
    public BookRequest? BookRequest { get; set; }
    public string? Error { get; set; }
}
