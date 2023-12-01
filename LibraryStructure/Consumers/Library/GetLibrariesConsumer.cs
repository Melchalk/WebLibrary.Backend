using LibraryStructure.Commands.Library.Interfaces;
using MassTransit;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace LibraryStructure.Consumers.Library;

public class GetLibrariesConsumer : IConsumer<GetLibrariesRequest>
{
    private readonly IReaderLibrary _command;

    public GetLibrariesConsumer(IReaderLibrary command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetLibrariesRequest> context)
    {
        GetLibrariesResponse actionResult = _command.Get();

        await context.RespondAsync(actionResult);
    }
}