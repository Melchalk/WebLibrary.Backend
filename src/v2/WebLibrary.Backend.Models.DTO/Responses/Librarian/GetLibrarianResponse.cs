namespace ServiceModels.Responses.Librarian;

public class GetLibrarianResponse
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public required string Telephone { get; set; }
    public Guid? LibraryId { get; set; }
}