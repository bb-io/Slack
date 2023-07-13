using Apps.Slack.Models.Responses;
using Apps.Slack.Webhooks.Payload;
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
            request.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
            request.AddBody(url);
            client.Execute(request);
        }

        public void Unsubscribe(string _event, string url)
        {
            var client = new RestClient(ApplicationConstants.BridgeServiceUrl);
            var requestGet = new RestRequest($"/{TeamId}/{_event}", Method.Get);
            requestGet.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
            var webhooks = client.Get<List<BridgeGetResponse>>(requestGet);
            var webhook = webhooks.FirstOrDefault(w => w.Value == url);

            var requestDelete = new RestRequest($"/{TeamId}/{_event}/{webhook.Id}", Method.Delete);
            requestDelete.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
            client.Delete(requestDelete);
        }
    }
}
