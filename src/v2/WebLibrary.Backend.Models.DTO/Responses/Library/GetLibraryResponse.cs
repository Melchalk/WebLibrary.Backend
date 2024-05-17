using WebLibrary.Backend.Models.DTO.Responses.Hall;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;

namespace WebLibrary.Backend.Models.DTO.Responses.Library;

public class GetLibraryResponse
{
    public int Number { get; set; }
    public required string Title { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }

    public int LibrariansCount { get; set; }
    public int BooksCount { get; set; }
    public int IssuesCount { get; set; }
    public required string OwnerPhone { get; set; }
    public required string OwnerName{ get; set; }

    public required GetLibrarianResponse Owner { get; set; }

    public IList<GetLibrarianResponse>? Librarians { get; set; }
    public IList<GetHallResponse>? Halls { get; set; }
}