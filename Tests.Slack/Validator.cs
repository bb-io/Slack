using Apps.Slack.Connections;
using Blackbird.Applications.Sdk.Common.Authentication;
using Tests.Slack.Base;
using FluentAssertions;

namespace Tests.Slack
{
    [TestClass]
    public class Validator : TestBase
    {
        [TestMethod]
        public async Task ValidatesCorrectConnection()
        {
            var validator = new ConnectionPingChecker();

            var result = await validator.ValidateConnection(Creds, CancellationToken.None);
            result.IsValid.Should().Be(true);
            Console.WriteLine(result.Message);
        }

        [TestMethod]
        public async Task DoesNotValidateIncorrectConnection()
        {
            var validator = new ConnectionPingChecker();

            var newCredentials = Creds.Select(x => new AuthenticationCredentialsProvider(x.KeyName, x.Value + "_incorrect"));
            var result = await validator.ValidateConnection(newCredentials, CancellationToken.None);
            result.IsValid.Should().Be(false);
            Console.WriteLine(result.Message);
        }
    }
}
