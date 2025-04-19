using System.Text.Json.Serialization;

namespace OBILET.API.DTOs
{
    public class SessionRequestDto
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("connection")]
        public ConnectionInfo Connection { get; set; }
        [JsonPropertyName("browser")]
        public BrowserInfo Browser { get; set; }
    }

    public class ConnectionInfo
    {
        [JsonPropertyName("ip-address")]
        public string IpAddress { get; set; }

        [JsonPropertyName("port")]
        public string Port { get; set; }
    }

    public class BrowserInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
