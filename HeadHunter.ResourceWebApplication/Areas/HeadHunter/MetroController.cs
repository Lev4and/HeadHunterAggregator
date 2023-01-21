using HeadHunter.Infrastructure.Queries.HeadHunter;
using HeadHunter.ResourceWebApplication.Extensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter
{
    [ApiController]
    [Area("HeadHunter")]
    [Route("api/headhunter/metro")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class MetroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MetroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("stations")]
        private async Task<IActionResult> GetMetroStationsAsync()
        {
            return Ok(await _mediator.Send(new GetMetroStations()));
        }
    }
}
