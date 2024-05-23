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
}