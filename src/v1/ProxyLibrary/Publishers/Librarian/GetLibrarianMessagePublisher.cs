using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace ProxyLibrary.Publishers.Librarian;

public class GetLibrarianMessagePublisher : IMessagePublisher<GetLibrarianRequest, GetLibrarianResponse>
{
    private readonly IRequestClient<GetLibrarianRequest> _requestClient;

    public GetLibrarianMessagePublisher(IRequestClient<GetLibrarianRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetLibrarianResponse> SendMessageAsync(GetLibrarianRequest request)
    {
        Response<GetLibrarianResponse> result = await _requestClient.GetResponse<GetLibrarianResponse>(request);

        return result.Message;
    }
}