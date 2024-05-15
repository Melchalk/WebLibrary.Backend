namespace WebLibrary.Backend.Models.DTO.Responses.Hall;

public class GetHallResponse
{
    public int LibraryNumber { get; set; }
    public uint Number { get; set; }
    public string? Title { get; set; }
    public required string Thematic { get; set; }
}