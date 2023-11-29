using MassTransit;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace LibraryStructure.Consumers.Library;

public class DeleteLibraryConsumer : IConsumer<DeleteLibraryRequest>
{
    private readonly IDeleterLibrary _command;

    public DeleteLibraryConsumer(IDeleterLibrary command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<DeleteLibraryRequest> context)
    {
        DeleteLibraryResponse actionResult = await _command.DeleteAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}