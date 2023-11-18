using WebLibrary.ModelRequest;

namespace WebLibrary.ModelsResponses.ReaderResponses;

public class GetReaderResponse
{
    public ReaderRequest? ReaderRequest { get; set; }
    public string? Error { get; set; }
}
