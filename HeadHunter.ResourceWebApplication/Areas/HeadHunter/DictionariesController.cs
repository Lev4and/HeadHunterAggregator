using HeadHunter.Infrastructure.Queries.HeadHunter;
using HeadHunter.ResourceWebApplication.Extensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter
{
    [ApiController]
    [Area("HeadHunter")]
    [Route("api/headhunter/dictionaries")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class DictionariesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DictionariesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDictionariesAsync()
        {
            return Ok(await _mediator.Send(new GetDictionaries()));
        }
    }
}
