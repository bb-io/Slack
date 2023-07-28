using Apps.Slack.Dtos;
using Apps.Slack.Models;
using Apps.Slack.Models.Requests;
using Apps.Slack.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using System.Collections.Generic;

namespace Apps.Slack
{
    [ActionList]
    public class Actions
    {
      
        [Action("Send message", Description = "Send a message to a Slack channel")]
        public PostMessageResponse PostMessage(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] PostMessageParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/chat.postMessage", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new PostMessageRequest { Channel = input.ChannelId, Text = input.Text });
            return client.ExecuteWithErrorHandling<PostMessageResponse>(request);
        }

        [Action("Get message files", Description = "Get message files by timestamp")]
        public GetMessageFilesResponse GetMessageFiles(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] GetMessageParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest($"/conversations.history?channel={input.ChannelId}&latest={input.Timestamp}&limit=1&inclusive=true", 
                Method.Get, authenticationCredentialsProviders);
            var message = client.Get<GetMessageDto<FileMessageDto>>(request).Messages.First();
            var files = new List<SlackFileDto>();
            if(message.Files != null)
            {
                files = message.Files.Select(f => new SlackFileDto() { Url = f.PrivateUrl, Filename = f.Name }).ToList();
            }
            return new GetMessageFilesResponse() { MessageText = message.Text, FilesUrls = files };
        }

        [Action("Delete message", Description = "Delete a message from Slack a Slack channel")]
        public void DeleteMessage(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] DeleteMessageParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/chat.delete", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new DeleteMessageRequest { Channel = input.ChannelId, Ts = input.Ts });
            client.ExecuteWithErrorHandling(request);
        }

        [Action("Add reaction", Description = "Add a reaction to a message")]
        public string AddReaction(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] AddReactionParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/reactions.add", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(
                new AddReactionRequest 
                {
                    Channel = input.ChannelId, 
                    Timestamp = input.Timestamp,
                    Name = input.Name
                });

            return client.ExecuteWithErrorHandling<string>(request);
        }

        [Action("Remove reaction", Description = "Remove a reaction from a message")]
        public void DeleteReaction(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] DeleteReactionParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/reactions.remove", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(
                new DeleteReactionRequest
                {
                    Channel = input.ChannelId,
                    Timestamp = input.Timestamp,
                    Name = input.Name
                });

            client.ExecuteWithErrorHandling(request);
        }

        [Action("Get reactions", Description = "Get reactions for a message")]
        public Message? GetReactions(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] GetReactionsParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/reactions.get", Method.Get, authenticationCredentialsProviders);
            request.AddParameter("channel", input.ChannelId);
            request.AddParameter("timestamp", input.Timestamp);
            return client.ExecuteWithErrorHandling<GetReactionsResponse>(request)?.Message;
        }

        [Action("Upload file", Description = "Upload a file to channel")]
        public FileInfoDto UploadFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] UploadFileDto input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/files.upload", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("channels", input.ChannelId);
            request.AddParameter("filename", input.FileName);
            request.AddFile("file", input.File, input.FileName);
            return client.ExecuteWithErrorHandling<UploadFileResponse>(request).File;
        }

        [Action("Get file info", Description = "Get information about a file")]
        public FileInfoDto? GetFileInfo(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] GetFileInfoParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/files.info", Method.Get, authenticationCredentialsProviders);
            request.AddParameter("file", input.FileId);
            return client.ExecuteWithErrorHandling<GetFileInfoResponse>(request)?.File;
        }

        [Action("Download file", Description = "Download file by url")]
        public DownloadFileResponse DownloadFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] DownloadFileRequest input)
        {
            var client = new SlackClient();
            var request = new SlackRequest(input.Url, Method.Get, authenticationCredentialsProviders);
            return new DownloadFileResponse() {
                File = client.Get(request).RawBytes
            };
        }

        [Action("Delete file", Description = "Delete a file")]
        public void DeleteFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] DeleteFileParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/files.delete", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("file", input.FileId);
            client.ExecuteWithErrorHandling(request);
        }

        [Action("Get all users", Description = "Get all users in a Slack team")]
        public GetUsersResponse? GetUsers(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/users.list", Method.Get, authenticationCredentialsProviders);
            return client.ExecuteWithErrorHandling<GetUsersResponse>(request);
        }

        [Action("Get user information", Description = "Get information about a user")]
        public UserInfoDto? GetUserInfo(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] GetUserInfoParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/users.info", Method.Get, authenticationCredentialsProviders);
            request.AddParameter("user", input.UserId);
            return client.ExecuteWithErrorHandling<GetUserInfoResponse>(request)?.User;
        }

        [Action("Get user by email", Description = "Find a user with an email address")]
        public UserInfoDto? GetUserByEmail(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] GetUserByEmailParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/users.lookupByEmail", Method.Get, authenticationCredentialsProviders);
            request.AddParameter("email", input.Email);
            return client.ExecuteWithErrorHandling<GetUserByEmailResponse>(request)?.User;
        }

        [Action("Get user profile", Description = "Retrieve a user's profile information, including their custom status")]
        public UserProfileDto? GetUserProfile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] GetUserProfileParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/users.profile.get", Method.Get, authenticationCredentialsProviders);
            request.AddParameter("user", input.UserId);
            return client.ExecuteWithErrorHandling<GetUserProfileResponse>(request)?.Profile;
        }
    }
}