using MediatR;
using Microsoft.AspNetCore.Mvc;
using OBILET.API.Application.Queries.Locations;
using OBILET.API.DTOs.Location;

namespace OBILET.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<List<LocationResponse>>> Get([FromBody] GetLocationsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
