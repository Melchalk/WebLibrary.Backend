using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.DTO.Requests.Book;

public class CreateBookRequest
{
    public int? HallNo { get; set; }
    public int LibraryNumber { get; set; }

    [MaxLength(50)]
    public required string Title { get; set; }

    [MaxLength(50)]
    public string? Author { get; set; }

    public uint NumberPages { get; set; }
    public uint YearPublishing { get; set; }

    [MaxLength(50)]
    public string? CityPublishing { get; set; }
}