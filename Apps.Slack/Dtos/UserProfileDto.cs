using System.Text.Json.Serialization;

namespace Apps.Slack.Dtos
{
    public class UserProfileDto
    {
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }

        [JsonPropertyName("real_name")]
        public string RealName { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("real_name_normalized")]
        public string RealNameNormalized { get; set; }

        [JsonPropertyName("display_name_normalized")]
        public string DisplayNameNormalized { get; set; }

        [JsonPropertyName("status_text")]
        public string StatusText { get; set; }

        [JsonPropertyName("status_emoji")]
        public string StatusEmoji { get; set; }

        [JsonPropertyName("status_emoji_display_info")]
        public string[] StatusEmojiDisplayInfo { get; set; }

        [JsonPropertyName("status_expiration")]
        public long StatusExpiration { get; set; }

        [JsonPropertyName("avatar_hash")]
        public string AvatarHash { get; set; }

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        public string Email { get; set; }

        public string Pronouns { get; set; }

        [JsonPropertyName("huddle_state")]
        public string HuddleState { get; set; }

        [JsonPropertyName("huddle_state_expiration_ts")]
        public long HuddleStateExpirationTs { get; set; }
        
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

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
