using MassTransit;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace ProxyLibrary.Publishers.Library;

public class DeleteLibraryMessagePublisher : IMessagePublisher<DeleteLibraryRequest, DeleteLibraryResponse>
{
    private readonly IRequestClient<DeleteLibraryRequest> _requestClient;

    public DeleteLibraryMessagePublisher(IRequestClient<DeleteLibraryRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<DeleteLibraryResponse> SendMessageAsync(DeleteLibraryRequest request)
    {
        Response<DeleteLibraryResponse> result = await _requestClient.GetResponse<DeleteLibraryResponse>(request);

        return result.Message;
    }
}