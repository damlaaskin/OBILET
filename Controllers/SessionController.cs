using MediatR;
using Microsoft.AspNetCore.Mvc;
using OBILET.API.Application.Queries.Sessions;
using OBILET.API.DTOs;

namespace OBILET.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<SessionResponseDto>> Get([FromBody] GetSessionsQuery query)
        {
            var session = await _mediator.Send(query);

            if (session == null)
                return NotFound();

            return Ok(session);
        }
    }
}
