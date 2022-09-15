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
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] WorkingTimeMode.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.WorkingTimeMode>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
