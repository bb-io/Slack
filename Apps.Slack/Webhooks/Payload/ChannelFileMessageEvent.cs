using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Webhooks.Payload;

public class ChannelFileMessageEvent
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("files")]
    public List<MessageFile> Files { get; set; }

    [JsonPropertyName("user")]
    public string User { get; set; }

    [JsonPropertyName("upload")]
    public bool Upload { get; set; }

    [Display("Display as bot")]
    [JsonPropertyName("display_as_bot")]
    public bool DisplayAsBot { get; set; }

    [Display("Bot ID")]
    [JsonPropertyName("bot_id")]
    public object BotId { get; set; }

    [Display("Timestamp")]
    [JsonPropertyName("ts")]
    public string Ts { get; set; }

    [Display("Channel ID")]
    [JsonPropertyName("channel")]
    public string Channel { get; set; }

    [Display("Event timestamp")]
    [JsonPropertyName("event_ts")]
    public string EventTs { get; set; }

    [Display("Channel type")]
    [JsonPropertyName("channel_type")]
    public string ChannelType { get; set; }
        
    [JsonPropertyName("thread_ts")]
    [Display("Thread timestamp")]
    public string? ThreadTs { get; set; }
}

public class MessageFile
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("mimetype")]
    public string Mimetype { get; set; }

    [JsonPropertyName("filetype")]
    public string Filetype { get; set; }

    [JsonPropertyName("pretty_type")]
    public string PrettyType { get; set; }

    [JsonPropertyName("user")]
    public string User { get; set; }

    [JsonPropertyName("editable")]
    public bool Editable { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("mode")]
    public string Mode { get; set; }

    [Display("Is external")]
    [JsonPropertyName("is_external")]
    public bool IsExternal { get; set; }

    [Display("External type")]
    [JsonPropertyName("external_type")]
    public string ExternalType { get; set; }

    [Display("Is public")]
    [JsonPropertyName("is_public")]
    public bool IsPublic { get; set; }

    [Display("Public url shared")]
    [JsonPropertyName("public_url_shared")]
    public bool PublicUrlShared { get; set; }

    [Display("Display as bot")]
    [JsonPropertyName("display_as_bot")]
    public bool DisplayAsBot { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [Display("Url private")]
    [JsonPropertyName("url_private")]
    public string UrlPrivate { get; set; }

    [Display("Url private download")]
    [JsonPropertyName("url_private_download")]
    public string UrlPrivateDownload { get; set; }

    [Display("Thumb 64")]
    [JsonPropertyName("thumb_64")]
    public string Thumb64 { get; set; }

    [Display("Thumb 80")]
    [JsonPropertyName("thumb_80")]
    public string Thumb80 { get; set; }

    [Display("Thumb 360")]
    [JsonPropertyName("thumb_360")]
    public string Thumb360 { get; set; }

    [Display("Thumb 360 width")]
    [JsonPropertyName("thumb_360_w")]
    public int Thumb360W { get; set; }

    [Display("Thumb 360 height")]
    [JsonPropertyName("thumb_360_h")]
    public int Thumb360H { get; set; }

    [Display("Thumb 480")]
    [JsonPropertyName("thumb_480")]
    public string Thumb480 { get; set; }

    [Display("Thumb 480 width")]
    [JsonPropertyName("thumb_480_w")]
    public int Thumb480W { get; set; }

    [Display("Thumb 480 height")]
    [JsonPropertyName("thumb_480_h")]
    public int Thumb480H { get; set; }

    [Display("Thumb 160")]
    [JsonPropertyName("thumb_160")]
    public string Thumb160 { get; set; }

    [JsonPropertyName("image_exif_rotation")]
    public int ImageExifRotation { get; set; }

    [Display("Original width")]
    [JsonPropertyName("original_w")]
    public int OriginalW { get; set; }

    [Display("Original height")]
    [JsonPropertyName("original_h")]
    public int OriginalH { get; set; }

    [JsonPropertyName("pjpeg")]
    public string Pjpeg { get; set; }

    [JsonPropertyName("permalink")]
    public string Permalink { get; set; }

    [Display("Permalink public")]
    [JsonPropertyName("permalink_public")]
    public string PermalinkPublic { get; set; }

    [Display("Has rich preview")]
    [JsonPropertyName("has_rich_preview")]
    public bool HasRichPreview { get; set; }
}