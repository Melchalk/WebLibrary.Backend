using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.DTO.Requests.Librarian;

public class CreateLibrarianRequest
{
    public Guid? LibraryId { get; set; }

    [MaxLength(50)]
    public required string FullName { get; set; }

    [MaxLength(50)]
    public required string Phone { get; set; }
}