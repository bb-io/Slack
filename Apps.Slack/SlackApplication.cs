using Apps.Slack.Connections.OAuth2;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Metadata;
using Microsoft.Extensions.Logging;

namespace Apps.Slack;

public class SlackApplication : BaseInvocable, IApplication, ICategoryProvider
{    
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.Communication, ApplicationCategory.CustomerSupport];
        set { }
    }

    private readonly Dictionary<Type, object> _typesInstances;
    private readonly ILoggerFactory _loggerFactory;

    public SlackApplication(InvocationContext invocationContext, ILoggerFactory loggerFactory) : base(invocationContext)
    {
        _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        _typesInstances = CreateTypesInstances();
    }

    public T GetInstance<T>()
    {
        if (!_typesInstances.TryGetValue(typeof(T), out var value))
        {
            throw new InvalidOperationException($"Instance of type '{typeof(T)}' not found");
        }

        return (T)value;
    }

    private Dictionary<Type, object> CreateTypesInstances()
    {
        var logger = _loggerFactory.CreateLogger<OAuth2TokenService>();
        return new Dictionary<Type, object>
        {
            { typeof(IOAuth2AuthorizeService), new OAuth2AuthorizationService(InvocationContext) },
            { typeof(IOAuth2TokenService), new OAuth2TokenService(InvocationContext,logger) }
        };
    }
}