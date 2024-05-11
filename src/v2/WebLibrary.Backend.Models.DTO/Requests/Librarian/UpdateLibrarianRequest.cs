using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests.Librarian;

public class UpdateLibrarianRequest
{
    public Guid Id { get; set; }
    public Guid? LibraryId { get; set; }

    [MaxLength(50, ErrorMessage = "FullName is too long")]
    public string? FullName { get; set; }

    [MaxLength(50, ErrorMessage = "Phone is too long")]
    public string? Phone { get; set; }
}