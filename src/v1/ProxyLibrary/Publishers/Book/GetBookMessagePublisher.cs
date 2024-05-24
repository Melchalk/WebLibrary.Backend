using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace ProxyLibrary.Publishers.Book;

public class GetBookMessagePublisher : IMessagePublisher<GetBookRequest, GetBookResponse>
{
    private readonly IRequestClient<GetBookRequest> _requestClient;

    public GetBookMessagePublisher(IRequestClient<GetBookRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetBookResponse> SendMessageAsync(GetBookRequest request)
    {
        Response<GetBookResponse> result = await _requestClient.GetResponse<GetBookResponse>(request);

        return result.Message;
    }
}