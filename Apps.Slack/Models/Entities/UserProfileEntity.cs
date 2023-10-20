using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Entities;

public class UserProfileEntity
{
    public string Title { get; set; }
    public string Phone { get; set; }
    public string Skype { get; set; }

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

    [Display("Status text")]
    [JsonProperty("status_text")]
    public string StatusText { get; set; }

    [Display("Status emoji")]
    [JsonProperty("status_emoji")]
    public string StatusEmoji { get; set; }

    [Display("Status emoji display info")]
    [JsonProperty("status_emoji_display_info")]
    public string[] StatusEmojiDisplayInfo { get; set; }

    [Display("Expiration status")]
    [JsonProperty("status_expiration")]
    public long StatusExpiration { get; set; }

    [Display("Avatar hash")]
    [JsonProperty("avatar_hash")]
    public string AvatarHash { get; set; }

    [Display("Start date")]
    [JsonProperty("start_date")]
    public string StartDate { get; set; }

    public string Email { get; set; }

    public string Pronouns { get; set; }

    [Display("Huddle state")]
    [JsonProperty("huddle_state")]
    public string HuddleState { get; set; }

    [Display("Huddle state expiration timestamp")]
    [JsonProperty("huddle_state_expiration_ts")]
    public long HuddleStateExpirationTs { get; set; }

    [Display("First name")]
    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [Display("Last name")]
    [JsonProperty("last_name")]
    public string LastName { get; set; }

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