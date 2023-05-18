using System.Text.Json.Serialization;

namespace Apps.Slack.Dtos
{
    public class FileInfoDto
    {
        public string Id { get; set; }
        public long Created { get; set; }
        public long Timestamp { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Mimetype { get; set; }
        public string Filetype { get; set; }
        
        [JsonPropertyName("pretty_type")]
        public string PrettyType { get; set; }

        public string User { get; set; }
        public string Username { get; set; }
        public bool Editable { get; set; }
        public long Size { get; set; }
        public string Mode { get; set; }

        [JsonPropertyName("is_external")]
        public bool IsExternal { get; set; }

        [JsonPropertyName("external_type")]
        public string ExternalType { get; set; }

        [JsonPropertyName("is_public")]
        public bool IsPublic { get; set; }

        [JsonPropertyName("public_url_shared")]
        public bool PublicUrlShared { get; set; }

        [JsonPropertyName("display_as_bot")]
        public bool DisplayAsBot { get; set; }

        [JsonPropertyName("url_private")]
        public string PrivateUrl { get; set; }

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

        [JsonPropertyName("original_w")]
        public int OriginalWidth { get; set; }

        [JsonPropertyName("original_h")]
        public int OriginalHeight { get; set; }

        [JsonPropertyName("deanimate_gif")]
        public string DeanimateGif { get; set; }

        public string Pjpeg { get; set; }
        public string Permalink { get; set; }

        [JsonPropertyName("edit_link")]
        public string EditLink { get; set; }

        [JsonPropertyName("permalink_public")]
        public string PublicPermalink { get; set; }

        [JsonPropertyName("comments_count")]
        public int CommentsCount { get; set; }

        [JsonPropertyName("is_starred")]
        public bool IsStarred { get; set; }

        public string[] Channels { get; set; }

        public string[] Groups { get; set; }

        public string[] Ims { get; set; }

        [JsonPropertyName("has_rich_preview")]
        public bool HasRichPreview  { get; set; }

        [JsonPropertyName("alt_txt")]
        public string AltTxt { get; set; }
    }
}
