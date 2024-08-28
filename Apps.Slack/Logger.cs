using Apps.Slack.Extensions;
using RestSharp;

namespace Apps.Slack;

public static class Logger
{
    private const string WebhookUrl = "https://webhook.site/5cede979-231d-4238-b932-2c2b73e17615";

    public static async Task LogAsync<T>(T obj) where T : class
    {
        var request = new RestRequest(string.Empty, Method.Post)
            .WithJsonBody(obj);
        
        var client = new RestClient(WebhookUrl);
        await client.ExecuteAsync(request);
    }
    
    public static async Task LogAsync(Exception exception)
    {
        await LogAsync(new
        {
            Exception = exception.Message,
            exception.StackTrace,
            InnerException = exception.InnerException?.Message,
            ExceptionType = exception.GetType().Name
        });
    }
}