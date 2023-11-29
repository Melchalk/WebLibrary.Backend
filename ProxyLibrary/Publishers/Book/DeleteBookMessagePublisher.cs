using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace ClientWebLibrary.Publishers.Book;

public class DeleteBookMessagePublisher : IMessagePublisher<DeleteBookRequest, DeleteBookResponse>
{
    private readonly IRequestClient<DeleteBookRequest> _requestClient;

    public DeleteBookMessagePublisher(IRequestClient<DeleteBookRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<DeleteBookResponse> SendMessageAsync(DeleteBookRequest request)
    {
        Response<DeleteBookResponse> result = await _requestClient.GetResponse<DeleteBookResponse>(request);

        return result.Message;
    }
}