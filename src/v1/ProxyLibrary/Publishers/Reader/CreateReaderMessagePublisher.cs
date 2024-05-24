using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;

namespace ProxyLibrary.Publishers.Reader;

public class CreateReaderMessagePublisher : IMessagePublisher<CreateReaderRequest, CreateReaderResponse>
{
    private readonly IRequestClient<CreateReaderRequest> _requestClient;

    public CreateReaderMessagePublisher(IRequestClient<CreateReaderRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<CreateReaderResponse> SendMessageAsync(CreateReaderRequest request)
    {
        Response<CreateReaderResponse> result = await _requestClient.GetResponse<CreateReaderResponse>(request);

        return result.Message;
    }
}