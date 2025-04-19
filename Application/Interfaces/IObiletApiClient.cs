using OBILET.API.Application.Queries.Journeys;
using OBILET.API.Application.Queries.Locations;
using OBILET.API.DTOs;
using OBILET.API.DTOs.Journey;
using OBILET.API.DTOs.Location;

namespace OBILET.API.Application.Interfaces
{
    public interface IObiletApiClient
    {
        Task<SessionResponseDto> GetSessionAsync(string IpAdress, string Port);
        Task<List<LocationResponse>> GetBusLocationsAsync(GetLocationsQuery request);
        Task<List<JourneyResponse>> GetJourneysAsync(GetJourneysQuery request);

    }
}
