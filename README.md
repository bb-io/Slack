# Blackbird.io Slack

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->

Slack is a messaging app for businesses that improves communication, teamwork, and decision-making. It allows people to collaborate easily, work on their own time, and share information in dedicated chat spaces.

## Before setting up

Before you can connect you need to make sure that you have a Slack account and you are part of a specific workspace. You need to be an Slack admin or have permission to connect external applications to your Slack channel. You can also [invite your Slack admin to Blackbird](https://docs.blackbird.io/concepts/nests/#users) in order for them to authorize the connection. 

### Enable webhooks

If you want to use Slack webhooks, you'll need to add Blackbird bot to the channels you're interested in after you've created a connection. There are two ways to do this.

The first way:

- Select a channel.
- Send a message with _@Blackbird_ content.
- Click _Add to channel_.
- Do the same for other channels you're interested in.

![Adding Blackbird to channel](image/README/add_to_channel.png)

The second way:

- Go to the channel you selected during connection creation.
- Find _added an integration to this channel: Blackbird_ message.
- Click on _Blackbird_ -> _Add this app to a channel..._ -> select a channel from dropdown.
- Do the same for other channels you're interested in.

![Adding Blackbird to channel](image/README/add_to_channel2.png)

## Connecting

1. Navigate to Apps, and identify the **Slack** app. You can use search to find it.
2. Click _Add Connection_.
3. Name your connection for future reference e.g. 'My organization'.
4. Click _Authorize connection_.
5. Follow the instructions that Slack gives you, allowing Blackbird to access the selected workspace.
6. When you return to Blackbird, confirm that the connection has appeared and the status is _Connected_.

![Connecting](image/README/connecting.png)


## Actions


> Note: For correct data handlers functioning, the Blackbird app has to be added to the channels that you want to use in your workflows.


### Messages

- **Send message** Sends a message to a channel or user. Requires scopes: chat:write, chat:write.customize, users:read Advanced settings:
  - **Thread timestamp**: If you are sending a message as part of a thread, set the timestamp of the primary message.
  - **Schedule at**: If used, creates a scheduled message.
  - **Ephemeral user ID**: If set, the message will only be visible to this user.
  - **Bot's username**: If not set, the bot's default username will be used.
  - **Send as user**: Send a message as a user.
- **Send files** Send files to a channel. Requires scope: files:write Advanced settings:
  - **Message**: Message text to send with the files.
- **Get message** Gets message metadata, text, reactions, and attachments. Requires scopes: channels:history, groups:history, files:read, reactions:read
- **Update message** Updates a specific message in a channel. Requires scope: chat:write Advanced settings:
  - **Message text**: New text for the message.
  - **Reply broadcast**: Select whether to broadcast the reply to the channel.
  - **Link names**: Select whether to parse and link @mentions and channel names.
  - **Parse**: Choose how message formatting is parsed.
- **Delete message** Deletes a message from a channel. Requires scopes: chat:write, channels:manage

### Reactions

- **Add reaction** Adds a reaction to a message. Requires scope: reactions:write
- **Remove reaction** Removes a reaction from a message. Requires scope: reactions:write

### Users

- **Search users** Searches all users in a workspace. Requires scopes: users:read, users.profile:read
- **Get user** Gets information about a user. Requires scopes: users:read, users.profile:read
- **Find user by email** Finds a user using an email address. Requires scopes: users:read.email, users:read, users.profile:read

## Events

### Messages

- **On app mentioned** Triggers when the app is mentioned. Requires scopes: app_mentions:read, channels:history, groups:history, files:read, reactions:read Advanced settings:
  - **Thread timestamp**: To filter messages only if they are part of a thread, use the message timestamp of the top thread message.
- **On message** Triggers whenever a new message is posted. Requires scopes: channels:history, groups:history, files:read, reactions:read Advanced settings:
  - **Message reply handling**: Choose whether to trigger on non-replies, only replies, or both.
  - **Trigger only when message has files**: Select whether to trigger only when messages include file attachments.
- **On reaction added** Triggers when someone adds a reaction to a message. Requires scopes: reactions:read, channels:history, groups:history, files:read Advanced settings:
  - **Reactions**: Filter to specific reactions.
  - **Message timestamp**: Filter on a specific message.

### Members

- **On member joined channel** Triggers when a member joins a channel. Requires scopes: channels:read, groups:read

## Example

![Example](image/README/1734624290730.png)

In this example, we respond to reactions on Slack messages. These reactions will correspond to country flags. When triggered, the Bird will translate all the files the reactionw as added to into the requested language and respond with the translated files in a thread reply.

## Missing features

Slack is a huge app with a lot of features. If any of these features are particularly interesting to you, let us know!

## Feedback

Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->
