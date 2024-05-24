using MassTransit;
using ProxyLibrary.Publishers;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace ProxyLibrary.Publishers.Hall;

public class DeleteHallMessagePublisher : IMessagePublisher<DeleteHallRequest, DeleteHallResponse>
{
    private readonly IRequestClient<DeleteHallRequest> _requestClient;

    public DeleteHallMessagePublisher(IRequestClient<DeleteHallRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<DeleteHallResponse> SendMessageAsync(DeleteHallRequest request)
    {
        Response<DeleteHallResponse> result = await _requestClient.GetResponse<DeleteHallResponse>(request);

        return result.Message;
    }
}