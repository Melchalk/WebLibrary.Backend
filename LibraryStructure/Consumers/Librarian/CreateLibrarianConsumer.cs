using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace LibraryStructure.Consumers.Librarian;

public class CreateLibrarianConsumer : IConsumer<CreateLibrarianRequest>
{
    private readonly ICreaterLibrarian _command;

    public CreateLibrarianConsumer(ICreaterLibrarian command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<CreateLibrarianRequest> context)
    {
        CreateLibrarianResponse actionResult = await _command.CreateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}