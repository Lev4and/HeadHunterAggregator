using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using DriverLicenseType = HeadHunter.Database.MongoDb.Features.DriverLicenseType;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/driverLicenseTypes")]
    public class DriverLicenseTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DriverLicenseTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("find")]
        [ProducesResponseType(typeof(ResponseModel<Collections.DriverLicenseType>), 200)]
        public async Task<IActionResult> FindDriverLicenseType([FromBody] DriverLicenseType.Find.Command command)
        {
            return Ok(new ResponseModel<Collections.DriverLicenseType>(await _mediator.Send(command), ResponseStatuses.Success));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> CreateDriverLicenseType([FromBody] DriverLicenseType.Create.Command command)
        {
            return Ok(new ResponseModel<ObjectId>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
