using Newtonsoft.Json;

namespace TAMDownload.Core.Models
{
    public class Tweet
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        public string? UserId { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("hashtags")]
        public List<string> Hashtags { get; set; } = new();

        [JsonProperty("media")]
        public List<Media> Media { get; set; } = new();
    }
}
