using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Entities;

public class UserEntity
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [Display("Team ID")]
    [JsonProperty("team_id")]
    public string TeamId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("deleted")]
    public bool Deleted { get; set; }

    [JsonProperty("color")]
    public string Color { get; set; }

    [Display("Real name")]
    [JsonProperty("real_name")]
    public string RealName { get; set; }

    [Display("Time zone")]
    [JsonProperty("tz")]
    public string TimeZone { get; set; }

    [Display("Time zone label")]
    [JsonProperty("tz_label")]
    public string TimeZoneLabel { get; set; }

    [Display("Time zone offset")]
    [JsonProperty("tz_offset")]
    public int TimeZoneOffset { get; set; }

    [JsonProperty("profile")]
    public Profile Profile { get; set; }

    [Display("Is admin")]
    [JsonProperty("is_admin")]
    public bool IsAdmin { get; set; }

    [Display("Is owner")]
    [JsonProperty("is_owner")]
    public bool IsOwner { get; set; }

    [Display("Is primary owner")]
    [JsonProperty("is_primary_owner")]
    public bool IsPrimaryOwner { get; set; }

    [Display("Is restricted")]
    [JsonProperty("is_restricted")]
    public bool IsRestricted { get; set; }

    [Display("Is ultra restricted")]
    [JsonProperty("is_ultra_restricted")]
    public bool IsUltraRestricted { get; set; }

    [Display("Is bot")]
    [JsonProperty("is_bot")]
    public bool IsBot { get; set; }

    [JsonProperty("updated")]
    public long Updated { get; set; }

    [Display("Is app user")]
    [JsonProperty("is_app_user")]
    public bool IsAppUser { get; set; }

    [Display("Has 2-factor authentication")]
    [JsonProperty("has_2fa")]
    public bool Has2FactorAuthentication { get; set; }
}

public class Profile
{
    [Display("Avatar hash")]
    [JsonProperty("avatar_hash")]
    public string AvatarHash { get; set; }

    [Display("Status text")]
    [JsonProperty("status_text")]
    public string StatusText { get; set; }

    [Display("Status emoji")]
    [JsonProperty("status_emoji")]
    public string StatusEmoji { get; set; }

    [Display("Real name")]
    [JsonProperty("real_name")]
    public string RealName { get; set; }

    [Display("Display name")]
    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    [Display("Real name normalized")]
    [JsonProperty("real_name_normalized")]
    public string RealNameNormalized { get; set; }

    [Display("Display name normalized")]
    [JsonProperty("display_name_normalized")]
    public string DisplayNameNormalized { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("team")]
    public string Team { get; set; }

    [Display("Original image")]
    [JsonProperty("image_original")]
    public string ImageOriginal { get; set; }

    [Display("Image 24")]
    [JsonProperty("image_24")]
    public string Image24 { get; set; }

    [Display("Image 32")]
    [JsonProperty("image_32")]
    public string Image32 { get; set; }

    [Display("Image 48")]
    [JsonProperty("image_48")]
    public string Image48 { get; set; }

    [Display("Image 72")]
    [JsonProperty("image_72")]
    public string Image72 { get; set; }

    [Display("Image 192")]
    [JsonProperty("image_192")]
    public string Image192 { get; set; }

    [Display("Image 512")]
    [JsonProperty("image_512")]
    public string Image512 { get; set; }
}