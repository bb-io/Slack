using Apps.Slack.Models;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Slack
{
    [ActionList]
    public class Actions
    {
      
        [Action( "Post message to slack", Description = "Post message to slack")]
        public void PostMessage(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] MessageParameters input)
        {
            var client = new SlackClient();
            var request = new RestRequest("/chat.postMessage", Method.Post);
            var authenticationCredentialsProvider = GetAuthenticationCredentialsProvider(authenticationCredentialsProviders);

            request.AddHeader("Authorization", $"Bearer {authenticationCredentialsProvider.Value}");
            request.AddJsonBody(new MessageRequest { Channel = input.ChannelId, Text = input.Text });
            client.Post(request);
        }
        
        [Action("Upload file", Description = "Upload file to channel")]
        public void UploadFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] UploadFileDto input)
        {
            var client = new SlackClient();
            var request = new RestRequest("/files.upload", Method.Post);
            var authenticationCredentialsProvider = GetAuthenticationCredentialsProvider(authenticationCredentialsProviders);

            request.AddHeader("Authorization", $"Bearer {authenticationCredentialsProvider.Value}");
            request.AddParameter("channels", input.ChannelId);
            request.AddParameter("filename", input.FileName);
            request.AddFile("file", input.File, input.FileName, input.FileType);
            client.Post(request);
        }

        private AuthenticationCredentialsProvider GetAuthenticationCredentialsProvider(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return authenticationCredentialsProviders.First(p => p.KeyName == "token");
        }
    }
}