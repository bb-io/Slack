using Newtonsoft.Json;
using RestSharp;

namespace Apps.Slack.Extensions;

public static class RestRequestExtensions
{
    public static RestRequest WithJsonBody(this RestRequest request, object body,
        JsonSerializerSettings? serializerSettings = null)
        => request.AddJsonBody(JsonConvert.SerializeObject(body, serializerSettings));
}