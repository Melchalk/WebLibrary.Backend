using MassTransit;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace ClientWebLibrary.Publishers.Library;

public class UpdateLibraryMessagePublisher : IMessagePublisher<UpdateLibraryRequest, UpdateLibraryResponse>
{
    private readonly IRequestClient<UpdateLibraryRequest> _requestClient;

    public UpdateLibraryMessagePublisher(IRequestClient<UpdateLibraryRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<UpdateLibraryResponse> SendMessageAsync(UpdateLibraryRequest request)
    {
        Response<UpdateLibraryResponse> result = await _requestClient.GetResponse<UpdateLibraryResponse>(request);

        return result.Message;
    }
}