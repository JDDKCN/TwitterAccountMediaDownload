using Newtonsoft.Json;

namespace TAMDownload.Core.Models
{
    public class TwitterUser
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("screen_name")]
        public string? ScreenName { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("created_time")]
        public long CreatedTime { get; set; }
    }
}
