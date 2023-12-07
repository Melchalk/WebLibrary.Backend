namespace ServiceModels.Responses.Librarian;

public class CreateLibrarianResponse
{
    public Guid? Id { get; set; }

    public List<string>? Errors { get; set; }
}