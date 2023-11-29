using ServiceModels.Responses.Library;

namespace ServiceModels.Responses.Library;

internal class GetLibrariesResponse
{
    public List<GetLibraryResponse>? LibraryResponses { get; set; }
}
