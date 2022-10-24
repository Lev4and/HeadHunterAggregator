using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using WorkingTimeInterval = HeadHunter.Database.MongoDb.Features.WorkingTimeInterval;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.WorkingTimeIntervalsPath)]
    public class WorkingTimeIntervalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkingTimeIntervalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.WorkingTimeIntervalsAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.WorkingTimeInterval>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.WorkingTimeInterval>>(await _mediator.Send(new WorkingTimeInterval.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
