namespace WebLibrary.Backend.Models.DTO.Responses.Reader;

public class GetReaderResponse
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public required string Phone { get; set; }
    public string? RegistrationAddress { get; set; }
    public uint Age { get; set; }
    public bool CanTakeBooks { get; set; }

    public Guid? IssueId { get; set; }
}