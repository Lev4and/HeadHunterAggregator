using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using MetroStation = HeadHunter.Database.MongoDb.Features.MetroStation;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.MetroStationsPath)]
    public class MetroStationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MetroStationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.MetroStationsAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.MetroStation>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.MetroStation>>(await _mediator.Send(new MetroStation.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
