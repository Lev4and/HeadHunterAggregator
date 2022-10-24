using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Experience = HeadHunter.Database.MongoDb.Features.Experience;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.ExperiencesPath)]
    public class ExperiencesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExperiencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.ExperiencesAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.Experience>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.Experience>>(await _mediator.Send(new Experience.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
