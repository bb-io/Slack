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
      
        [Action( "Post a message to Slack", Description = "Post a message to slack")]
        public void PostMessage(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] MessageParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/chat.postMessage", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new MessageRequest { Channel = input.ChannelId, Text = input.Text });
            client.Post(request);
        }
        
        [Action("Upload a file", Description = "Upload a file to channel")]
        public void UploadFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] UploadFileDto input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/files.upload", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("channels", input.ChannelId);
            request.AddParameter("filename", input.FileName);
            request.AddFile("file", input.File, input.FileName, input.FileType);
            client.Post(request);
        }
    }
}