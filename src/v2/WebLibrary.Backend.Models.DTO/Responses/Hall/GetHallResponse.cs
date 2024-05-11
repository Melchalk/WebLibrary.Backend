namespace ServiceModels.Responses.Hall;

public class GetHallResponse
{
    public Guid LibraryId { get; set; }
    public uint Number { get; set; }
    public string? Title { get; set; }
    public required string Thematic { get; set; }
}