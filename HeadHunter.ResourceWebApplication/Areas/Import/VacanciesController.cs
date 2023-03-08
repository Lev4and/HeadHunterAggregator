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
    [Route("api/import/vacancies")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class VacanciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacanciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ImportAsync([FromBody][Required] Vacancy vacancy)
        {
            return Ok(await _mediator.Send(new ImportVacancy(vacancy)));
        }
    }
}
