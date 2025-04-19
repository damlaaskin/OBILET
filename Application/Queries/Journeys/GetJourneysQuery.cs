using MediatR;
using OBILET.API.DTOs.Journey;
using System.Text.Json.Serialization;

namespace OBILET.API.Application.Queries.Journeys
{
    public class GetJourneysQuery : IRequest<List<JourneyResponse>>
    {
        [JsonPropertyName("originId")]
        public int OriginId { get; set; }

        [JsonPropertyName("destinationId")]
        public int DestinationId { get; set; }

        [JsonPropertyName("departureDate")]
        public string DepartureDate { get; set; }

        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; }

        [JsonPropertyName("deviceId")]
        public string DeviceId { get; set; }
    }
}
