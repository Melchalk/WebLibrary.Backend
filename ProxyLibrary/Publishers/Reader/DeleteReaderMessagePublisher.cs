using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;

namespace ProxyLibrary.Publishers.Reader;

public class DeleteReaderMessagePublisher : IMessagePublisher<DeleteReaderRequest, DeleteReaderResponse>
{
    private readonly IRequestClient<DeleteReaderRequest> _requestClient;

    public DeleteReaderMessagePublisher(IRequestClient<DeleteReaderRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<DeleteReaderResponse> SendMessageAsync(DeleteReaderRequest request)
    {
        Response<DeleteReaderResponse> result = await _requestClient.GetResponse<DeleteReaderResponse>(request);

        return result.Message;
    }
}