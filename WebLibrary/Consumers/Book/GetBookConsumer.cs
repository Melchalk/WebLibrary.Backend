using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;

namespace WebLibrary.Consumers.Book;

public class GetBookConsumer : IConsumer<GetBookRequest>
{
    private readonly IReadBookCommand _command;

    public GetBookConsumer(IReadBookCommand command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetBookRequest> context)
    {
        GetBookResponse actionResult = await _command.GetAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}