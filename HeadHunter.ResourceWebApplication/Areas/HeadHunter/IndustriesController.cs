using HeadHunter.Infrastructure.Queries.HeadHunter;
using HeadHunter.ResourceWebApplication.Extensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter
{
    [ApiController]
    [Area("HeadHunter")]
    [Route("api/headhunter/industries")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class IndustriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndustriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetIndustriesAsync()
        {
            return Ok(await _mediator.Send(new GetIndustries()));
        }
    }
}
