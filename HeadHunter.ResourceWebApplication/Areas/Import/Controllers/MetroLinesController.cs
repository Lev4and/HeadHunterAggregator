using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using MetroLine = HeadHunter.Database.MongoDb.Features.MetroLine;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/metroLines")]
    public class MetroLinesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MetroLinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] MetroLine.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.MetroLine>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
