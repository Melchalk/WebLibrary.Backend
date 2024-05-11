using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests.Librarian;

public class CreateLibrarianRequest
{
    public Guid? LibraryId { get; set; }

    [MaxLength(50)]
    public required string FullName { get; set; }

    [MaxLength(50)]
    public required string Phone { get; set; }
}