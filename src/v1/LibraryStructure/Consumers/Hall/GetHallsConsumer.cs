using LibraryStructure.Commands.Hall.Interfaces;
using MassTransit;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace LibraryStructure.Consumers.Hall;

public class GetHallsConsumer : IConsumer<GetHallsRequest>
{
    private readonly IReadHallCommand _command;

    public GetHallsConsumer(IReadHallCommand command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetHallsRequest> context)
    {
        GetHallsResponse actionResult =  _command.Get();

        await context.RespondAsync(actionResult);
    }
}