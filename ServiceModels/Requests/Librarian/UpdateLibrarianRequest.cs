namespace ServiceModels.Requests.Librarian;

public class UpdateLibrarianRequest
{
    public Guid Id { get; set; }
    public CreateLibrarianRequest CreateLibrarianRequest { get; set; }
}
