namespace Apps.Slack.Extensions;

public static class InputsExtensions
{
    public static string GetChannelId(this (string? channelId, string? manualChannelId) tuple)
    {
        if (!(tuple.channelId == null ^ tuple.manualChannelId == null))
            throw new("You should specify one value: Channel ID or Manual channel ID");

        return tuple.channelId ?? tuple.manualChannelId;
    }
}