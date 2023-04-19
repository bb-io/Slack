using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack
{
    public class SlackApplication : IApplication
    {
        public string Name
        {
            get => "Slack";
            set { }
        }

        public T GetInstance<T>()
        {
            throw new NotImplementedException();
        }
    }
}
