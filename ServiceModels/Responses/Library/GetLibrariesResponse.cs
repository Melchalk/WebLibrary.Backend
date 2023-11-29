using ServiceModels.Responses.Library;

namespace ServiceModels.Responses.Library;

public class GetLibrariesResponse
{
    public List<GetLibraryResponse>? LibraryResponses { get; set; }
}
