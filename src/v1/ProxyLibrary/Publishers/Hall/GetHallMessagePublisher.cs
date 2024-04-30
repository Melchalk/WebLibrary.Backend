using MassTransit;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace ProxyLibrary.Publishers.Hall;

public class GetHallMessagePublisher : IMessagePublisher<GetHallRequest, GetHallResponse>
{
    private readonly IRequestClient<GetHallRequest> _requestClient;

    public GetHallMessagePublisher(IRequestClient<GetHallRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetHallResponse> SendMessageAsync(GetHallRequest request)
    {
        Response<GetHallResponse> result = await _requestClient.GetResponse<GetHallResponse>(request);

        return result.Message;
    }
}