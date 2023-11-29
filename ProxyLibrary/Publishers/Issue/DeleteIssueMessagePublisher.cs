using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;

namespace ProxyLibrary.Publishers.Issue;

public class DeleteIssueMessagePublisher : IMessagePublisher<DeleteIssueRequest, DeleteIssueResponse>
{
    private readonly IRequestClient<DeleteIssueRequest> _requestClient;

    public DeleteIssueMessagePublisher(IRequestClient<DeleteIssueRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<DeleteIssueResponse> SendMessageAsync(DeleteIssueRequest request)
    {
        Response<DeleteIssueResponse> result = await _requestClient.GetResponse<DeleteIssueResponse>(request);

        return result.Message;
    }
}