using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.DTO.Requests.Librarian;

public class UpdateLibrarianRequest
{
    public Guid Id { get; set; }
    public int? LibraryNumber { get; set; }

    [MaxLength(50, ErrorMessage = "FullName is too long")]
    public string? FullName { get; set; }

    [MaxLength(50, ErrorMessage = "Phone is too long")]
    public string? Phone { get; set; }
}