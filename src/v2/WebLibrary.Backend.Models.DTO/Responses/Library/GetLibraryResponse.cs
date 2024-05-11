using ServiceModels.Responses.Hall;
using ServiceModels.Responses.Librarian;

namespace ServiceModels.Responses.Library;

public class GetLibraryResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Address { get; set; }
    public required string Telephone { get; set; }

    public IList<GetLibrarianResponse> Librarians { get; set; } = new List<GetLibrarianResponse>();
    public IList<GetHallResponse> Halls { get; set; } = new List<GetHallResponse>();
}