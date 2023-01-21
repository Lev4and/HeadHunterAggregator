using HeadHunter.Infrastructure.Queries.HeadHunter;
using HeadHunter.ResourceWebApplication.Extensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter
{
    [ApiController]
    [Area("HeadHunter")]
    [Route("api/headhunter/languages")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class LanguagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetLanguagesAsync()
        {
            return Ok(await _mediator.Send(new GetLanguages()));
        }
    }
}
