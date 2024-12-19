using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Slack.Base;

namespace Tests.Slack
{
    [TestClass]
    public class DataSourceHandlers : TestBase
    {
        [TestMethod]
        public async Task ChannelHandler_ShouldReturnItems()
        {
            var handler = new ChannelHandler(InvocationContext);
            var result = await TestDataHandler(handler);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public async Task ChannelUserHandler_ShouldReturnItems()
        {
            var handler = new ChannelUserHandler(InvocationContext);
            var result = await TestDataHandler(handler);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public async Task UserHandler_ShouldReturnItems()
        {
            var handler = new UserHandler(InvocationContext);
            var result = await TestDataHandler(handler);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }


        private async Task<IEnumerable<DataSourceItem>> TestDataHandler(IAsyncDataSourceItemHandler dataSourceItemHandler)
        {
            var result = await dataSourceItemHandler.GetDataAsync(new(), default);
            foreach (var item in result ?? [])
            {
                Console.WriteLine($"{item.Value}: {item.DisplayName}");
            }
            return result;
        }
    }
}
