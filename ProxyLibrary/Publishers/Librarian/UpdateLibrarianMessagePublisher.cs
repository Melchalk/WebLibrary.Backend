using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace ClientWebLibrary.Publishers.Librarian;

public class UpdateLibrarianMessagePublisher : IMessagePublisher<UpdateLibrarianRequest, UpdateLibrarianResponse>
{
    private readonly IRequestClient<UpdateLibrarianRequest> _requestClient;

    public UpdateLibrarianMessagePublisher(IRequestClient<UpdateLibrarianRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<UpdateLibrarianResponse> SendMessageAsync(UpdateLibrarianRequest request)
    {
        Response<UpdateLibrarianResponse> result = await _requestClient.GetResponse<UpdateLibrarianResponse>(request);

        return result.Message;
    }
}