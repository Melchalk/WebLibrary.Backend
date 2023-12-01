namespace ServiceModels.Responses.Library;

public class UpdateLibraryResponse
{
    public bool Result { get; set; }
    public List<string>? Errors { get; set; }
}
