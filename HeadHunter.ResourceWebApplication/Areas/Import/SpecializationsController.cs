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
    [Route("api/import/specializations")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class SpecializationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecializationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ImportAsync([FromBody][Required] Specialization[] specializations)
        {
            return Ok(await _mediator.Send(new ImportSpecializations(specializations)));
        }
    }
}
