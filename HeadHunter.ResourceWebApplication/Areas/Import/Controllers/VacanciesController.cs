using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Vacancy = HeadHunter.Database.MongoDb.Features.Vacancy;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ImportVacanciesPath)]
    public class VacanciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacanciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<Collections.Vacancy>), 200)]
        public async Task<IActionResult> Import([FromBody] Vacancy.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.Vacancy>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
