using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using WorkingDay = HeadHunter.Database.MongoDb.Features.WorkingDay;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ImportWorkingDaysPath)]
    public class WorkingDaysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkingDaysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<Collections.WorkingDay>), 200)]
        public async Task<IActionResult> Import([FromBody] WorkingDay.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.WorkingDay>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
