using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Experience = HeadHunter.Database.MongoDb.Features.Experience;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ImportExperiencesPath)]
    public class ExperiencesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExperiencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] Experience.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.Experience>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
