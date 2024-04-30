using LibraryStructure.Commands.Librarian.Interfaces;
using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace LibraryStructure.Consumers.Librarian;

public class GetLibrariansConsumer : IConsumer<GetLibrariansRequest>
{
    private readonly IReaderLibrarian _command;

    public GetLibrariansConsumer(IReaderLibrarian command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetLibrariansRequest> context)
    {
        GetLibrariansResponse actionResult = _command.Get();

        await context.RespondAsync(actionResult);
    }
}