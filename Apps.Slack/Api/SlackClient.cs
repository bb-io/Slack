using Apps.Slack.Constants;
using Apps.Slack.Models.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Slack.Api;

public class SlackClient : RestClient
{
    public SlackClient() : base(new RestClientOptions()
    {
        BaseUrl = new(Urls.Api)
    })
    {
    }

    public async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);
        var genericResponse = JsonConvert.DeserializeObject<GenericResponse>(response.Content!);

        if (!string.IsNullOrEmpty(genericResponse?.Error))
            throw new Exception($"Error: {genericResponse.Error}");

        return response;
    }

    public async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithErrorHandling(request);
        return JsonConvert.DeserializeObject<T>(response.Content!)!;
    }
}