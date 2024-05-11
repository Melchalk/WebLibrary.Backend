namespace ServiceModels.Responses.Hall;

public class GetHallResponse
{
    public int No { get; set; }
    public required string Title { get; set; }
    public required string Thematic { get; set; }
    public Guid LibraryId { get; set; }
}