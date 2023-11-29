using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;

namespace ProxyLibrary.Publishers.Reader;

public class UpdateReaderMessagePublisher : IMessagePublisher<UpdateReaderRequest, UpdateReaderResponse>
{
    private readonly IRequestClient<UpdateReaderRequest> _requestClient;

    public UpdateReaderMessagePublisher(IRequestClient<UpdateReaderRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<UpdateReaderResponse> SendMessageAsync(UpdateReaderRequest request)
    {
        Response<UpdateReaderResponse> result = await _requestClient.GetResponse<UpdateReaderResponse>(request);

        return result.Message;
    }
}