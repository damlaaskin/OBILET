using MediatR;
using OBILET.API.DTOs;

namespace OBILET.API.Application.Queries.Sessions
{
    public class GetSessionsQuery : IRequest<SessionResponseDto>
    {
        public string IpAddress { get; set; }

        public string Port { get; set; }
    }
}
