using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Slack;

public static class WebhookLogger
{
    private static string WebhookUrl = "https://webhook.site/7e8dcedd-754f-42d1-8228-e98a8c2a984d";

    public static async Task LogAsync<T>(T obj) where T : class
    {
        var restRequest = new RestRequest(WebhookUrl, Method.Post)
            .WithJsonBody(obj);
        var restClient = new RestClient();
        await restClient.ExecuteAsync(restRequest);
    }

    public static async Task LogAsync(Exception exception)
    {
        await LogAsync(new
        {
            exception.Message,
            exception.StackTrace,
            ExceptionType = exception.GetType().Name
        });
    }
}