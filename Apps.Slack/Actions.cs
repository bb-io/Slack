using Apps.Slack.Dtos;
using Apps.Slack.Models;
using Apps.Slack.Models.Requests;
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
        public void PostMessage(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] PostMessageParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/chat.postMessage", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new PostMessageRequest { Channel = input.ChannelId, Text = input.Text });
            client.Post(request);
        }

        [Action("Delete a message from Slack", Description = "Delete a message from Slack")]
        public void DeleteMessage(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] DeleteMessageParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/chat.delete", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new DeleteMessageRequest { Channel = input.ChannelId, Ts = input.Ts });
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

        //[Action("Get a file info", Description = "Get information about a file")]
        //public void GetFileInfo(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] GetFileInfoParameters input)
        //{
        //    var client = new SlackClient();
        //    var request = new SlackRequest("/files.info", Method.Get, authenticationCredentialsProviders);
        //    request.AddParameter("file", input.FileId);
        //    client.Get(request);
        //}

        [Action("Delete a file", Description = "Delete a file")]
        public void DeleteFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] DeleteFileParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/files.delete", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("file", input.FileId);
            client.Post(request);
        }
    }
}