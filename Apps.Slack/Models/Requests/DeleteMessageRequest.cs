﻿namespace Apps.Slack.Models.Requests
{
    public class DeleteMessageRequest
    {
        public string Channel { get; set; }
        public string Ts { get; set; }
    }
}
