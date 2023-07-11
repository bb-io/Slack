using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack
{
    public class ApplicationConstants
    {
        public const string BridgeServiceUrl = "https://bridge.blackbird.io/api/slack";
        public const string ClientId = "5287240876960.5444364908193";

        public const string RedirectUri = "https://dev.blackbird.io/api-rest/connections/AuthorizationCode";

        public const string Scope = "app_mentions:read,channels:history,channels:read,groups:read,mpim:read,reactions:read,users:read,channels:join,chat:write.public,chat:write,chat:write.customize,commands,emoji:read,files:read,files:write,incoming-webhook,links:read,reactions:write,users:read.email,users:write,team:read";

        public const string ClientSecret = "d332e06086fb84c6eb001150cd28e848";

        public const string BlackbirdToken = "dcdcd7da-e4f6-4116-8307-63cfc2b92fc2"; // bridge validates this token
    }
}
