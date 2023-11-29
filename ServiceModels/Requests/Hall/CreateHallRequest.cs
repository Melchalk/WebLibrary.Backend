using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests.Hall;

public class CreateHallRequest
{
    public int No { get; set; }

    [MaxLength(50, ErrorMessage = "Title of hall is too long")]
    public string Title { get; set; }

    [MaxLength(50, ErrorMessage = "Thematics of hall is too long")]
    public string Thematics { get; set; }

    public Guid LibraryId { get; set; }
}
