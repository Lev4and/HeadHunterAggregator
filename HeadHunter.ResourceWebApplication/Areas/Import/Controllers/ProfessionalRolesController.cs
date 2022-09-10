using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using ProfessionalRole = HeadHunter.Database.MongoDb.Features.ProfessionalRole;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/professionalRoles")]
    public class ProfessionalRolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfessionalRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("find")]
        [ProducesResponseType(typeof(ResponseModel<Collections.ProfessionalRole>), 200)]
        public async Task<IActionResult> FindProfessionalRole([FromBody] ProfessionalRole.Find.Command command)
        {
            return Ok(new ResponseModel<Collections.ProfessionalRole>(await _mediator.Send(command), ResponseStatuses.Success));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> CreateProfessionalRole([FromBody] ProfessionalRole.Create.Command command)
        {
            return Ok(new ResponseModel<ObjectId>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
