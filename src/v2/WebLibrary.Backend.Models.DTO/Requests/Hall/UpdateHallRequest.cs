using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests.Hall;

public class UpdateHallRequest
{
    public Guid LibraryId { get; set; }
    public uint Number { get; set; }

    [MaxLength(50)]
    public string? Title { get; set; }

    [MaxLength(50)]
    public string? Thematic { get; set; }
}