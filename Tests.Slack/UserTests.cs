using Apps.Slack.Actions;
using Apps.Slack.Models.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Slack.Base;

namespace Tests.Slack
{
    [TestClass]
    public class UserTests :TestBase
    {
        [TestMethod]
        public async Task GetUsersTest()
        {
            var userActions = new UserActions(InvocationContext);
            var response = await userActions.GetUsers();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);

            Assert.IsNotNull(response);

        }

        [TestMethod]
        public async Task GetUserTest()
        {
            var userActions = new UserActions(InvocationContext);
            var response = await userActions.GetUserInfo(new GetUserInfoParameters { UserId= "U081DKASZB7" });
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);

            Assert.IsNotNull(response);

        }
    }
}
