using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.Slack.Models.Responses
{
    public class GenericResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}
