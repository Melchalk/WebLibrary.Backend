namespace ServiceModels.Responses.Book;

public class GetBookResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Author { get; set; }
    public int NumberPages { get; set; }
    public int YearPublishing { get; set; }
    public string? CityPublishing { get; set; }
    public int? HallNo { get; set; }
    public Guid? IssueId { get; set; }

    public string? Error { get; set; }
}