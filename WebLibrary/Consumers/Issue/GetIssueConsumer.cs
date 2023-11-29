using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;

namespace WebLibrary.Consumers.Issue;

public class GetIssueConsumer : IConsumer<GetIssueRequest>
{
    private readonly IReaderIssue _command;

    public GetIssueConsumer(IReaderIssue command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetIssueRequest> context)
    {
        GetIssueResponse actionResult = await _command.GetAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}