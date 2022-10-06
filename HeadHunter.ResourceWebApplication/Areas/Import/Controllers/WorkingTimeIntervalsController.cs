using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using WorkingTimeInterval = HeadHunter.Database.MongoDb.Features.WorkingTimeInterval;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ImportWorkingTimeIntervalsPath)]
    public class WorkingTimeIntervalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkingTimeIntervalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<Collections.WorkingTimeInterval>), 200)]
        public async Task<IActionResult> Import([FromBody] WorkingTimeInterval.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.WorkingTimeInterval>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
