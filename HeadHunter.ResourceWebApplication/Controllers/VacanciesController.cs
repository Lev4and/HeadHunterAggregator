using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Vacancy = HeadHunter.Database.MongoDb.Features.Vacancy;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.VacanciesPath)]
    public class VacanciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacanciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<Collections.Vacancy>), 200)]
        public async Task<IActionResult> GetVacancyByHeadHunterId([Required][FromRoute(Name = "id")] long id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            return Ok(new ResponseModel<Collections.Vacancy>(await _mediator.Send(new Vacancy.Find.Command(id)), ResponseStatuses.Success));
        }
    }
}
