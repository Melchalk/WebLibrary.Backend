using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace LibraryStructure.Consumers.Librarian;

public class GetLibrariansConsumer : IConsumer<GetLibrariansRequest>
{
    private readonly ILibrarianLibrarian _command;

    public GetLibrariansConsumer(ILibrarianLibrarian command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetLibrariansRequest> context)
    {
        GetLibrariansResponse actionResult = _command.Get();

        await context.RespondAsync(actionResult);
    }
}