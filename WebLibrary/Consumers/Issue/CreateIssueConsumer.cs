using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;

namespace WebLibrary.Consumers.Issue;

public class CreateIssueConsumer : IConsumer<CreateIssueRequest>
{
    private readonly ICreaterIssue _command;

    public CreateIssueConsumer(ICreaterIssue command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<CreateIssueRequest> context)
    {
        CreateIssueResponse actionResult = await _command.CreateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}