using LibraryStructure.Commands.Hall.Interfaces;
using MassTransit;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace LibraryStructure.Consumers.Hall;

public class GetHallConsumer : IConsumer<GetHallRequest>
{
    private readonly IReadHallCommand _command;

    public GetHallConsumer(IReadHallCommand command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetHallRequest> context)
    {
        GetHallResponse actionResult = await _command.GetAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}