# Blackbird.io Slack

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->

Slack is a messaging app for businesses that improves communication, teamwork, and decision-making. It allows people to collaborate easily, work on their own time, and share information in dedicated chat spaces.

## Before setting up

Before you can connect you need to make sure that you have a Slack account and you are part of a specific workspace.

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

1. Navigate to apps and search for Slack. If you cannot find Slack then click _Add App_ in the top right corner, select Slack and add the app to your Blackbird environment.
2. Click _Add Connection_.
3. Name your connection for future reference e.g. 'My organization'. 
4. Click _Authorize connection_. 
5. Follow the instructions that Slack gives you, allowing Blackbird to access the selected workspace. 
6. When you return to Blackbird, confirm that the connection has appeared and the status is _Connected_.

![Connecting](image/README/connecting.png)

## Actions

### Channel

- **Send message** sends a message to a Slack channel.
- **Send message in thread** sends a reply in response to a message from a specific channel.
- **Get message files** returns files attached to a message.
- **Delete message**.
- **Add reaction** adds a reaction to a message.
- **Remove reaction** removes a reaction from a message.
- **Get reactions** lists all reactions for a single message.
- **Upload file** uploads a file to a channel.
- **Get file info**.
- **Download file** downloads file by url.
- **Delete file**.
- **Get all channels**.

### Users

- **Get all users** retrieves a list of users in a Slack team.
- **Get user information**.
- **Get user by email**.
- **Get user profile**.
- **Get team**.

## Events

- **On channel message** and **On channel files message** are triggered when a new message is sent to a channel and when a new message with attached files is sent to a channel, respectively. This events have a parameter _Trigger on message replies_ which is _False_ by default. If you want your bird to trigger on channel messages and message replies, set this parameter to _True_. If you use one of the **On channel message** or **On channel files message** with **Send message in thread** in a single flow, you should set _Trigger on message replies_ to _False_ or leave it unspecified to avoid an infinite loop. 
- **On app mentioned** is triggered when an app is mentioned.
- **On member joined channel**.
- **On message reaction**.

## Example

![Example](image/README/example.png)

Here, whenever a new message with attachments is sent, we download the files, upload them to Google Drive and add new rows to Google Sheets table with information about the uploaded files. 

<!-- end docs -->
