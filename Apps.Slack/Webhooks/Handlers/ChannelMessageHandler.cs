namespace Apps.Slack.Webhooks.Handlers
{
    public class ChannelMessageHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "message.channels";

        public ChannelMessageHandler() : base(SubscriptionEvent) { }
    }
}
