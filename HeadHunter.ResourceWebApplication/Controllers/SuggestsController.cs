using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Suggests = HeadHunter.Database.MongoDb.Features.Suggests;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.SuggestsPath)]
    public class SuggestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuggestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.SuggestsMainQuery)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<List<string>>), 200)]
        public async Task<IActionResult> GetMainSuggests([Required][FromQuery(Name = "q")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            return Ok(new ResponseModel<List<string>>(await _mediator.Send(new Suggests.Main.Command(searchString)), ResponseStatuses.Success));
        }
    }
}
