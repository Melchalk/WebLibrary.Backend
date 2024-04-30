using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;

namespace ProxyLibrary.Publishers.Issue;

public class UpdateIssueMessagePublisher : IMessagePublisher<UpdateIssueRequest, UpdateIssueResponse>
{
    private readonly IRequestClient<UpdateIssueRequest> _requestClient;

    public UpdateIssueMessagePublisher(IRequestClient<UpdateIssueRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<UpdateIssueResponse> SendMessageAsync(UpdateIssueRequest request)
    {
        Response<UpdateIssueResponse> result = await _requestClient.GetResponse<UpdateIssueResponse>(request);

        return result.Message;
    }
}