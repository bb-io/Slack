using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Webhooks.Payload;

public class ChannelFileMessageEvent
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("files")]
    public List<MessageFile> Files { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("upload")]
    public bool Upload { get; set; }

    [Display("Display as bot")]
    [JsonProperty("display_as_bot")]
    public bool DisplayAsBot { get; set; }

    [Display("Bot ID")]
    [JsonProperty("bot_id")]
    public object BotId { get; set; }

    [Display("Timestamp")]
    [JsonProperty("ts")]
    public string Ts { get; set; }

    [Display("Channel ID")]
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [Display("Event timestamp")]
    [JsonProperty("event_ts")]
    public string EventTs { get; set; }

    [Display("Channel type")]
    [JsonProperty("channel_type")]
    public string ChannelType { get; set; }
        
    [JsonProperty("thread_ts")]
    [Display("Thread timestamp")]
    public string? ThreadTs { get; set; }
}

public class MessageFile
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("created")]
    public int Created { get; set; }

    [JsonProperty("timestamp")]
    public int Timestamp { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("mimetype")]
    public string Mimetype { get; set; }

    [JsonProperty("filetype")]
    public string Filetype { get; set; }

    [JsonProperty("pretty_type")]
    public string PrettyType { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("editable")]
    public bool Editable { get; set; }

    [JsonProperty("size")]
    public int Size { get; set; }

    [JsonProperty("mode")]
    public string Mode { get; set; }

    [Display("Is external")]
    [JsonProperty("is_external")]
    public bool IsExternal { get; set; }

    [Display("External type")]
    [JsonProperty("external_type")]
    public string ExternalType { get; set; }

    [Display("Is public")]
    [JsonProperty("is_public")]
    public bool IsPublic { get; set; }

    [Display("Public url shared")]
    [JsonProperty("public_url_shared")]
    public bool PublicUrlShared { get; set; }

    [Display("Display as bot")]
    [JsonProperty("display_as_bot")]
    public bool DisplayAsBot { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [Display("Url private")]
    [JsonProperty("url_private")]
    public string UrlPrivate { get; set; }

    [Display("Url private download")]
    [JsonProperty("url_private_download")]
    public string UrlPrivateDownload { get; set; }

    [Display("Thumb 64")]
    [JsonProperty("thumb_64")]
    public string Thumb64 { get; set; }

    [Display("Thumb 80")]
    [JsonProperty("thumb_80")]
    public string Thumb80 { get; set; }

    [Display("Thumb 360")]
    [JsonProperty("thumb_360")]
    public string Thumb360 { get; set; }

    [Display("Thumb 360 width")]
    [JsonProperty("thumb_360_w")]
    public int Thumb360W { get; set; }

    [Display("Thumb 360 height")]
    [JsonProperty("thumb_360_h")]
    public int Thumb360H { get; set; }

    [Display("Thumb 480")]
    [JsonProperty("thumb_480")]
    public string Thumb480 { get; set; }

    [Display("Thumb 480 width")]
    [JsonProperty("thumb_480_w")]
    public int Thumb480W { get; set; }

    [Display("Thumb 480 height")]
    [JsonProperty("thumb_480_h")]
    public int Thumb480H { get; set; }

    [Display("Thumb 160")]
    [JsonProperty("thumb_160")]
    public string Thumb160 { get; set; }

    [JsonProperty("image_exif_rotation")]
    public int ImageExifRotation { get; set; }

    [Display("Original width")]
    [JsonProperty("original_w")]
    public int OriginalW { get; set; }

    [Display("Original height")]
    [JsonProperty("original_h")]
    public int OriginalH { get; set; }

    [JsonProperty("pjpeg")]
    public string Pjpeg { get; set; }

    [JsonProperty("permalink")]
    public string Permalink { get; set; }

    [Display("Permalink public")]
    [JsonProperty("permalink_public")]
    public string PermalinkPublic { get; set; }

    [Display("Has rich preview")]
    [JsonProperty("has_rich_preview")]
    public bool HasRichPreview { get; set; }
}