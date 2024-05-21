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
    
    public static DateTime ToDateTime(this string timestamp) // 1715851118.440689
    {
        string[] parts = timestamp.Split('.');
        long seconds = long.Parse(parts[0]);
        int milliseconds = (int)(double.Parse("0." + parts[1]) * 1000);

        DateTimeOffset epoch = DateTimeOffset.FromUnixTimeSeconds(0);
        
        DateTimeOffset dateTimeOffset = epoch.AddSeconds(seconds).AddMilliseconds(milliseconds);

        DateTime dateTime = dateTimeOffset.LocalDateTime;
        return dateTime;
    }
}