using MassTransit;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;

namespace ClientWebLibrary.Publishers.Issue;

public class GetIssuesMessagePublisher : IMessagePublisher<GetIssuesRequest, GetIssuesResponse>
{
    private readonly IRequestClient<GetIssuesRequest> _requestClient;

    public GetIssuesMessagePublisher(IRequestClient<GetIssuesRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<GetIssuesResponse> SendMessageAsync(GetIssuesRequest request)
    {
        Response<GetIssuesResponse> result = await _requestClient.GetResponse<GetIssuesResponse>(request);

        return result.Message;
    }
}