using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests.Book;

public class UpdateBookRequest
{
    public Guid Id { get; set; }
    public int? HallNo { get; set; }

    [MaxLength(50)]
    public string? Title { get; set; }

    [MaxLength(50)]
    public string? Author { get; set; }

    public uint? NumberPages { get; set; }
    public uint? YearPublishing { get; set; }

    [MaxLength(50)]
    public string? CityPublishing { get; set; }
}