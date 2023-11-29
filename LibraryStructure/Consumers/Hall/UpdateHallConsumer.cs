using MassTransit;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace LibraryStructure.Consumers.Hall;

public class UpdateHallConsumer : IConsumer<UpdateHallRequest>
{
    private readonly IUpdaterHall _command;

    public UpdateHallConsumer(IUpdaterHall command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<UpdateHallRequest> context)
    {
        UpdateHallResponse actionResult = await _command.UpdateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}