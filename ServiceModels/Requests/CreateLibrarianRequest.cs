using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests;

public class CreateLibrarianRequest
{
    [MaxLength(50, ErrorMessage = "Fullname is too long")]
    public string Fullname { get; set; }

    [MaxLength(50, ErrorMessage = "Telephone is too long"))]
    public string Telephone { get; set; }

    public Guid LibraryId { get; set; }
}
