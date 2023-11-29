using MassTransit;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace ClientWebLibrary.Publishers.Library;

public class GetLibraryMessagePublisher : IMessagePublisher<GetLibraryRequest, GetLibraryResponse>
{
    private readonly IRequestClient<GetLibraryRequest> _requestClient;

    public GetLibraryMessagePublisher(IRequestClient<GetLibraryRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetLibraryResponse> SendMessageAsync(GetLibraryRequest request)
    {
        Response<GetLibraryResponse> result = await _requestClient.GetResponse<GetLibraryResponse>(request);

        return result.Message;
    }
}