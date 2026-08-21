using System.Globalization;
using System.Net;
using Polly;
using Polly.Retry;
using RestSharp;

namespace Apps.Slack.Api;

public static class SlackPollyPolicies
{
    internal const int RateLimitRetryCount = 5;
    private const double MinimumDelaySeconds = 5;
    private const double MaximumDelaySeconds = 25;

    public static ResiliencePipeline<RestResponse> CreateRateLimitPipeline()
    {
        var options = new RetryStrategyOptions<RestResponse>
        {
            MaxRetryAttempts = RateLimitRetryCount,
            ShouldHandle = new PredicateBuilder<RestResponse>()
                .HandleResult(response => response.StatusCode == HttpStatusCode.TooManyRequests)
                .Handle<HttpRequestException>(exception =>
                    exception.StatusCode == HttpStatusCode.TooManyRequests),
            DelayGenerator = args => new ValueTask<TimeSpan?>(GetRetryDelay(args.Outcome.Result))
        };

        return new ResiliencePipelineBuilder<RestResponse>()
            .AddRetry(options)
            .Build();
    }

    internal static TimeSpan GetRetryDelay(RestResponse? response)
    {
        var retryAfter = response?.Headers?
            .FirstOrDefault(header =>
                header.Name?.Equals("Retry-After", StringComparison.OrdinalIgnoreCase) == true)
            ?.Value?.ToString();

        if (double.TryParse(retryAfter, NumberStyles.Float, CultureInfo.InvariantCulture, out var seconds) &&
            seconds >= 0)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        var delaySeconds = Random.Shared.NextDouble() *
                           (MaximumDelaySeconds - MinimumDelaySeconds) + MinimumDelaySeconds;

        return TimeSpan.FromSeconds(delaySeconds);
    }
}
