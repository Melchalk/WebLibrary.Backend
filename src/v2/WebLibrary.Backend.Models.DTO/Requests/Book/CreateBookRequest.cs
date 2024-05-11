using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests.Book;

public class CreateBookRequest
{
    [MaxLength(50, ErrorMessage = "Title of book is too long")]
    public required string Title { get; set; }

    [MaxLength(50, ErrorMessage = "Author's name is too long")]
    public string? Author { get; set; }

    public uint NumberPages { get; set; }
    public uint YearPublishing { get; set; }

    [MaxLength(50, ErrorMessage = "Name of the publication city is too long")]
    public string? CityPublishing { get; set; }

    public int? HallNo { get; set; }
}