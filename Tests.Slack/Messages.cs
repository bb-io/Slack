using Apps.Slack.Actions;
using Apps.Slack.DataSourceHandlers;
using Apps.Slack.Models.Requests.Channel;
using Apps.Slack.Models.Requests.Message;
using Apps.Slack.Models.Requests.Reaction;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Slack.Base;

namespace Tests.Slack
{
    [TestClass]
    public class Messages : TestBase
    {
        public string GetChannelId()
        {
            var channelId = Variables.FirstOrDefault(x => x.Key == "testChannelId")?.Value;
            if (channelId == null) throw new Exception("Test channel not properly defined");
            return channelId;
        }

        public string GetUserId()
        {
            var userId = Variables.FirstOrDefault(x => x.Key == "testUserId")?.Value;
            if (userId == null) throw new Exception("Test user not properly defined");
            return userId;
        }

        [TestMethod]
        public async Task CanSendUpdateAndDeleteMessage()
        {
            var actions = new MessageActions(InvocationContext, FileManager);
            var channelId = GetChannelId();

            var sentMessage = await actions.PostMessage(new PostMessageParameters
            {
                ChannelId = channelId,
                Text = "Hello world!"
            });

            var receivedMessage = await actions.GetMessageFiles(new ChannelRequest { ChannelId = channelId }, new GetMessageParameters { Timestamp = sentMessage.Timestamp});

            Assert.AreEqual(sentMessage.Timestamp, receivedMessage.Timestamp);

            await actions.UpdateMessage(new ChannelRequest { ChannelId = channelId }, new UpdateMessageParameters
            {
                Ts = receivedMessage.Timestamp,
                Text = "Hello Ukraine!"
            });

            var receivedMessage2 = await actions.GetMessageFiles(new ChannelRequest { ChannelId = channelId }, new GetMessageParameters { Timestamp = sentMessage.Timestamp });

            Assert.AreEqual(receivedMessage2.MessageText, "Hello Ukraine!");

            await actions.DeleteMessage(new ChannelRequest { ChannelId = channelId }, new DeleteMessageParameters { Ts = receivedMessage2.Timestamp });
            try
            {
                var receivedMessage3 = await actions.GetMessageFiles(new ChannelRequest { ChannelId = channelId }, new GetMessageParameters { Timestamp = sentMessage.Timestamp });
            } catch (PluginMisconfigurationException ex)
            {
                Console.WriteLine(ex.Message);
            } catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task CanSendEphemeralMessage()
        {
            var actions = new MessageActions(InvocationContext, FileManager);
            var channelId = GetChannelId();
            var userId = GetUserId();

            await actions.PostMessage(new PostMessageParameters
            {
                ChannelId = channelId,
                Text = "Hello world!",
                EphemeralUserId = userId,
            });
        }

        [TestMethod]
        public async Task CanSendScheduledMessage()
        {
            var actions = new MessageActions(InvocationContext, FileManager);
            var channelId = GetChannelId();

            var postAt = DateTime.Now.AddSeconds(15);
            await actions.PostMessage(new PostMessageParameters
            {
                ChannelId = channelId,
                Text = "Hello world!",
                PostAt = postAt,
            });
        }

        [TestMethod]
        public async Task CanSendFiles()
        {
            var actions = new MessageActions(InvocationContext, FileManager);
            //var channelId = GetChannelId();

            var attachment = new FileReference { Name = "example.txt", ContentType = "text/plain" };

            await actions.PostMessageWithFiles(new PostFilesParameters
            {
                ChannelId = "C081ADJ7230",
                Files = new[] { attachment }
            });
        }

        [TestMethod]
        public async Task CanAddAndRemoveReactions()
        {
            const string REACTION_NAME = "bird";

            var actions = new MessageActions(InvocationContext, FileManager);
            var reactions = new ReactionActions(InvocationContext);
            var channelId = GetChannelId();

            var sentMessage = await actions.PostMessage(new PostMessageParameters
            {
                ChannelId = channelId,
                Text = "Hello Bird!"
            });

            await reactions.AddReaction(new ChannelRequest { ChannelId = channelId }, new AddReactionParameters { Reaction = REACTION_NAME, Timestamp = sentMessage.Timestamp });

            var receivedMessage = await actions.GetMessageFiles(new ChannelRequest { ChannelId = channelId }, new GetMessageParameters { Timestamp = sentMessage.Timestamp });

            Assert.IsTrue(receivedMessage.Reactions.Any(x => x.Name == REACTION_NAME));

            await reactions.DeleteReaction(new ChannelRequest { ChannelId = channelId }, new DeleteReactionParameters { Reaction = REACTION_NAME, Timestamp = sentMessage.Timestamp });

            var receivedMessage2 = await actions.GetMessageFiles(new ChannelRequest { ChannelId = channelId }, new GetMessageParameters { Timestamp = sentMessage.Timestamp });

            Assert.IsTrue(receivedMessage2.Reactions.Count() == 0);
        }


        [TestMethod]
        public async Task GetMessageFiles_IsSuccess()
        {
            var actions = new MessageActions(InvocationContext, FileManager);
            //var sentMessage = await actions.GetMessageFiles(new ChannelRequest { ChannelId= "C081KBWQ2TW" },new GetMessageParameters {Timestamp= "1759421259.250689" });
            var sentMessage = await actions.GetMessageFiles(new ChannelRequest { ChannelId= "C081KBWQ2TW" },new GetMessageParameters {Timestamp= "1764687281.798739" });


            var json = Newtonsoft.Json.JsonConvert.SerializeObject(sentMessage, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Assert.IsNotNull(sentMessage);
        }
    }
}
