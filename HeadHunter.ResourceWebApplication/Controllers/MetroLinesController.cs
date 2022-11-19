using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using MetroLine = HeadHunter.Database.MongoDb.Features.MetroLine;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.MetroLinesPath)]
    public class MetroLinesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MetroLinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.MetroLinesAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.MetroLine>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.MetroLine>>(await _mediator.Send(new MetroLine.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
