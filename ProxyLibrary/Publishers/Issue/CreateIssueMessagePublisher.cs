using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;

namespace ClientWebLibrary.Publishers.Issue;

public class CreateIssueMessagePublisher : IMessagePublisher<CreateIssueRequest, CreateIssueResponse>
{
    private readonly IRequestClient<CreateIssueRequest> _requestClient;

    public CreateIssueMessagePublisher(IRequestClient<CreateIssueRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<CreateIssueResponse> SendMessageAsync(CreateIssueRequest request)
    {
        Response<CreateIssueResponse> result = await _requestClient.GetResponse<CreateIssueResponse>(request);

        return result.Message;
    }
}