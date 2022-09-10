using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using VacancyType = HeadHunter.Database.MongoDb.Features.VacancyType;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/vacancyTypes")]
    public class VacancyTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacancyTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("find")]
        [ProducesResponseType(typeof(ResponseModel<Collections.VacancyType>), 200)]
        public async Task<IActionResult> FindVacancyType([FromBody] VacancyType.Find.Command command)
        {
            return Ok(new ResponseModel<Collections.VacancyType>(await _mediator.Send(command), ResponseStatuses.Success));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> CreateVacancyType([FromBody] VacancyType.Create.Command command)
        {
            return Ok(new ResponseModel<ObjectId>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
