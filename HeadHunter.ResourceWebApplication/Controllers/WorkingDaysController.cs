using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using WorkingDay = HeadHunter.Database.MongoDb.Features.WorkingDay;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.WorkingDaysPath)]
    public class WorkingDaysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkingDaysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.WorkingDaysAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.WorkingDay>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.WorkingDay>>(await _mediator.Send(new WorkingDay.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
