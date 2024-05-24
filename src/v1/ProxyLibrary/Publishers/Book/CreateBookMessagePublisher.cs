using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace ProxyLibrary.Publishers.Book;

public class CreateBookMessagePublisher : IMessagePublisher<CreateBookRequest, CreateBookResponse>
{
    private readonly IRequestClient<CreateBookRequest> _requestClient;

    public CreateBookMessagePublisher(IRequestClient<CreateBookRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<CreateBookResponse> SendMessageAsync(CreateBookRequest request)
    {
        Response<CreateBookResponse> result = await _requestClient.GetResponse<CreateBookResponse>(request);

        return result.Message;
    }
}