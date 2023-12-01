namespace ServiceModels.Responses.Reader;

public class CreateReaderResponse
{
    public Guid? Id { get; set; }

    public List<string>? Errors { get; set; }
}
