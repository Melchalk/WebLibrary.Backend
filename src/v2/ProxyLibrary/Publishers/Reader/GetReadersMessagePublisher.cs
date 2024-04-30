using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;

namespace ProxyLibrary.Publishers.Reader;

public class GetReadersMessagePublisher : IMessagePublisher<GetReadersRequest, GetReadersResponse>
{
    private readonly IRequestClient<GetReadersRequest> _requestClient;

    public GetReadersMessagePublisher(IRequestClient<GetReadersRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetReadersResponse> SendMessageAsync(GetReadersRequest request)
    {
        Response<GetReadersResponse> result = await _requestClient.GetResponse<GetReadersResponse>(request);

        return result.Message;
    }
}