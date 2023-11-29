using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Commands.Librarian.Interfaces;

namespace LibraryStructure.Consumers.Librarian;

public class GetLibrarianConsumer : IConsumer<GetLibrarianRequest>
{
    private readonly ILibrarianLibrarian _command;

    public GetLibrarianConsumer(ILibrarianLibrarian command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetLibrarianRequest> context)
    {
        GetLibrarianResponse? actionResult = await _command.GetAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}