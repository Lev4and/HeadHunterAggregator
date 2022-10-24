using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using DriverLicenseType = HeadHunter.Database.MongoDb.Features.DriverLicenseType;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.DriverLicenseTypesPath)]
    public class DriverLicenseTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DriverLicenseTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.DriverLicenseTypesAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.DriverLicenseType>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.DriverLicenseType>>(await _mediator.Send(new DriverLicenseType.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
