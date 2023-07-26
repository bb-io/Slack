using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
