using MassTransit;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace ProxyLibrary.Publishers.Book;

public class GetLibrariesMessagePublisher : IMessagePublisher<GetLibrariesRequest, GetLibrariesResponse>
{
    private readonly IRequestClient<GetLibrariesRequest> _requestClient;

    public GetLibrariesMessagePublisher(IRequestClient<GetLibrariesRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetLibrariesResponse> SendMessageAsync(GetLibrariesRequest request)
    {
        Response<GetLibrariesResponse> result = await _requestClient.GetResponse<GetLibrariesResponse>(request);

        return result.Message;
    }
}