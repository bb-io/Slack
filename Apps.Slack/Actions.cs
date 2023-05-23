using Apps.Slack.Dtos;
using Apps.Slack.Models;
using Apps.Slack.Models.Requests;
using Apps.Slack.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Slack
{
    [ActionList]
    public class Actions
    {
      
        [Action( "Post a message", Description = "Post a message to a Slack channel")]
        public void PostMessage(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] PostMessageParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/chat.postMessage", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new PostMessageRequest { Channel = input.ChannelId, Text = input.Text });
            client.Post(request);
        }

        [Action("Delete a message", Description = "Delete a message from Slack a Slack channel")]
        public void DeleteMessage(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] DeleteMessageParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/chat.delete", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new DeleteMessageRequest { Channel = input.ChannelId, Ts = input.Ts });
            client.Post(request);
        }

        [Action("Add a reaction to a message", Description = "Add a reaction to a message")]
        public void AddReaction(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] AddReactionParameters input)
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

            client.Post(request);
        }

        [Action("Remove a reaction from a message", Description = "Remove a reaction from a message")]
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

            client.Post(request);
        }

        [Action("Get reactions for a message", Description = "Get reactions for a message")]
        public Message? GetReactions(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] GetReactionsParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/reactions.get", Method.Get, authenticationCredentialsProviders);
            request.AddParameter("channel", input.ChannelId);
            request.AddParameter("timestamp", input.Timestamp);
            return client.Get<GetReactionsResponse>(request)?.Message;
        }

        [Action("Upload a file", Description = "Upload a file to channel")]
        public void UploadFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] UploadFileDto input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/files.upload", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("channels", input.ChannelId);
            request.AddParameter("filename", input.FileName);
            request.AddFile("file", input.File, input.FileName);
            client.Post(request);
        }

        [Action("Get a file info", Description = "Get information about a file")]
        public FileInfoDto? GetFileInfo(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] GetFileInfoParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/files.info", Method.Get, authenticationCredentialsProviders);
            request.AddParameter("file", input.FileId);
            return client.Get<GetFileInfoResponse>(request)?.File;
        }

        [Action("Delete a file", Description = "Delete a file")]
        public void DeleteFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] DeleteFileParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/files.delete", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("file", input.FileId);
            client.Post(request);
        }

        [Action("Create a reminder", Description = "Create a reminder")]
        public void AddReminder(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] AddReminderParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/reminders.add", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(
                new AddReminderRequest
                {
                    Text = input.Text,
                    Time = input.Time,
                    User = input.UserId
                });

            client.Post(request);
        }

        [Action("Mark a reminder as complete", Description = "Mark a reminder as complete")]
        public void CompleteReminder(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] CompleteReminderParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/reminders.complete", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("reminder", input.ReminderId);
            client.Post(request);
        }

        [Action("Delete a reminder", Description = "Delete a reminder")]
        public void DeleteReminder(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] DeleteReminderParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/reminders.delete", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("reminder", input.ReminderId);
            client.Post(request);
        }

        [Action("Get information about a reminder", Description = "Get information about a reminder")]
        public ReminderInfoDto? GetReminderInfo(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] GetReminderInfoParameters input)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/reminders.info", Method.Get, authenticationCredentialsProviders);
            request.AddParameter("reminder", input.ReminderId);
            return client.Get<GetReminderInfoResponse>(request)?.Reminder;
        }

        [Action("Get all reminders created by or for a given user", Description = "Get all reminders created by or for a given user")]
        public ReminderInfoDto[]? GetReminders(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            var client = new SlackClient();
            var request = new SlackRequest("/reminders.list", Method.Get, authenticationCredentialsProviders);
            return client.Get<GetRemindersResponse>(request)?.Reminders;
        }

        
    }
}