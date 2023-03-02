using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Models
{
    public class MessageRequest
    {
        public string Text { get; set; }
        public string Channel { get; set; }
    }
}
