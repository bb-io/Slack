using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack
{
    public class SlackRequest : RestRequest
    {
        public SlackRequest(string endpoint, Method method, IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) : base(endpoint, method)
        {
            var token = authenticationCredentialsProviders.First(p => p.KeyName == "token").Value;
            this.AddHeader("Authorization", $"Bearer {token}");
        }
    }
}
