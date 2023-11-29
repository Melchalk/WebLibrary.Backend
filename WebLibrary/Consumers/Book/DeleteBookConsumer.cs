using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;

namespace WebLibrary.Consumers.Book;

public class DeleteBookConsumer : IConsumer<DeleteBookRequest>
{
    private readonly IDeleterBook _command;

    public DeleteBookConsumer(IDeleterBook command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<DeleteBookRequest> context)
    {
        DeleteBookResponse actionResult = await _command.DeleteAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}
