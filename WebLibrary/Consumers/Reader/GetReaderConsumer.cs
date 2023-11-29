using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Reader.Interfaces;

namespace WebLibrary.Consumers.Reader;

public class GetReaderConsumer : IConsumer<GetReaderRequest>
{
    private readonly IReaderReader _command;

    public GetReaderConsumer(IReaderReader command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetReaderRequest> context)
    {
        GetReaderResponse? actionResult = await _command.GetAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}