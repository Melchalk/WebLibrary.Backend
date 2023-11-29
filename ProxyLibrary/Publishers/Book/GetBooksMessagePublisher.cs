using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace ClientWebLibrary.Publishers.Book;

public class GetBooksMessagePublisher : IMessagePublisher<GetBooksRequest, GetBooksResponse>
{
    private readonly IRequestClient<GetBooksRequest> _requestClient;

    public GetBooksMessagePublisher(IRequestClient<GetBooksRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetBooksResponse> SendMessageAsync(GetBooksRequest request)
    {
        Response<GetBooksResponse> result = await _requestClient.GetResponse<GetBooksResponse>(request);

        return result.Message;
    }
}