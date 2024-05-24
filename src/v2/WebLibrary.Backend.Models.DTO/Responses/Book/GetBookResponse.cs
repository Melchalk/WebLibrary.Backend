namespace WebLibrary.Backend.Models.DTO.Responses.Book;

public class GetBookResponse
{
    public Guid Id { get; set; }
    public int LibraryNumber { get; set; }
    public required string Title { get; set; }
    public string? Author { get; set; }
    public uint NumberPages { get; set; }
    public uint YearPublishing { get; set; }
    public string? CityPublishing { get; set; }
    public uint? HallNo { get; set; }
    public Guid? IssueId { get; set; }
}