using HeadHunter.HttpClients.Resource;
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
    [Route(ResourceRoutes.ImportProfessionalRolesPath)]
    public class ProfessionalRolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfessionalRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] ProfessionalRole.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.ProfessionalRole>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
