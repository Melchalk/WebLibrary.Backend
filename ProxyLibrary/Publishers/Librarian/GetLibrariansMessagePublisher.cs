using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace ProxyLibrary.Publishers.Librarian;

public class GetLibrariansMessagePublisher : IMessagePublisher<GetLibrariansRequest, GetLibrariansResponse>
{
    private readonly IRequestClient<GetLibrariansRequest> _requestClient;

    public GetLibrariansMessagePublisher(IRequestClient<GetLibrariansRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetLibrariansResponse> SendMessageAsync(GetLibrariansRequest request)
    {
        Response<GetLibrariansResponse> result = await _requestClient.GetResponse<GetLibrariansResponse>(request);

        return result.Message;
    }
}