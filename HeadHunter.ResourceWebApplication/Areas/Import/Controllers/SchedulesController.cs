using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Schedule = HeadHunter.Database.MongoDb.Features.Schedule;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ImportSchedulesPath)]
    public class SchedulesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchedulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<Collections.Schedule>), 200)]
        public async Task<IActionResult> Import([FromBody] Schedule.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.Schedule>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
