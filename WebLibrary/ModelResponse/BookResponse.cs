namespace WebLibrary.ModelResponse;

public class BookResponse
{
    public string Title { get; set; }
    public string? Author { get; set; }
    public int NumberPages { get; set; }
    public int YearPublishing { get; set; }
    public string? CityPublishing { get; set; }
    public int? HallNo { get; set; }
    public Guid? IssueId { get; set; }

    //public IssueResponse? Issue { get; set; }
}