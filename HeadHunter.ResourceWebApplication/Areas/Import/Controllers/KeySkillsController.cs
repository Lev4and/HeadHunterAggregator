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
    [Route("api/import/keySkills")]
    public class KeySkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KeySkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("find")]
        [ProducesResponseType(typeof(ResponseModel<Collections.KeySkill>), 200)]
        public async Task<IActionResult> FindKeySkill([FromBody] KeySkill.Find.Command command)
        {
            return Ok(new ResponseModel<Collections.KeySkill>(await _mediator.Send(command), ResponseStatuses.Success));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> CreateKeySkill([FromBody] KeySkill.Create.Command command)
        {
            return Ok(new ResponseModel<ObjectId>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
