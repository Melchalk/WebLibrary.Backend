namespace ServiceModels.Responses.Book;

public class GetReaderResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Author { get; set; }
    public uint NumberPages { get; set; }
    public uint YearPublishing { get; set; }
    public string? CityPublishing { get; set; }
    public uint? HallNo { get; set; }
    public Guid? IssueId { get; set; }
}