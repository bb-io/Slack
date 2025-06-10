using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Entities;

public class UserEntity
{
    [Display("User ID")]
    [JsonProperty("id")]
    public string Id { get; set; }

    [Display("Mention user")]
    public string? MentionUser { get { return $"<@{Id}>"; } }

    [Display("Team ID")]
    [JsonProperty("team_id")]
    public string TeamId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [Display("Is deleted")]
    [JsonProperty("deleted")]
    public bool Deleted { get; set; }

    [JsonProperty("color")]
    public string Color { get; set; }

    [Display("Real name")]
    [JsonProperty("real_name")]
    public string RealName { get; set; }

    [Display("Timezone")]
    [JsonProperty("tz")]
    public string TimeZone { get; set; }

    [Display("Timezone label")]
    [JsonProperty("tz_label")]
    public string TimeZoneLabel { get; set; }

    [Display("Timezone offset")]
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

    [Display("Is app user")]
    [JsonProperty("is_app_user")]
    public bool IsAppUser { get; set; }

    [Display("Has 2-factor authentication")]
    [JsonProperty("has_2fa")]
    public bool Has2FactorAuthentication { get; set; }
}

public class Profile
{
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

    [DefinitionIgnore]
    [JsonProperty("image_72")]
    public string Image72 { get; set; }

}