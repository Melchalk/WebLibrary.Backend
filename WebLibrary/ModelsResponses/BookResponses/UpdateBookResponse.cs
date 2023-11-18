using WebLibrary.ModelRequest;

namespace WebLibrary.ModelsResponses.BookResponses;

public class UpdateBookResponse
{
    public bool Result { get; set; }
    public List<string>? Errors { get; set; }
}
