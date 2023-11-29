using MassTransit;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace ClientWebLibrary.Publishers.Hall;

public class UpdateHallMessagePublisher : IMessagePublisher<UpdateHallRequest, UpdateHallResponse>
{
    private readonly IRequestClient<UpdateHallRequest> _requestClient;

    public UpdateHallMessagePublisher(IRequestClient<UpdateHallRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<UpdateHallResponse> SendMessageAsync(UpdateHallRequest request)
    {
        Response<UpdateHallResponse> result = await _requestClient.GetResponse<UpdateHallResponse>(request);

        return result.Message;
    }
}