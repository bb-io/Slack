using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Entities;

public class FileEntity
{
    [Display("File ID")]
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("created")]
    public long Created { get; set; }

    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [Display("Mime type")]
    [JsonProperty("mimetype")]
    public string Mimetype { get; set; }

    [Display("File type")]
    [JsonProperty("filetype")]
    public string Filetype { get; set; }

    [Display("Pretty type")]
    [JsonProperty("pretty_type")]
    public string PrettyType { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("editable")]
    public bool Editable { get; set; }

    [JsonProperty("size")]
    public long Size { get; set; }

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

    [Display("Shared public url")]
    [JsonProperty("public_url_shared")]
    public bool PublicUrlShared { get; set; }

    [Display("Display as bot")]
    [JsonProperty("display_as_bot")]
    public bool DisplayAsBot { get; set; }

    [Display("Private url")]
    [JsonProperty("url_private")]
    public string PrivateUrl { get; set; }

    [Display("Private url download")]
    [JsonProperty("url_private_download")]
    public string PrivateUrlDownload { get; set; }

    [JsonProperty("thumb_64")]
    public string Thumb64 { get; set; }

    [JsonProperty("thumb_80")]
    public string Thumb80 { get; set; }

    [JsonProperty("thumb_360")]
    public string Thumb360 { get; set; }

    [JsonProperty("thumb_360_w")]
    public int Thumb360Width { get; set; }

    [JsonProperty("thumb_360_h")]
    public int Thumb360Height { get; set; }

    [JsonProperty("thumb_160")]
    public string Thumb160 { get; set; }
    
    [JsonProperty("thumb_360_gif")]
    public string Thumb360Gif { get; set; }

    [JsonProperty("image_exif_rotation")]
    public int ImageExifRotation { get; set; }

    [Display("Original width")]
    [JsonProperty("original_w")]
    public int OriginalWidth { get; set; }

    [Display("Original height")]
    [JsonProperty("original_h")]
    public int OriginalHeight { get; set; }

    [Display("Deanimate gif")]
    [JsonProperty("deanimate_gif")]
    public string DeanimateGif { get; set; }

    public string Pjpeg { get; set; }

    [JsonProperty("permalink")]
    public string Permalink { get; set; }

    [Display("Edit link")]
    [JsonProperty("edit_link")]
    public string EditLink { get; set; }

    [Display("Public permalink")]
    [JsonProperty("permalink_public")]
    public string PublicPermalink { get; set; }

    [Display("Comments count")]
    [JsonProperty("comments_count")]
    public int CommentsCount { get; set; }

    [Display("Is starred")]
    [JsonProperty("is_starred")]
    public bool IsStarred { get; set; }
    
    [JsonProperty("shares")]
    public FileShares Shares { get; set; }

    [JsonProperty("channels")]
    public string[] Channels { get; set; }

    [JsonProperty("groups")]
    public string[] Groups { get; set; }

    [JsonProperty("ims")]
    public string[] Ims { get; set; }

    [Display("Has rich preview")]
    [JsonProperty("has_rich_preview")]
    public bool HasRichPreview  { get; set; }

    [Display("Alternative text")]
    [JsonProperty("alt_txt")]
    public string AltTxt { get; set; }
}

public class FileShares
{
    [JsonProperty("public")]
    public Dictionary<string, IEnumerable<FileMessageInfo>>? Public { get; set; }
}

public class FileMessageInfo
{
    [JsonProperty("ts")]
    public string Ts { get; set; }
    
    [JsonProperty("thread_ts")]
    public string? ThreadTs { get; set; }
}