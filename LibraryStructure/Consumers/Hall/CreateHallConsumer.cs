using LibraryStructure.Commands.Hall.Interfaces;
using MassTransit;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace LibraryStructure.Consumers.Hall;

public class CreateHallConsumer : IConsumer<CreateHallRequest>
{
    private readonly ICreateHallCommand _command;

    public CreateHallConsumer(ICreateHallCommand command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<CreateHallRequest> context)
    {
        CreateHallResponse actionResult = await _command.CreateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}