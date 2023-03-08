using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Infrastructure.Commands.Import;
using HeadHunter.ResourceWebApplication.Extensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HeadHunter.ResourceWebApplication.Areas.Import
{
    [ApiController]
    [Area("Import")]
    [Route("api/import/metro")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class MetroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MetroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ImportAsync([FromBody][Required] City[] cities)
        {
            return Ok(await _mediator.Send(new ImportMetro(cities)));
        }
    }
}
