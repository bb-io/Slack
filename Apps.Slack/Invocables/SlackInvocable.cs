using Apps.Slack.Api;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Slack.Invocables;

public class SlackInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected SlackClient Client { get; }

    public SlackInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }
}