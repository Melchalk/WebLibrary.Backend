using LibraryStructure.Commands.Librarian.Interfaces;
using MassTransit;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace LibraryStructure.Consumers.Librarian;

public class GetLibrarianConsumer : IConsumer<GetLibrarianRequest>
{
    private readonly IReaderLibrarian _command;

    public GetLibrarianConsumer(IReaderLibrarian command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetLibrarianRequest> context)
    {
        GetLibrarianResponse? actionResult = await _command.GetAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}