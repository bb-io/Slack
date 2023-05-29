using Apps.Slack.Models.Responses;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Bridge
{
    public class BridgeService
    {
        internal string TeamId { get; set; }

        public BridgeService(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/team.info", Method.Get, authenticationCredentialsProviders);
            var team = client.Get<TeamInfoResponse>(request);

            if (team == null) throw new Exception("Could not fetch team details");
            TeamId = team.Team.Id;
        }
        public void Subscribe(string _event, string url)
        {
            var client = new RestClient(ApplicationConstants.BridgeServiceUrl);
            var request = new RestRequest($"/{TeamId}/{_event}", Method.Post);
            request.AddBody(url);
            client.Execute(request);
        }

        public void Unsubscribe(string _event)
        {
            var client = new RestClient(ApplicationConstants.BridgeServiceUrl);
            var request = new RestRequest($"/{TeamId}/{_event}", Method.Delete);
            client.Execute(request);
        }
    }
}
