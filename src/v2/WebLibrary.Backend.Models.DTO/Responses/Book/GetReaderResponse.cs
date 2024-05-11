namespace ServiceModels.Responses.Book;

public class GetReaderResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Author { get; set; }
    public int NumberPages { get; set; }
    public int YearPublishing { get; set; }
    public string? CityPublishing { get; set; }
    public int? HallNo { get; set; }
    public Guid? IssueId { get; set; }
}