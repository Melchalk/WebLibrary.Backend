namespace ServiceModels.Responses.Librarian;

public class GetLibrarianResponse
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public string Telephone { get; set; }
    public Guid? LibraryId { get; set; }

    public string? Error { get; set; }
}
