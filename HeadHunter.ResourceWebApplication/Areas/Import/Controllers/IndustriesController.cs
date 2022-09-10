using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Industry = HeadHunter.Database.MongoDb.Features.Industry;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/industries")]
    public class IndustriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndustriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("find")]
        [ProducesResponseType(typeof(ResponseModel<Collections.Industry>), 200)]
        public async Task<IActionResult> FindIndustry([FromBody] Industry.Find.Command command)
        {
            return Ok(new ResponseModel<Collections.Industry>(await _mediator.Send(command), ResponseStatuses.Success));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> CreateIndustry([FromBody] Industry.Create.Command command)
        {
            return Ok(new ResponseModel<ObjectId>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
