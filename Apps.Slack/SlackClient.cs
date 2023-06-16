using Apps.Slack.Models.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Apps.Slack
{
    public class SlackClient : RestClient
    {
        public SlackClient() : base(new RestClientOptions() { ThrowOnAnyError = true, BaseUrl = new Uri("https://slack.com/api") }) { }

        public void ExecuteWithErrorHandling(SlackRequest request)
        {
            var response = this.Execute(request);
            var genericResponse = JsonSerializer.Deserialize<GenericResponse>(response.Content);
            if (!string.IsNullOrEmpty(genericResponse?.Error))
            {
                throw new Exception($"Error: {genericResponse.Error}");
            }
        }

        public T ExecuteWithErrorHandling<T>(SlackRequest request)
        {
            var response = this.Execute(request);
            var genericResponse = JsonSerializer.Deserialize<GenericResponse>(response.Content);
            if (!string.IsNullOrEmpty(genericResponse?.Error))
            {
                throw new Exception($"Error: {genericResponse.Error}");
            }

            return JsonSerializer.Deserialize<T>(response.Content);
        }
    }
}
