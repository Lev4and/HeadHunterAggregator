using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BillingType = HeadHunter.Database.MongoDb.Features.BillingType;
using Collections = HeadHunter.Database.MongoDb.Collections;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.BillingTypesPath)]
    public class BillingTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillingTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.BillingTypesAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.BillingType>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.BillingType>>(await _mediator.Send(new BillingType.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
