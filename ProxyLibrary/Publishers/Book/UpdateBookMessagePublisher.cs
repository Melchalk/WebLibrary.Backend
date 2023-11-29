using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace ClientWebLibrary.Publishers.Book;

public class UpdateBookMessagePublisher : IMessagePublisher<UpdateBookRequest, UpdateBookResponse>
{
    private readonly IRequestClient<UpdateBookRequest> _requestClient;

    public UpdateBookMessagePublisher(IRequestClient<UpdateBookRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<UpdateBookResponse> SendMessageAsync(UpdateBookRequest request)
    {
        Response<UpdateBookResponse> result = await _requestClient.GetResponse<UpdateBookResponse>(request);

        return result.Message;
    }
}