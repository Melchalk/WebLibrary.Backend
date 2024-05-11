using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests.Hall;

public class CreateHallRequest
{
    public Guid LibraryId { get; set; }
    public uint Number { get; set; }

    [MaxLength(50)]
    public required string Title { get; set; }

    [MaxLength(50)]
    public required string Thematic { get; set; }
}