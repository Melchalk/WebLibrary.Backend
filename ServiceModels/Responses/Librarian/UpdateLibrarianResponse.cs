namespace ServiceModels.Responses.Librarian;

public class UpdateLibrarianResponse
{
    public bool Result { get; set; }
    public List<string>? Errors { get; set; }
}