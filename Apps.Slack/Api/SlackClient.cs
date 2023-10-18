using System.Text.Json;
using Apps.Slack.Constants;
using Apps.Slack.Models.Responses;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.Slack.Api;

public class SlackClient : RestClient
{
    public SlackClient() : base(new RestClientOptions()
    {
        BaseUrl = Urls.Api.ToUri()
    })
    {
    }

    public async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);
        var genericResponse = JsonSerializer.Deserialize<GenericResponse>(response.Content!, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (!string.IsNullOrEmpty(genericResponse?.Error))
            throw new Exception($"Error: {genericResponse.Error}");

        return response;
    }

    public async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithErrorHandling(request);
        return JsonSerializer.Deserialize<T>(response.Content!)!;
    }
}