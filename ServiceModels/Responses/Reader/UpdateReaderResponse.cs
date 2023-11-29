namespace ServiceModels.Responses.Reader;

public class UpdateReaderResponse
{
    public bool Result { get; set; }
    public List<string>? Errors { get; set; }
}
