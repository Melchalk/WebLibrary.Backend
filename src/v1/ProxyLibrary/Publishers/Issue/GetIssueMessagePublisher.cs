using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;

namespace ProxyLibrary.Publishers.Issue;

public class GetIssueMessagePublisher : IMessagePublisher<GetIssueRequest, GetIssueResponse>
{
    private readonly IRequestClient<GetIssueRequest> _requestClient;

    public GetIssueMessagePublisher(IRequestClient<GetIssueRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetIssueResponse> SendMessageAsync(GetIssueRequest request)
    {
        Response<GetIssueResponse> result = await _requestClient.GetResponse<GetIssueResponse>(request);

        return result.Message;
    }
}