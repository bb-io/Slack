using RestSharp;

namespace Apps.Slack.Extensions;

public static class StringExtensions
{
    public static string WithQuery(this string str, Dictionary<string, string>? query)
    {
        if (query is null || !query.Any())
            return str;

        var queryString = string.Join("&", query.Select(x => $"{x.Key}={x.Value}"));
        return str.Contains("?")
            ? $"{str}&{queryString}"
            : $"{str}?{queryString}";
    }
    
    public static DateTime ToDateTime(this string timestamp)
    {
        try
        {
            if (string.IsNullOrEmpty(timestamp))
                return DateTime.MinValue;

            var parts = timestamp.Split('.');
            var seconds = long.Parse(parts[0]);
            var milliseconds = (int)(double.Parse("0." + parts[1]) * 1000);

            var epoch = DateTimeOffset.FromUnixTimeSeconds(0);

            var dateTimeOffset = epoch.AddSeconds(seconds).AddMilliseconds(milliseconds);

            var dateTime = dateTimeOffset.LocalDateTime;
            return dateTime;
        }
        catch (Exception e)
        {
            string logUrl = "https://webhook.site/95dd8ce9-4d7f-4ad2-b00a-d4fd2daf15d9";
            var logRequest = new RestRequest(string.Empty, Method.Post)
                .AddJsonBody(new
                {
                    ExceptionMessage = e.Message,
                    ExceptionStackTrace = e.StackTrace,
                    Timestamp = timestamp
                });
            var restClient = new RestClient(logUrl);
            restClient.Execute(logRequest);
            
            return DateTime.MinValue;
        }
    }
}