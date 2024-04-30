using MassTransit;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace ProxyLibrary.Publishers.Hall;

public class GetHallsMessagePublisher : IMessagePublisher<GetHallsRequest, GetHallsResponse>
{
    private readonly IRequestClient<GetHallsRequest> _requestClient;

    public GetHallsMessagePublisher(IRequestClient<GetHallsRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetHallsResponse> SendMessageAsync(GetHallsRequest request)
    {
        Response<GetHallsResponse> result = await _requestClient.GetResponse<GetHallsResponse>(request);

        return result.Message;
    }
}