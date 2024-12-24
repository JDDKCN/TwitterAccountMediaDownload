using Newtonsoft.Json;

namespace TAMDownload.Core.Models
{
    public class MetadataContainer
    {
        [JsonProperty("current_page")]
        public string? CurrentPage { get; set; }

        [JsonProperty("users")]
        public Dictionary<string, UserData> Users { get; set; } = new();

        public class UserData
        {
            [JsonProperty("user")]
            public List<TwitterUser> UserHistory { get; set; } = new();

            [JsonProperty("tweet")]
            public List<Tweet> Tweets { get; set; } = new();
        }
    }
}
