using System.Text.Json.Serialization;

namespace OBILET.API.DTOs.Journey
{
    public class JourneyResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("partner-id")]
        public int PartnerId { get; set; }

        [JsonPropertyName("partner-name")]
        public string PartnerName { get; set; }

        [JsonPropertyName("route-id")]
        public int RouteId { get; set; }

        [JsonPropertyName("bus-type")]
        public string BusType { get; set; }

        [JsonPropertyName("bus-type-name")]
        public string BusTypeName { get; set; }

        [JsonPropertyName("total-seats")]
        public int TotalSeats { get; set; }

        [JsonPropertyName("available-seats")]
        public int AvailableSeats { get; set; }

        [JsonPropertyName("journey")]
        public JourneyDetailDto Journey { get; set; }

        [JsonPropertyName("features")]
        public List<FeatureDto> Features { get; set; }

        [JsonPropertyName("origin-location")]
        public string OriginLocation { get; set; }

        [JsonPropertyName("destination-location")]
        public string DestinationLocation { get; set; }

        [JsonPropertyName("origin-location-id")]
        public int OriginLocationId { get; set; }

        [JsonPropertyName("destination-location-id")]
        public int DestinationLocationId { get; set; }

        [JsonPropertyName("is-active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonPropertyName("partner-rating")]
        public double PartnerRating { get; set; }

        [JsonPropertyName("partner-route-rating")]
        public double PartnerRouteRating { get; set; }

        [JsonPropertyName("partner-route-rating-vote-count")]
        public int PartnerRouteRatingVoteCount { get; set; }

        [JsonPropertyName("partner-rating-vote-count")]
        public int PartnerRatingVoteCount { get; set; }

        [JsonPropertyName("internet-price")]
        public decimal InternetPrice { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

    }

    public class JourneyDetailDto
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("departure")]
        public DateTime Departure { get; set; }

        [JsonPropertyName("arrival")]
        public DateTime Arrival { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("original-price")]
        public decimal OriginalPrice { get; set; }

        [JsonPropertyName("internet-price")]
        public decimal InternetPrice { get; set; }

        [JsonPropertyName("provider-internet-price")]
        public decimal? ProviderInternetPrice { get; set; }

        [JsonPropertyName("bus-name")]
        public string BusName { get; set; }

        [JsonPropertyName("policy")]
        public PolicyDto Policy { get; set; }

        [JsonPropertyName("features")]
        public List<string> Features { get; set; }

        [JsonPropertyName("stops")]
        public List<StopDto> Stops { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class StopDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("kolayCarLocationId")]
        public int? KolayCarLocationId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("station")]
        public string Station { get; set; }

        [JsonPropertyName("time")]
        public DateTime? Time { get; set; }

        [JsonPropertyName("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonPropertyName("is-destination")]
        public bool IsDestination { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }
    }

    public class FeatureDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("priority")]
        public int? Priority { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class PolicyDto
    {
        [JsonPropertyName("max-seats")]
        public int? MaxSeats { get; set; }

        [JsonPropertyName("max-single")]
        public int? MaxSingle { get; set; }

        [JsonPropertyName("max-single-males")]
        public int? MaxSingleMales { get; set; }

        [JsonPropertyName("max-single-females")]
        public int? MaxSingleFemales { get; set; }

        [JsonPropertyName("mixed-genders")]
        public bool MixedGenders { get; set; }

        [JsonPropertyName("gov-id")]
        public bool GovId { get; set; }

        [JsonPropertyName("lht")]
        public bool Lht { get; set; }
    }


}
