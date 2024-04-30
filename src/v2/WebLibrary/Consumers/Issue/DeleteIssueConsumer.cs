using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;
using WebLibrary.Commands.Issue.Interfaces;

namespace WebLibrary.Consumers.Issue;

public class DeleteIssueConsumer : IConsumer<DeleteIssueRequest>
{
    private readonly IDeleteIssueCommand _command;

    public DeleteIssueConsumer(IDeleteIssueCommand command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<DeleteIssueRequest> context)
    {
        DeleteIssueResponse actionResult = await _command.DeleteAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}