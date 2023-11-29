using MassTransit;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace ClientWebLibrary.Publishers.Library;

public class CreateLibraryMessagePublisher : IMessagePublisher<CreateLibraryRequest, CreateLibraryResponse>
{
    private readonly IRequestClient<CreateLibraryRequest> _requestClient;

    public CreateLibraryMessagePublisher(IRequestClient<CreateLibraryRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<CreateLibraryResponse> SendMessageAsync(CreateLibraryRequest request)
    {
        Response<CreateLibraryResponse> result = await _requestClient.GetResponse<CreateLibraryResponse>(request);

        return result.Message;
    }
}