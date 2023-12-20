using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Reader.Interfaces;

namespace WebLibrary.Consumers.Reader;

public class GetReadersConsumer : IConsumer<GetReadersRequest>
{
    private readonly IReadReaderCommand _command;

    public GetReadersConsumer(IReadReaderCommand command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetReadersRequest> context)
    {
        GetReadersResponse actionResult = _command.Get();

        await context.RespondAsync(actionResult);
    }
}