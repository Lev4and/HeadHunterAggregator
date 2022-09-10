using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Experience = HeadHunter.Database.MongoDb.Features.Experience;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/experiences")]
    public class ExperiencesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExperiencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("find")]
        [ProducesResponseType(typeof(ResponseModel<Collections.Experience>), 200)]
        public async Task<IActionResult> FindExperience([FromBody] Experience.Find.Command command)
        {
            return Ok(new ResponseModel<Collections.Experience>(await _mediator.Send(command), ResponseStatuses.Success));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> CreateExperience([FromBody] Experience.Create.Command command)
        {
            return Ok(new ResponseModel<ObjectId>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
