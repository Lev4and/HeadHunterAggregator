using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using WorkingDay = HeadHunter.Database.MongoDb.Features.WorkingDay;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/workingDays")]
    public class WorkingDaysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkingDaysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("find")]
        [ProducesResponseType(typeof(ResponseModel<Collections.WorkingDay>), 200)]
        public async Task<IActionResult> FindWorkingDay([FromBody] WorkingDay.Find.Command command)
        {
            return Ok(new ResponseModel<Collections.WorkingDay>(await _mediator.Send(command), ResponseStatuses.Success));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> CreateWorkingDay([FromBody] WorkingDay.Create.Command command)
        {
            return Ok(new ResponseModel<ObjectId>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
