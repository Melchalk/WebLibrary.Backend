using MassTransit;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace LibraryStructure.Consumers.Library;

public class UpdateLibraryConsumer : IConsumer<UpdateLibraryRequest>
{
    private readonly IUpdaterLibrary _command;

    public UpdateLibraryConsumer(IUpdaterLibrary command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<UpdateLibraryRequest> context)
    {
        UpdateLibraryResponse actionResult = await _command.UpdateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}