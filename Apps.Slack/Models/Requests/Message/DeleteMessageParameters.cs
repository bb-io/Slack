using Apps.Slack.DataSourceHandlers;
using Apps.Slack.Extensions;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Requests.Message;

public class DeleteMessageParameters(string channelId, string ts)
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    [JsonProperty("channel")]
    public string ChannelId { get; set; } = channelId;

    [Display("Timestamp")]
    public string Ts { get; set; } = ts;

    [Display("Timestamp (Datetime)")]
    public DateTime Timestamp { get; set; } = ts.ToDateTime();
}