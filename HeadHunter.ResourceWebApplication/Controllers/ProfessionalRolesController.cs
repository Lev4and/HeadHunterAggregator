using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using ProfessionalRole = HeadHunter.Database.MongoDb.Features.ProfessionalRole;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ProfessionalRolesPath)]
    public class ProfessionalRolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfessionalRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.ProfessionalRolesAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.ProfessionalRole>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.ProfessionalRole>>(await _mediator.Send(new ProfessionalRole.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
