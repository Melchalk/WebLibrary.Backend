using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;

namespace ClientWebLibrary.Publishers.Reader;

public class GetReaderMessagePublisher : IMessagePublisher<GetReaderRequest, GetReaderResponse>
{
    private readonly IRequestClient<GetReaderRequest> _requestClient;

    public GetReaderMessagePublisher(IRequestClient<GetReaderRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetReaderResponse> SendMessageAsync(GetReaderRequest request)
    {
        Response<GetReaderResponse> result = await _requestClient.GetResponse<GetReaderResponse>(request);

        return result.Message;
    }
}