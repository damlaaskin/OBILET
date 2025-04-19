using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using OBILET.API.Application.Interfaces;
using OBILET.API.Application.Queries.Journeys;
using OBILET.API.Application.Queries.Locations;
using OBILET.API.Application.Settings;
using OBILET.API.DTOs;
using OBILET.API.DTOs.Journey;
using OBILET.API.DTOs.Location;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace OBILET.API.Infrastructure.Services
{
    public class ObiletApiClient : IObiletApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ObiletApiSettings _settings;
        private readonly IMemoryCache _cache;
        public ObiletApiClient(HttpClient httpClient, IOptions<ObiletApiSettings> options, IMemoryCache cache)
        {
            _cache = cache;
            _httpClient = httpClient;
            _settings = options.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _settings.Token);
        }

        public async Task<SessionResponseDto> GetSessionAsync(string IpAdress, string Port)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "client/getsession");

            request.Content = new StringContent(JsonSerializer.Serialize(new
            {
                type = 1,
                connection = new Dictionary<string, string>
                {
                    { "ip-address", IpAdress },
                    { "port", Port }
                },
                browser = new
                {
                    name = "Chrome",
                    version = "47.0.0.12"
                }
            }), Encoding.UTF8, "application/json");


            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"API ERROR: {response.StatusCode} - {errorMessage}");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<SessionResponseDto>>(jsonString);

            return result.Data;
        }



        public async Task<List<LocationResponse>> GetBusLocationsAsync(GetLocationsQuery query)
        {

            if (string.IsNullOrEmpty(query.Keyword))
            {
                if (_cache.TryGetValue("bus_locations", out List<LocationResponse> cachedLocations))
                {
                    return cachedLocations;
                }
            }


            var request = new HttpRequestMessage(HttpMethod.Post, "location/getbuslocations");
            request.Content = new StringContent(JsonSerializer.Serialize(new Dictionary<string, object>
                                            {
                                                { "data", query.Keyword },
                                                { "device-session", new Dictionary<string, string>
                                                    {
                                                        { "session-id", query.SessionId },
                                                        { "device-id", query.DeviceId }
                                                    }
                                                },
                                                { "date", DateTime.UtcNow.ToString("yyyy-MM-dd") },
                                                { "language", "tr-TR" }
                                            }), Encoding.UTF8, "application/json");


            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"API ERROR: {response.StatusCode} - {errorMessage}");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<List<LocationResponse>>>(jsonString);

            if (string.IsNullOrEmpty(query.Keyword))
                _cache.Set("bus_locations", result.Data, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                });

            return result.Data;
        }

        public async Task<List<JourneyResponse>> GetJourneysAsync(GetJourneysQuery query)
        {
            var payload = new Dictionary<string, object>
            {
                ["device-session"] = new Dictionary<string, string>
                {
                    ["session-id"] = query.SessionId,
                    ["device-id"] = query.DeviceId
                },
                ["date"] = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                ["language"] = "tr-TR",
                ["data"] = new Dictionary<string, object>
                {
                    ["origin-id"] = query.OriginId,
                    ["destination-id"] = query.DestinationId,
                    ["departure-date"] = query.DepartureDate
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("journey/getbusjourneys", content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<List<JourneyResponse>>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result.Data;
        }

    }
}
