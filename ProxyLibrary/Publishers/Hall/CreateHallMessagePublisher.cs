using MassTransit;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace ClientWebLibrary.Publishers.Hall;

public class CreateHallMessagePublisher : IMessagePublisher<CreateHallRequest, CreateHallResponse>
{
    private readonly IRequestClient<CreateHallRequest> _requestClient;

    public CreateHallMessagePublisher(IRequestClient<CreateHallRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<CreateHallResponse> SendMessageAsync(CreateHallRequest request)
    {
        Response<CreateHallResponse> result = await _requestClient.GetResponse<CreateHallResponse>(request);

        return result.Message;
    }
}