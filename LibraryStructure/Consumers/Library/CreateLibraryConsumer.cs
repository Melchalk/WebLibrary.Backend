using MassTransit;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace LibraryStructure.Consumers.Library;

public class CreateLibraryConsumer : IConsumer<CreateLibraryRequest>
{
    private readonly ICreaterLibrary _command;

    public CreateLibraryConsumer(ICreaterLibrary command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<CreateLibraryRequest> context)
    {
        CreateLibraryResponse actionResult = await _command.CreateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}