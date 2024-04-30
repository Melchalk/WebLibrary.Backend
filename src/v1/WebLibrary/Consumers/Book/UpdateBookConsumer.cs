using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;

namespace WebLibrary.Consumers.Book;

public class UpdateBookConsumer : IConsumer<UpdateBookRequest>
{
    private readonly IUpdateBookCommand _command;

    public UpdateBookConsumer(IUpdateBookCommand command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<UpdateBookRequest> context)
    {
        UpdateBookResponse actionResult = await _command.UpdateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}