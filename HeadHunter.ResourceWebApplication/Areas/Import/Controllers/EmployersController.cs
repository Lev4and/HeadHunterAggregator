using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Employer = HeadHunter.Database.MongoDb.Features.Employer;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ImportEmployersPath)]
    public class EmployersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<Collections.Employer>), 200)]
        public async Task<IActionResult> Import([FromBody] Employer.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.Employer>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
