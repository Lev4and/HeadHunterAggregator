using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using MetroStation = HeadHunter.Database.MongoDb.Features.MetroStation;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/metroStations")]
    public class MetroStationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MetroStationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] MetroStation.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.MetroStation>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
