using MediatR;
using OBILET.API.Application.Interfaces;
using OBILET.API.DTOs.Journey;

namespace OBILET.API.Application.Queries.Journeys
{
    public class GetJourneysQueryHandler : IRequestHandler<GetJourneysQuery, List<JourneyResponse>>
    {
        private readonly IObiletApiClient _apiClient;

        public GetJourneysQueryHandler(IObiletApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<JourneyResponse>> Handle(GetJourneysQuery request, CancellationToken cancellationToken)
        {
            return await _apiClient.GetJourneysAsync(request);
        }
    }
}
