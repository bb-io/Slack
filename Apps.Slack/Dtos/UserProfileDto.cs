using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Dtos
{
    public class UserProfileDto
    {
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }

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

        [Display("Status text")]
        [JsonPropertyName("status_text")]
        public string StatusText { get; set; }

        [Display("Status emoji")]
        [JsonPropertyName("status_emoji")]
        public string StatusEmoji { get; set; }

        [Display("Status emoji display info")]
        [JsonPropertyName("status_emoji_display_info")]
        public string[] StatusEmojiDisplayInfo { get; set; }

        [Display("Expiration status")]
        [JsonPropertyName("status_expiration")]
        public long StatusExpiration { get; set; }

        [Display("Avatar hash")]
        [JsonPropertyName("avatar_hash")]
        public string AvatarHash { get; set; }

        [Display("Start date")]
        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        public string Email { get; set; }

        public string Pronouns { get; set; }

        [Display("Huddle state")]
        [JsonPropertyName("huddle_state")]
        public string HuddleState { get; set; }

        [Display("Huddle state expiration timestamp")]
        [JsonPropertyName("huddle_state_expiration_ts")]
        public long HuddleStateExpirationTs { get; set; }

        [Display("First name")]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [Display("Last name")]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

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
