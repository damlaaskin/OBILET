using MediatR;
using Microsoft.AspNetCore.Mvc;
using OBILET.API.Application.Queries.Journeys;
using OBILET.API.Application.Resources;
using OBILET.API.DTOs.Journey;

namespace OBILET.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JourneyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JourneyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<List<JourneyResponse>>> Get([FromBody] GetJourneysQuery query)
        {
            var journeys = await _mediator.Send(query);

            if (journeys == null || !journeys.Any())
                return NotFound(ValidationMessages.NotFoundJourney);

            return Ok(journeys);
        }
    }
}
