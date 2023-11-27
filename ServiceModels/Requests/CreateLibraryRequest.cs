using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests;

public class CreateLibraryRequest
{
    [MaxLength(50, ErrorMessage = "Title of library is too long")]
    public string Title { get; set; }

    [MaxLength(50, ErrorMessage = "Address is too long")]
    public string Address { get; set; }

    [MaxLength(50, ErrorMessage = "Telephone is too long")]
    public string Telephone { get; set; }
}
