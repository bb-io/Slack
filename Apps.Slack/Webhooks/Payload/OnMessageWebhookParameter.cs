using Apps.Slack.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Slack.Webhooks.Payload;

public class OnMessageWebhookParameter
{
    [Display("Message reply handling")]
    [StaticDataSource(typeof(ReplyTypeHandlerIDataSourceHandler))]
    public string? ReplyHandling { get; set; }

    [Display("Trigger only when message has files")]
    public bool? TriggerOnlyOnFiles { get; set; }
}