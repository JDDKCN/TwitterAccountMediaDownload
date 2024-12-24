using Newtonsoft.Json;

namespace TAMDownload.Core.Models
{
    public class Media
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("bitrate")]
        public long? Bitrate { get; set; }
    }
}
