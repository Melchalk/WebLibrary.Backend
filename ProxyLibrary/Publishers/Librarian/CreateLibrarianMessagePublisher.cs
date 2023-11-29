using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace ProxyLibrary.Publishers.Librarian;

public class CreateLibrarianMessagePublisher : IMessagePublisher<CreateLibrarianRequest, CreateLibrarianResponse>
{
    private readonly IRequestClient<CreateLibrarianRequest> _requestClient;

    public CreateLibrarianMessagePublisher(IRequestClient<CreateLibrarianRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<CreateLibrarianResponse> SendMessageAsync(CreateLibrarianRequest request)
    {
        Response<CreateLibrarianResponse> result = await _requestClient.GetResponse<CreateLibrarianResponse>(request);

        return result.Message;
    }
}