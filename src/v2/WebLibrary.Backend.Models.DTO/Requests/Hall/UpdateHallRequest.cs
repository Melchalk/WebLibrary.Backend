using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.DTO.Requests.Hall;

public class UpdateHallRequest
{
    public int LibraryNumber { get; set; }
    public uint Number { get; set; }

    [MaxLength(50)]
    public string? Title { get; set; }

    [MaxLength(50)]
    public string? Thematic { get; set; }
}