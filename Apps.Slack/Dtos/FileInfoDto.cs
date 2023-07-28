using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Dtos
{
    public class FileInfoDto
    {
        [Display("File ID")]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("created")]
        public long Created { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Display("Mime type")]
        [JsonPropertyName("mimetype")]
        public string Mimetype { get; set; }

        [Display("File type")]
        [JsonPropertyName("filetype")]
        public string Filetype { get; set; }

        [Display("Pretty type")]
        [JsonPropertyName("pretty_type")]
        public string PrettyType { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("editable")]
        public bool Editable { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }

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

        [Display("Shared public url")]
        [JsonPropertyName("public_url_shared")]
        public bool PublicUrlShared { get; set; }

        [Display("Display as bot")]
        [JsonPropertyName("display_as_bot")]
        public bool DisplayAsBot { get; set; }

        [Display("Private url")]
        [JsonPropertyName("url_private")]
        public string PrivateUrl { get; set; }

        [Display("Private url download")]
        [JsonPropertyName("url_private_download")]
        public string PrivateUrlDownload { get; set; }

        [JsonPropertyName("thumb_64")]
        public string Thumb64 { get; set; }

        [JsonPropertyName("thumb_80")]
        public string Thumb80 { get; set; }

        [JsonPropertyName("thumb_360")]
        public string Thumb360 { get; set; }

        [JsonPropertyName("thumb_360_w")]
        public int Thumb360Width { get; set; }

        [JsonPropertyName("thumb_360_h")]
        public int Thumb360Height { get; set; }

        [JsonPropertyName("thumb_160")]
        public string Thumb160 { get; set; }


        [JsonPropertyName("thumb_360_gif")]
        public string Thumb360Gif { get; set; }

        [JsonPropertyName("image_exif_rotation")]
        public int ImageExifRotation { get; set; }

        [Display("Original width")]
        [JsonPropertyName("original_w")]
        public int OriginalWidth { get; set; }

        [Display("Original height")]
        [JsonPropertyName("original_h")]
        public int OriginalHeight { get; set; }

        [Display("Deanimate gif")]
        [JsonPropertyName("deanimate_gif")]
        public string DeanimateGif { get; set; }

        public string Pjpeg { get; set; }

        [JsonPropertyName("permalink")]
        public string Permalink { get; set; }

        [Display("Edit link")]
        [JsonPropertyName("edit_link")]
        public string EditLink { get; set; }

        [Display("Public permalink")]
        [JsonPropertyName("permalink_public")]
        public string PublicPermalink { get; set; }

        [Display("Comments count")]
        [JsonPropertyName("comments_count")]
        public int CommentsCount { get; set; }

        [Display("Is starred")]
        [JsonPropertyName("is_starred")]
        public bool IsStarred { get; set; }

        [JsonPropertyName("channels")]
        public string[] Channels { get; set; }

        [JsonPropertyName("groups")]
        public string[] Groups { get; set; }

        [JsonPropertyName("ims")]
        public string[] Ims { get; set; }

        [Display("Has rich preview")]
        [JsonPropertyName("has_rich_preview")]
        public bool HasRichPreview  { get; set; }

        [Display("Alternative text")]
        [JsonPropertyName("alt_txt")]
        public string AltTxt { get; set; }
    }
}
