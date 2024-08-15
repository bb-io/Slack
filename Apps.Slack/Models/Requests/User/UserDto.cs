using Newtonsoft.Json;

namespace Apps.Slack.Models.Requests.User;

public class UserDto
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;
    
    [JsonProperty("team_id")]
    public string TeamId { get; set; } = string.Empty;
    
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonProperty("deleted")]
    public bool Deleted { get; set; }
    
    [JsonProperty("color")]
    public string RealName { get; set; } = string.Empty;
    
    [JsonProperty("tz")]
    public string Tz { get; set; } = string.Empty;
    
    [JsonProperty("tz_label")]
    public string TzLabel { get; set; } = string.Empty;
    
    [JsonProperty("tz_offset")]
    public int TzOffset { get; set; }
    
    [JsonProperty("is_admin")]
    public bool IsAdmin { get; set; }
    
    [JsonProperty("is_owner")]
    public bool IsOwner { get; set; }
    
    [JsonProperty("is_primary_owner")]
    public bool IsPrimaryOwner { get; set; }
    
    [JsonProperty("is_restricted")]
    public bool IsRestricted { get; set; }
    
    [JsonProperty("is_ultra_restricted")]
    public bool IsUltraRestricted { get; set; }
    
    [JsonProperty("is_bot")]
    public bool IsBot { get; set; }
    
    [JsonProperty("updated")]
    public int Updated { get; set; }
    
    [JsonProperty("is_app_user")]
    public bool IsAppUser { get; set; }
    
    [JsonProperty("has_2fa")]
    public bool Has2Fa { get; set; }
}