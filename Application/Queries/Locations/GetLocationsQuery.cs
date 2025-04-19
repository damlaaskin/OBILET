using MediatR;
using OBILET.API.DTOs.Location;
using System.Text.Json.Serialization;

namespace OBILET.API.Application.Queries.Locations
{
    public class GetLocationsQuery : IRequest<List<LocationResponse>>
    {
        [JsonPropertyName("keyword")]
        public string? Keyword { get; set; }

        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; }

        [JsonPropertyName("deviceId")]
        public string DeviceId { get; set; }
    }
}
