using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests.Hall;

public class CreateHallRequest
{
    public Guid LibraryId { get; set; }
    public uint No { get; set; }

    [MaxLength(50, ErrorMessage = "Title of hall is too long")]
    public required string Title { get; set; }

    [MaxLength(50, ErrorMessage = "Thematic of hall is too long")]
    public required string Thematic { get; set; }
}