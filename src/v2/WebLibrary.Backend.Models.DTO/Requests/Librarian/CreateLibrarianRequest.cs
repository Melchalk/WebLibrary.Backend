using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.DTO.Requests.Librarian;

public class CreateLibrarianRequest
{
    public int? LibraryNumber { get; set; }

    [MaxLength(50)]
    public required string FullName { get; set; }

    [MaxLength(50)]
    public required string Phone { get; set; }
    public required string Password { get; set; }
}