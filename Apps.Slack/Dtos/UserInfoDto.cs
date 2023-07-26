using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Dtos
{
    public class UserInfoDto
    {
        public string Id { get; set; }

        [Display("Team ID")]
        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }

        public string Color { get; set; }

        [Display("Real name")]
        [JsonPropertyName("real_name")]
        public string RealName { get; set; }

        [Display("Time zone")]
        [JsonPropertyName("tz")]
        public string TimeZone { get; set; }

        [Display("Time zone label")]
        [JsonPropertyName("tz_label")]
        public string TimeZoneLabel { get; set; }

        [Display("Time zone offset")]
        [JsonPropertyName("tz_offset")]
        public int TimeZoneOffset { get; set; }
        
        public Profile Profile { get; set; }

        [Display("Is admin")]
        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [Display("Is owner")]
        [JsonPropertyName("is_owner")]
        public bool IsOwner { get; set; }

        [Display("Is primary owner")]
        [JsonPropertyName("is_primary_owner")]
        public bool IsPrimaryOwner { get; set; }

        [Display("Is restricted")]
        [JsonPropertyName("is_restricted")]
        public bool IsRestricted { get; set; }

        [Display("Is ultra restricted")]
        [JsonPropertyName("is_ultra_restricted")]
        public bool IsUltraRestricted { get; set; }

        [Display("Is bot")]
        [JsonPropertyName("is_bot")]
        public bool IsBot { get; set; }

        public long Updated { get; set; }

        [Display("Is app user")]
        [JsonPropertyName("is_app_user")]
        public bool IsAppUser { get; set; }

        [Display("Has 2-factor authentication")]
        [JsonPropertyName("has_2fa")]
        public bool Has2FactorAuthentication { get; set; }
    }

    public class Profile
    {
        [Display("Avatar hash")]
        [JsonPropertyName("avatar_hash")]
        public string AvatarHash { get; set; }

        [Display("Status text")]
        [JsonPropertyName("status_text")]
        public string StatusText { get; set; }

        [Display("Status emoji")]
        [JsonPropertyName("status_emoji")]
        public string StatusEmoji { get; set; }

        [Display("Real name")]
        [JsonPropertyName("real_name")]
        public string RealName { get; set; }

        [Display("Display name")]
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [Display("Real name normalized")]
        [JsonPropertyName("real_name_normalized")]
        public string RealNameNormalized { get; set; }

        [Display("Display name normalized")]
        [JsonPropertyName("display_name_normalized")]
        public string DisplayNameNormalized { get; set; }

        public string Email { get; set; }
        public string Team { get; set; }

        [Display("Original image")]
        [JsonPropertyName("image_original")]
        public string ImageOriginal { get; set; }

        [Display("Image 24")]
        [JsonPropertyName("image_24")]
        public string Image24 { get; set; }

        [Display("Image 32")]
        [JsonPropertyName("image_32")]
        public string Image32 { get; set; }

        [Display("Image 48")]
        [JsonPropertyName("image_48")]
        public string Image48 { get; set; }

        [Display("Image 72")]
        [JsonPropertyName("image_72")]
        public string Image72 { get; set; }

        [Display("Image 192")]
        [JsonPropertyName("image_192")]
        public string Image192 { get; set; }

        [Display("Image 512")]
        [JsonPropertyName("image_512")]
        public string Image512 { get; set; }
    }
}
