using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using WorkingTimeMode = HeadHunter.Database.MongoDb.Features.WorkingTimeMode;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/workingTimeModes")]
    public class WorkingTimeModesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkingTimeModesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("find")]
        [ProducesResponseType(typeof(ResponseModel<Collections.WorkingTimeMode>), 200)]
        public async Task<IActionResult> FindWorkingTimeMode([FromBody] WorkingTimeMode.Find.Command command)
        {
            return Ok(new ResponseModel<Collections.WorkingTimeMode>(await _mediator.Send(command), ResponseStatuses.Success));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> CreateWorkingTimeMode([FromBody] WorkingTimeMode.Create.Command command)
        {
            return Ok(new ResponseModel<ObjectId>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
