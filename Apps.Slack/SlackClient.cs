using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack
{
    public class SlackClient : RestClient
    {
        public SlackClient() : base(new RestClientOptions() { ThrowOnAnyError = true, BaseUrl = new Uri("https://slack.com/api") }) { }
    }
}
