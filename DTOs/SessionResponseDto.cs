using System.Text.Json.Serialization;

namespace OBILET.API.DTOs
{
    public class SessionResponseDto
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }

        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }
    }
}
