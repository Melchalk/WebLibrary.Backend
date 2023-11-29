using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;
using WebLibrary.Commands.Issue.Interfaces;

namespace WebLibrary.Consumers.Issue;

public class UpdateIssueConsumer : IConsumer<UpdateIssueRequest>
{
    private readonly IUpdaterIssue _command;

    public UpdateIssueConsumer(IUpdaterIssue command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<UpdateIssueRequest> context)
    {
        UpdateIssueResponse actionResult = await _command.UpdateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}