using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Models.Responses
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class TeamInfoResponse
    {
        public bool Ok { get; set; }
        public Team Team { get; set; }
    }
}
