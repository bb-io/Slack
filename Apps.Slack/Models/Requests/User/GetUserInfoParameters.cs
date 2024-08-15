using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Models.Requests.User;

public class GetUserInfoParameters
{
    [Display("User ID"), DataSource(typeof(UserHandler))]
    public string UserId { get; set; }
}