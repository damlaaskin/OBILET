using MediatR;
using OBILET.API.Application.Interfaces;
using OBILET.API.DTOs.Location;

namespace OBILET.API.Application.Queries.Locations
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, List<LocationResponse>>
    {
        private readonly IObiletApiClient _apiClient;

        public GetLocationsQueryHandler(IObiletApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<LocationResponse>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            return await _apiClient.GetBusLocationsAsync(request);
        }
    }
}
