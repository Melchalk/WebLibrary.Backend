using WebLibrary.ModelRequest;

namespace WebLibrary.ModelsResponses.ReaderResponses;

public class UpdateReaderResponse
{
    public bool Result { get; set; }
    public List<string>? Errors { get; set; }
}
