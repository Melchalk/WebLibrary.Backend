using ServiceModels.Responses.Hall;
using ServiceModels.Responses.Librarian;

namespace ServiceModels.Responses.Library;

public class GetLibraryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string Telephone { get; set; }

    public string? Error { get; set; }

    public IList<GetLibrarianResponse> Librarians { get; set; } = new List<GetLibrarianResponse>();
    public IList<GetHallResponse> Halls { get; set; } = new List<GetHallResponse>();
}