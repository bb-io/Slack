using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.Slack.Models.Responses
{
    public class PostMessageResponse
    {
        [Display("Channel ID")]
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [Display("Message timestamp")]
        [JsonPropertyName("ts")]
        public string Timestamp { get; set; }
    }
}
