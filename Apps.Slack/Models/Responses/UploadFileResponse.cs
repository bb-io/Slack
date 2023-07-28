using Apps.Slack.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.Slack.Models.Responses
{
    public class UploadFileResponse
    {
        [JsonPropertyName("file")]
        public FileInfoDto File { get; set; }
    }
}
