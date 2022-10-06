using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BillingType = HeadHunter.Database.MongoDb.Features.BillingType;
using Collections = HeadHunter.Database.MongoDb.Collections;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ImportBillingTypesPath)]
    public class BillingTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillingTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<Collections.BillingType>), 200)]
        public async Task<IActionResult> Import([FromBody] BillingType.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.BillingType>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
