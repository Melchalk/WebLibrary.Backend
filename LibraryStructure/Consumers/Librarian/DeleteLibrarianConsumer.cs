using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace LibraryStructure.Consumers.Librarian;

public class DeleteLibrarianConsumer : IConsumer<DeleteLibrarianRequest>
{
    private readonly IDeleterLibrarian _command;

    public DeleteLibrarianConsumer(IDeleterLibrarian command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<DeleteLibrarianRequest> context)
    {
        DeleteLibrarianResponse actionResult = await _command.DeleteAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}