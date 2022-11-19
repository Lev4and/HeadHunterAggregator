using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Employment = HeadHunter.Database.MongoDb.Features.Employment;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.EmploymentsPath)]
    public class EmploymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmploymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.EmploymentsAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.Employment>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.Employment>>(await _mediator.Send(new Employment.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
