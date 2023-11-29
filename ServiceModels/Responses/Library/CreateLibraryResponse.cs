namespace ServiceModels.Responses.Library;

public class CreateLibraryResponse
{
    public Guid? Id { get; set; }

    public List<string>? Errors { get; set; }
}
