using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using KeySkill = HeadHunter.Database.MongoDb.Features.KeySkill;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ImportKeySkillsPath)]
    public class KeySkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KeySkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] KeySkill.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.KeySkill>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
