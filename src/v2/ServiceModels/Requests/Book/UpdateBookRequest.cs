namespace ServiceModels.Requests.Book;

public class UpdateBookRequest
{
    public Guid Id { get; set; }
    public CreateBookRequest CreateBookRequest { get; set; }
}