using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack
{
    public class ApplicationConstants
    {
        public const string ClientId = "#{SLACK_CLIENT_ID}#";

        public const string Scope = "#{SLACK_SCOPE}#";

        public const string ClientSecret = "#{SLACK_SECRET}#";

        public const string BlackbirdToken = "#{SLACK_BLACKBIRD_TOKEN}#"; // bridge validates this token
    }
}
