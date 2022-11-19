using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using WorkingTimeMode = HeadHunter.Database.MongoDb.Features.WorkingTimeMode;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.WorkingTimeModesPath)]
    public class WorkingTimeModesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkingTimeModesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.WorkingTimeModesAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.WorkingTimeMode>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.WorkingTimeMode>>(await _mediator.Send(new WorkingTimeMode.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
