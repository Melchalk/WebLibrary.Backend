using MassTransit;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace LibraryStructure.Consumers.Library;

public class GetLibraryConsumer : IConsumer<GetLibraryRequest>
{
    private readonly IReaderLibrary _command;

    public GetLibraryConsumer(IReaderLibrary command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetLibraryRequest> context)
    {
        GetLibraryResponse actionResult = await _command.GetAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}