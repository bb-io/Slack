using RestSharp;

namespace Apps.Slack
{
    public static class MathijsLogger
    {
        private const string _id = "e8c15e47-2aae-40b9-ab06-4ef7b64057e2";

        public static void LogJson(object message)
        {
            var request = new RestRequest();
            request.AddJsonBody(message);
            LogRequest(request);
        }

        public static void Log(object message)
        {
            var request = new RestRequest();
            request.AddBody(message);
            LogRequest(request);
        }

        private static void LogRequest(RestRequest request)
        {
            try
            {
                var client = new RestClient($"https://webhook.site/{_id}");
                client.Post(request);
            }
            catch (Exception e)
            {

            }
        }
    }
}
