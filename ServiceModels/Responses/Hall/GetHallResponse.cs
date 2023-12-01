namespace ServiceModels.Responses.Hall;

public class GetHallResponse
{
    public int No { get; set; }
    public string Title { get; set; }
    public string Thematics { get; set; }
    public Guid LibraryId { get; set; }

    public string? Error { get; set; }
}
