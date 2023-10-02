using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Models.Responses
{
    public class OAuthTokenResponse
    {
        [JsonPropertyName("ok")]
        public bool Ok { get; set; }

        [Display("Access token")]
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

    }
}
