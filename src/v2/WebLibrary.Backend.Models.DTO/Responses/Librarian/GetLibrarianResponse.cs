namespace WebLibrary.Backend.Models.DTO.Responses.Librarian;

public class GetLibrarianResponse
{
    public Guid Id { get; set; }
    public int? LibraryNumber { get; set; }
    public required string FullName { get; set; }
    public required string Phone { get; set; }
}