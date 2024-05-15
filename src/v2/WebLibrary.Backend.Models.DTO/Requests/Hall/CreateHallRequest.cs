using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.DTO.Requests.Hall;

public class CreateHallRequest
{
    public int LibraryNumber { get; set; }
    public uint Number { get; set; }

    [MaxLength(50)]
    public string? Title { get; set; }

    [MaxLength(50)]
    public required string Thematic { get; set; }
}