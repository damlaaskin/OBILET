using MediatR;
using OBILET.API.Application.Interfaces;
using OBILET.API.DTOs;

namespace OBILET.API.Application.Queries.Sessions
{
    public class GetSessionsQueryHandler : IRequestHandler<GetSessionsQuery, SessionResponseDto>
    {
        private readonly IObiletApiClient _apiClient;

        public GetSessionsQueryHandler(IObiletApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<SessionResponseDto> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
        {
            return await _apiClient.GetSessionAsync(request.IpAddress, request.Port);
        }
    }
}
