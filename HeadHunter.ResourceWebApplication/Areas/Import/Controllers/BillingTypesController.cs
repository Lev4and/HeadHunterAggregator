using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using BillingType = HeadHunter.Database.MongoDb.Features.BillingType;
using Collections = HeadHunter.Database.MongoDb.Collections;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/billingTypes")]
    public class BillingTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillingTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] BillingType.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.BillingType>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
