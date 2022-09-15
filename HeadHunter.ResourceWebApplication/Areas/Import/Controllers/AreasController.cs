using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Area = HeadHunter.Database.MongoDb.Features.Area;
using Collections = HeadHunter.Database.MongoDb.Collections;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ImportAreaPath)]
    public class AreasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AreasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] Area.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.Area>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
