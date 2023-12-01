namespace ServiceModels.Requests.Library;

public class UpdateLibraryRequest
{
    public Guid Id { get; set; }
    public CreateLibraryRequest CreateLibraryRequest { get; set; }
}
