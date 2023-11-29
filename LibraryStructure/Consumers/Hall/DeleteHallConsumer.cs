using LibraryStructure.Commands.Hall.Interfaces;
using MassTransit;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace LibraryStructure.Consumers.Hall;

public class DeleteHallConsumer : IConsumer<DeleteHallRequest>
{
    private readonly IDeleterHall _command;

    public DeleteHallConsumer(IDeleterHall command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<DeleteHallRequest> context)
    {
        DeleteHallResponse actionResult = await _command.DeleteAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}