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
    [Route("api/import/dictionaries")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class DictionariesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DictionariesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ImportAsync([FromBody][Required] Dictionaries dictionaries)
        {
            return Ok(await _mediator.Send(new ImportDictionaries(dictionaries)));
        }
    }
}
