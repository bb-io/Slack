using Apps.Slack.DataSourceHandlers;
using Apps.Slack.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Webhooks.Payload;

public class OnMessageWebhookParameter
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string? ChannelId { get; set; }

    [Display("Message reply handling")]
    [StaticDataSource(typeof(ReplyTypeHandlerIDataSourceHandler))]
    public string? ReplyHandling { get; set; }

    [Display("Trigger only when message has files")]
    public bool? TriggerOnlyOnFiles { get; set; }
}