using System.Text.Json.Serialization;

namespace Apps.Slack.Dtos
{
    public class UserInfoDto
    {
        public string Id { get; set; }

        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }

        public string Color { get; set; }

        [JsonPropertyName("real_name")]
        public string RealName { get; set; }

        [JsonPropertyName("tz")]
        public string TimeZone { get; set; }

        [JsonPropertyName("tz_label")]
        public string TimeZoneLabel { get; set; }

        [JsonPropertyName("tz_offset")]
        public int TimeZoneOffset { get; set; }
        
        public Profile Profile { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("is_owner")]
        public bool IsOwner { get; set; }

        [JsonPropertyName("is_primary_owner")]
        public bool IsPrimaryOwner { get; set; }

        [JsonPropertyName("is_restricted")]
        public bool IsRestricted { get; set; }

        [JsonPropertyName("is_ultra_restricted")]
        public bool IsUltraRestricted { get; set; }

        [JsonPropertyName("is_bot")]
        public bool IsBot { get; set; }

        public long Updated { get; set; }

        [JsonPropertyName("is_app_user")]
        public bool IsAppUser { get; set; }

        [JsonPropertyName("has_2fa")]
        public bool Has2FactorAuthentication { get; set; }
    }

    public class Profile
    {
        [JsonPropertyName("avatar_hash")]
        public string AvatarHash { get; set; }

        [JsonPropertyName("status_text")]
        public string StatusText { get; set; }

        [JsonPropertyName("status_emoji")]
        public string StatusEmoji { get; set; }

        [JsonPropertyName("real_name")]
        public string RealName { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("real_name_normalized")]
        public string RealNameNormalized { get; set; }

        [JsonPropertyName("display_name_normalized")]
        public string DisplayNameNormalized { get; set; }

        public string Email { get; set; }
        public string Team { get; set; }

        [JsonPropertyName("image_original")]
        public string ImageOriginal { get; set; }

        [JsonPropertyName("image_24")]
        public string Image24 { get; set; }

        [JsonPropertyName("image_32")]
        public string Image32 { get; set; }

        [JsonPropertyName("image_48")]
        public string Image48 { get; set; }

        [JsonPropertyName("image_72")]
        public string Image72 { get; set; }

        [JsonPropertyName("image_192")]
        public string Image192 { get; set; }

        [JsonPropertyName("image_512")]
        public string Image512 { get; set; }
    }
}
