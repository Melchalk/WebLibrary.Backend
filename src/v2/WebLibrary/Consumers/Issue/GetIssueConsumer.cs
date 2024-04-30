using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;
using WebLibrary.Commands.Issue.Interfaces;

namespace WebLibrary.Consumers.Issue;

public class GetIssueConsumer : IConsumer<GetIssueRequest>
{
    private readonly IReadIssueCommand _command;

    public GetIssueConsumer(IReadIssueCommand command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetIssueRequest> context)
    {
        GetIssueResponse actionResult = await _command.GetAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}