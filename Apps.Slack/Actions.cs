using Apps.Slack.Models;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Slack
{
    [ActionList]
    public class Actions
    {
        [Action]
        public void PostMessage(AuthenticationCredentialsProvider authenticationCredentialsProvider, [ActionParameter] MessageParameters input)
        {
            var client = new SlackClient();
            var request = new RestRequest("/chat.postMessage", Method.Post);
            request.AddHeader("Authorization", $"Bearer {authenticationCredentialsProvider.Value}");
            request.AddJsonBody(new MessageRequest { Channel = input.ChannelId, Text = input.Text });
            var response = client.Post(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"{response.StatusCode}: {response.ErrorMessage}")
            }
        }
    }
}