using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;
using WebLibrary.Commands.Issue.Interfaces;

namespace WebLibrary.Consumers.Issue;

public class DeleteIssueConsumer : IConsumer<DeleteIssueRequest>
{
    private readonly IDeleterIssue _command;

    public DeleteIssueConsumer(IDeleterIssue command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<DeleteIssueRequest> context)
    {
        DeleteIssueResponse actionResult = await _command.DeleteAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}