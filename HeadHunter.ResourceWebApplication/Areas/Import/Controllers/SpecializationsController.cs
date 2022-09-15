using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Specialization = HeadHunter.Database.MongoDb.Features.Specialization;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ImportSpecializationsPath)]
    public class SpecializationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecializationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] Specialization.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.Specialization>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
