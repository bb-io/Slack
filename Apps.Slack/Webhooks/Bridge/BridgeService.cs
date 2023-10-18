using Apps.Slack.Api;
using Apps.Slack.Models.Responses.Team;
using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Slack.Webhooks.Bridge;

public class BridgeService
{
    private string TeamId { get; set; }

    public BridgeService(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        var client = new SlackClient();

        var request = new SlackRequest("/team.info", Method.Get, authenticationCredentialsProviders);
        var team = client.Get<TeamInfoResponse>(request);

        if (team == null) throw new Exception("Could not fetch team details");

        TeamId = team.Team.Id;
    }

    public void Subscribe(string @event, string url)
    {
        var client = new RestClient(ApplicationConstants.BridgeServiceUrl);

        var request = new RestRequest($"/{TeamId}/{@event}", Method.Post)
            .AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken)
            .AddBody(url);

        client.Execute(request);
    }

    public void Unsubscribe(string @event, string url)
    {
        var client = new RestClient(ApplicationConstants.BridgeServiceUrl);

        var requestGet = new RestRequest($"/{TeamId}/{@event}")
            .AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);

        var webhooks = client.Get<List<BridgeGetResponse>>(requestGet);
        var webhook = webhooks.FirstOrDefault(w => w.Value == url);

        if (webhook is null) return;

        var requestDelete = new RestRequest($"/{TeamId}/{@event}/{webhook.Id}", Method.Delete)
            .AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);

        client.Delete(requestDelete);
    }
}