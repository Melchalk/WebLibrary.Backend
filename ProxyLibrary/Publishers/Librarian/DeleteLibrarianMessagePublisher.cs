using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace ClientWebLibrary.Publishers.Librarian;

public class DeleteLibrarianMessagePublisher : IMessagePublisher<DeleteLibrarianRequest, DeleteLibrarianResponse>
{
    private readonly IRequestClient<DeleteLibrarianRequest> _requestClient;

    public DeleteLibrarianMessagePublisher(IRequestClient<DeleteLibrarianRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<DeleteLibrarianResponse> SendMessageAsync(DeleteLibrarianRequest request)
    {
        Response<DeleteLibrarianResponse> result = await _requestClient.GetResponse<DeleteLibrarianResponse>(request);

        return result.Message;
    }
}